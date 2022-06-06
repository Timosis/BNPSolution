using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFileRepository FileRepository { get; }
        IFileHistoryRepository FileHistoryRepository { get; }
        int Complete();
    }
}
