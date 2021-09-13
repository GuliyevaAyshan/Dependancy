using Dependency.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dependency.Services
{
    public interface ITeamRepository
    {
        List<Team> GetTeams();
        Team GetTeam(int id);
        Team AddTeam(Team team);

        Team Update(Team team);
        Team Delete(int id);
    }
}
