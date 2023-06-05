using Contracts;
using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RentalsRepository : IRentalsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RentalsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Rentals GetRentalByID(int? rntId)
        {
            return _dbContext.Rentals.Find(rntId);
        }

        public IEnumerable<Rentals> GetRentals()
        {
            return _dbContext.Rentals.ToList();
        }

        public void InsertRental(Rentals rnt)
        {
            _dbContext.Add(rnt);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
