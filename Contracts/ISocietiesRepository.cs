using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISocietiesRepository
    {
        IEnumerable<Societies> GetSocieties();
        Societies GetSocietyByID(int? socId);
        void Insert(Societies soc);
        void Delete(int socId);
        void Update(Societies soc);
        void Save();
    }
}
