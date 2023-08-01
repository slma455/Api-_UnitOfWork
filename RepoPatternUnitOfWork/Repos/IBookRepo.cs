using RepoPatternUnitOfWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternUnitOfWork.Repos
{
    public interface IBookRepo : IBaseRepo<Book>
    {
        IEnumerable<Book> SpecialMethod();
    }
}
