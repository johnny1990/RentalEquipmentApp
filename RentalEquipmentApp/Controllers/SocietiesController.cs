using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RentalEquipmentApp.Controllers
{
    public class SocietiesController : Controller
    {
        private readonly ISocietiesRepository _socRepository;

        public SocietiesController(ISocietiesRepository socRepository)
        {
            _socRepository = socRepository;
        }

        public async Task<IActionResult> Index()
        {
            var societies = _socRepository.GetSocieties();
            return View(await Task.FromResult(societies.ToList()));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soc = await Task.FromResult(_socRepository.GetSocietyByID(id));

            if (soc == null)
            {
                return NotFound();
            }

            return View(soc);
        }

        public async Task<IActionResult> Create()
        {
            return await Task.FromResult(View());
        }

        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Societies soc)
        {
            if (ModelState.IsValid)
            {
                _socRepository.Insert(soc);
                _socRepository.Save();
                return await Task.FromResult(RedirectToAction(nameof(Index)));
            }
            return View(soc);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soc = await Task.FromResult(_socRepository.GetSocietyByID(id));
            if (soc == null)
            {
                return NotFound();
            }
            return View(soc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Societies soc)
        {
            if (id != soc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _socRepository.Update(soc);
                    _socRepository.Save();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(soc.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return await Task.FromResult(RedirectToAction(nameof(Index)));
            }
            return View(soc);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eq = await Task.FromResult(_socRepository.GetSocietyByID(id));
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
            var eq = await Task.FromResult(_socRepository.GetSocietyByID(id));
            _socRepository.Delete(id);
            _socRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
            return true;

        }
    }
}
