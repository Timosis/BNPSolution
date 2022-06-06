using BNP.DataAccess.Repositories;
using BNP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            FileRepository = new FileRepository(_context);
            FileHistoryRepository = new FileHistoryRepository(_context);
        }

        public IFileRepository FileRepository { get; private set; }
        public IFileHistoryRepository FileHistoryRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
