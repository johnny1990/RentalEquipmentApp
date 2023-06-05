using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRentalsRepository
    {
        IEnumerable<Rentals> GetRentals();
        Rentals GetRentalByID(int? rntId);
        void InsertRental(Rentals rnt);
        void Save();
    }
}
