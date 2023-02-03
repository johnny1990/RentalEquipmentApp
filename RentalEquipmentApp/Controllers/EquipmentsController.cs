using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RentalEquipmentApp.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly IEquipmentsRepository _eqRepository;

        public EquipmentsController(IEquipmentsRepository eqRepository)
        {
            _eqRepository = eqRepository;
        }

        public IActionResult Index()
        {
            var equipments = _eqRepository.GetEquipments();
            return View(equipments.ToList());
        }


    }
}
