using Contracts;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class EquipmentsRepository : IEquipmentsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EquipmentsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteEquipment(int eqId)
        {
            var eq = _dbContext.Equipments.Find(eqId);
            _dbContext.Equipments.Remove(eq);
            Save();
        }

        public Equipments GetEquipmentByID(int? eqId)
        {
            return _dbContext.Equipments.Find(eqId);
        }

        public IEnumerable<Equipments> GetEquipments()
        {
            return _dbContext.Equipments.ToList();
        }

        public void InsertEquipment(Equipments eq)
        {
            _dbContext.Add(eq);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateEquipment(Equipments eq)
        {
            _dbContext.Entry(eq).State = EntityState.Modified;
            Save();
        }
    }
}