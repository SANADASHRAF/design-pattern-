using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOFWork.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOFWork.EF
{
    public class context :DbContext
    {
        //constructor of dbcontext
        public context(DbContextOptions<context>options):base(options)
        {

        }
        public DbSet<author> authors { get; set; }
        public DbSet<books>  books { get; set; }
    }
}
