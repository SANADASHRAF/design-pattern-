using RepositoryPatternWithUnitOFWork.Core;
using RepositoryPatternWithUnitOFWork.Core.interfaces;
using RepositoryPatternWithUnitOFWork.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOFWork.EF
{
    public class unitOfWork: IunitOfWork
    {
        private readonly context _context;

       public IBaseRepository<author> authors { get; private set; }
        public IBaseRepository<books> books { get; private set; }

        public IBaseRepository<author> authers => throw new NotImplementedException();

        public unitOfWork(context context)
        {
            _context = context;
            authors = new BaseRepository<author>(_context);
            books = new BaseRepository<books>(_context);
        }

        public int complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
