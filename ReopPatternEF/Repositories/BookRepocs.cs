using RepoPatternUnitOfWork.Models;
using RepoPatternUnitOfWork.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReopPatternEF.Repositories
{
    public class BookRepocs : RepoBase<Book> , IBookRepo
    {
        private readonly ApplicationDBContext dBContext;
        public BookRepocs(ApplicationDBContext dBContext) : base(dBContext)
        {
        }

        public IEnumerable<Book> SpecialMethod()
        {
            throw new NotImplementedException();
        }
    }
}
