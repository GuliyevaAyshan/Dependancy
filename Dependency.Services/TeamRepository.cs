using Dependency.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dependency.Services
{
      public class TeamRepository : ITeamRepository
       {
        private readonly AppDbContext _context;

        public TeamRepository(AppDbContext context)
        {
            _context = context;
        }

        public Team AddTeam(Team model)
        {
            _context.Teams.Add(model);
            _context.SaveChanges();
            return model;
        }

        public Team Delete(int id)
        {
            Team t = _context.Teams.FirstOrDefault(b => b.Id == id);
            _context.Teams.Remove(t);
            _context.SaveChanges();
            return t;
        }

      

        public Team GetTeam(int id)
        {
            return _context.Teams.Find(id);
        }

        public List<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }

        public Team Update(Team team)
        {
            _context.Entry(team).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return team;
        }
    }
}
