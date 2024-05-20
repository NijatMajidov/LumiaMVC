using LumiaMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumiaMVC.Business.Services.Abstract
{
    public interface ITeamService
    {
        void CreateTeam(Team team);
        void DeleteTeam(int id);
        void UpdateTeam(int id,Team newTeam);
        Team GetTeam(Func<Team,bool>? func=null);
        List<Team> GetAllTeams(Func<Team, bool>? func = null);
    }
}
