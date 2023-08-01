using Microsoft.EntityFrameworkCore;
using RepoPatternUnitOfWork;
using RepoPatternUnitOfWork.Models;
using RepoPatternUnitOfWork.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReopPatternEF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IBaseRepo<Auther> authers { get; private set; }
        public IBookRepo books { get; private set; }
        public UnitOfWork(ApplicationDBContext dBContext)
        {
            this._context = dBContext;
            authers = new RepoBase<Auther>(dBContext);
            books = new BookRepocs(dBContext);
        }
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
