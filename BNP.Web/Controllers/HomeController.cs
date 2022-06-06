using AutoMapper;
using BNP.DataAccess;
using BNP.Domain.Entities;
using BNP.Domain.Interfaces;
using BNP.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace BNP.Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var _statics = _mapper.Map<List<FileStaticsVM>>(_unitOfWork.FileHistoryRepository.GetQueryable<FileHistory>());
            var chartDataSoruce = _statics.GroupBy(x => x.Type)
                .Select(x => new
                { 
                    Category = x.Key.ToString(),
                    Count = x.Count() 
                });

            ViewBag.FileStatics = chartDataSoruce;
            return View();
        }

        public IActionResult FileHistory(string filename)
        {
            var file = _unitOfWork.FileRepository.GetQueryable<UserFile>(x => x.FileName == filename).IncludeMultiple(x => x.FileHistory).ToList();
            ViewBag.FileName = file[0].FileName;
            ViewBag.History = file[0].FileHistory;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}