using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RentalEquipmentApp.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IRentalsRepository _rnRepository;
        private readonly ISocietiesRepository _socRepository;

        public RentalsController(IRentalsRepository rnRepository, ISocietiesRepository socRepository)
        {
            _rnRepository = rnRepository;
            _socRepository = socRepository;
        }

        public async Task<IActionResult> Index()
        {
            var rentals = _rnRepository.GetRentals();
            return View(await Task.FromResult(rentals.ToList()));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rn = await Task.FromResult(_rnRepository.GetRentalByID(id));

            if (rn == null)
            {
                return NotFound();
            }

            return View(rn);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["Societies"] = new SelectList(_socRepository.GetSocieties(), "Id", "Name");
            return await Task.FromResult(View());
        }

        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,SocietyId")] Rentals rn)
        {
            if (ModelState.IsValid)
            {
                _rnRepository.InsertRental(rn);
                _rnRepository.Save();
                return await Task.FromResult(RedirectToAction(nameof(Index)));
            }
            return View(rn);
        }    

        private bool EquipmentExists(int id)
        {
            return true;

        }
    }
}
