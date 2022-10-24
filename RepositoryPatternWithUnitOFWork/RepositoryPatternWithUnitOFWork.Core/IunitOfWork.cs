using RepositoryPatternWithUnitOFWork.Core.interfaces;
using RepositoryPatternWithUnitOFWork.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOFWork.Core
{
   public interface IunitOfWork :IDisposable
    {
        //add all repository
        IBaseRepository<author> authers { get; }
        IBaseRepository<books> books { get; }

        int complete();
    }
}
