using RepoPatternUnitOfWork.Models;
using RepoPatternUnitOfWork.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepo<Auther> authers { get; }
        IBookRepo books { get; }
        int Complete();
    }
}
