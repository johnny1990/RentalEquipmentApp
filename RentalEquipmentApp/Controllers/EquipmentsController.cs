using Contracts;
using Entities;
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

        public async Task<IActionResult> Index()
        {
            var equipments = _eqRepository.GetEquipments();
            return View(await Task.FromResult(equipments.ToList()));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await Task.FromResult(_eqRepository.GetEquipmentByID(id));

            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        public async Task<IActionResult> Create()
        {
            return await Task.FromResult(View());
        }

        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Image")] Equipments eq)
        {
            if (ModelState.IsValid)
            {
                 _eqRepository.InsertEquipment(eq);
                 _eqRepository.Save();
                return await Task.FromResult(RedirectToAction(nameof(Index)));
            }
            return View(eq);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eq = await Task.FromResult(_eqRepository.GetEquipmentByID(id));
            if (eq == null)
            {
                return NotFound();
            }
            return View(eq);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Image")] Equipments eq)
        {
            if (id != eq.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _eqRepository.UpdateEquipment(eq);
                    _eqRepository.Save();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(eq.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return await Task.FromResult(RedirectToAction(nameof(Index))); ;
            }
            return View(eq);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eq = await Task.FromResult(_eqRepository.GetEquipmentByID(id));
            if (eq == null)
            {
                return NotFound();
            }

            return View(eq);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eq = await Task.FromResult(_eqRepository.GetEquipmentByID(id));
            _eqRepository.DeleteEquipment(id);
            _eqRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
            return true;
           
        }
    }
}
