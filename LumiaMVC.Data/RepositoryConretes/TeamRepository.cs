using LumiaMVC.Core.Models;
using LumiaMVC.Core.RepositoryAbstract;
using LumiaMVC.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumiaMVC.Data.RepositoryConretes
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
