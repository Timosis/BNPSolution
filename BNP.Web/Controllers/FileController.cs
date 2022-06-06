using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using Syncfusion.EJ2.FileManager.Base;
using Syncfusion.EJ2.FileManager.PhysicalFileProvider;
using Microsoft.AspNetCore.Authorization;
using BNP.Domain.Interfaces;
using BNP.Domain.Entities;

namespace BNP.Web.Controllers
{
    public class FileController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public PhysicalFileProvider operation;
        public string basePath;
        string root = @"wwwroot\Files";

        public FileController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IUnitOfWork unitOfWork)
        {
            this.basePath = hostingEnvironment.ContentRootPath;
            this.operation = new PhysicalFileProvider();
            this.operation.RootFolder(this.basePath + this.root);
            _unitOfWork = unitOfWork;
        }
        public object FileOperations([FromBody] FileManagerDirectoryContent args)
        {
            var fullPath = (this.basePath + this.root + args.Path).Replace("/", "\\");
            if (args.Action == "delete" || args.Action == "rename")
            {
                if ((args.TargetPath == null) && (args.Path == ""))
                {
                    FileManagerResponse response = new FileManagerResponse();
                    response.Error = new ErrorDetails { Code = "401", Message = "Restricted to modify the root folder." };
                    return this.operation.ToCamelCase(response);
                }
            }
            switch (args.Action)
            {
                case "read":
                    // reads the file(s) or folder(s) from the given path.
                    return this.operation.ToCamelCase(this.operation.GetFiles(args.Path, args.ShowHiddenItems));
                case "delete":
                    var userFile = GetUserFile(args.Names[0]);
                    if (userFile != null)
                    {
                       AddFileHistory(userFile);
                    }
                    return this.operation.ToCamelCase(this.operation.Delete(args.Path, args.Names));
                case "copy":
                    // copies the selected file(s) or folder(s) from a path and then pastes them into a given target path.
                    return this.operation.ToCamelCase(this.operation.Copy(args.Path, args.TargetPath, args.Names, args.RenameFiles, args.TargetData));
                case "move":
                    // cuts the selected file(s) or folder(s) from a path and then pastes them into a given target path.
                    return this.operation.ToCamelCase(this.operation.Move(args.Path, args.TargetPath, args.Names, args.RenameFiles, args.TargetData));
                case "details":
                    // gets the details of the selected file(s) or folder(s).
                    return this.operation.ToCamelCase(this.operation.Details(args.Path, args.Names, args.Data));
                case "create":
                    AddFile(new UserFile { FileName = args.Name, FileHistory = new List<FileHistory> { new FileHistory { Date = DateTime.Now, Type = StaticType.Create } } });                    
                    return this.operation.ToCamelCase(this.operation.Create(args.Path, args.Name));
                case "search":
                    // gets the list of file(s) or folder(s) from a given path based on the searched key string.
                    return this.operation.ToCamelCase(this.operation.Search(args.Path, args.SearchString, args.ShowHiddenItems, args.CaseSensitive));
                case "rename":
                    return this.operation.ToCamelCase(this.operation.Rename(args.Path, args.Name, args.NewName));
            }
            return null;
        }

        // uploads the file(s) into a specified path
        public IActionResult Upload(string path, IList<IFormFile> uploadFiles, string action)
        {
            FileManagerResponse uploadResponse;
            uploadResponse = operation.Upload(path, uploadFiles, action, null);
            if (uploadResponse.Error != null)
            {
                AddFile(new UserFile { FileName = uploadFiles[0].FileName, FileHistory = new List<FileHistory> { new FileHistory { Date = DateTime.Now, Type = StaticType.Upload } } });
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.StatusCode = Convert.ToInt32(uploadResponse.Error.Code);
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = uploadResponse.Error.Message;
            }

            return Content("");
        }

        public IActionResult Download(string downloadInput)
        {
            FileManagerDirectoryContent args = JsonConvert.DeserializeObject<FileManagerDirectoryContent>(downloadInput);
            var userFile = GetUserFile(args.Names[0]);            
            if (userFile != null)
            {
                AddFileHistory(userFile);
            }
            return operation.Download(args.Path, args.Names, args.Data);
        }

        public UserFile GetUserFile(string fileName)
        {
            return _unitOfWork.FileRepository.GetQueryable<UserFile>(x=>x.FileName == fileName).FirstOrDefault();
        }

        public void AddFile(UserFile userFile)
        {
            _unitOfWork.FileRepository.Add(userFile);
            _unitOfWork.Complete();
        }

        public void AddFileHistory(UserFile userFile)
        {
            var history = new FileHistory { Date = DateTime.Now, Type = StaticType.Delete, UserFileId = userFile.Id };
            _unitOfWork.FileHistoryRepository.Add(history);
            _unitOfWork.Complete();
        }

        public IActionResult GetImage(FileManagerDirectoryContent args)
        {
            return this.operation.GetImage(args.Path, args.Id, false, null, null);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
