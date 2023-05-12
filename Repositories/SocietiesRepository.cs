using Contracts;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SocietiesRepository : ISocietiesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SocietiesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int socId)
        {
            var soc = _dbContext.Societies.Find(socId);
            _dbContext.Societies.Remove(soc);
            Save();
        }

        public IEnumerable<Societies> GetSocieties()
        {
            return _dbContext.Societies.ToList();
        }

        public Societies GetSocietyByID(int? socId)
        {
            return _dbContext.Societies.Find(socId);
        }

        public void Insert(Societies soc)
        {
            _dbContext.Add(soc);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Societies soc)
        {
            _dbContext.Entry(soc).State = EntityState.Modified;
            Save();
        }
    }
}
