using BNP.Domain.Entities;
using BNP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFile = BNP.Domain.Entities.UserFile;

namespace BNP.DataAccess.Repositories
{
    public class FileRepository : GenericRepository, IFileRepository
    {
        public FileRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
