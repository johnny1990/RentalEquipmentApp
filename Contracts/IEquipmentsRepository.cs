using Entities;

namespace Contracts
{
    public interface IEquipmentsRepository
    {
        IEnumerable<Equipments> GetEquipments();
        Equipments GetEquipmentByID(int? eqId);
        void InsertEquipment(Equipments eq);
        void DeleteEquipment(int eqId);
        void UpdateEquipment(Equipments eq);
        void Save();
    }
}