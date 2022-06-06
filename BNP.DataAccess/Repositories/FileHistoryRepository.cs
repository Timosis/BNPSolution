using BNP.Domain.Entities;
using BNP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.DataAccess.Repositories
{
    public class FileHistoryRepository : GenericRepository, IFileHistoryRepository
    {
        public FileHistoryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
