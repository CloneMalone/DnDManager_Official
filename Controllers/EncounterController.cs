using DnDManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DnDManager.Controllers
{
    public class EncounterController : Controller
    {
        private readonly AppDbContext _context;

        public EncounterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Encounter
public async Task<IActionResult> Index()
{
    var encounters = _context.Encounters.Include(e => e.SessionLog);
    return View(await encounters.ToListAsync());
}

// GET: Encounter/Details/5
public async Task<IActionResult> Details(int? id)
{
    if (id == null) return NotFound();

    var encounter = await _context.Encounters
        .Include(e => e.LogEntries)
        .FirstOrDefaultAsync(m => m.Id == id);

    if (encounter == null) return NotFound();

    return View(encounter);
}

// GET: Encounter/Create
public IActionResult Create()
{
    return View();
}

// POST: Encounter/Create
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(Encounter encounter)
{
    if (ModelState.IsValid)
    {
        _context.Add(encounter);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(encounter);
}

// GET: Encounter/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null) return NotFound();

    var encounter = await _context.Encounters.FindAsync(id);
    if (encounter == null) return NotFound();

    return View(encounter);
}

// POST: Encounter/Edit/5
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, Encounter encounter)
{
    if (id != encounter.Id) return NotFound();

    if (ModelState.IsValid)
    {
        _context.Update(encounter);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(encounter);
}

// GET: Encounter/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null) return NotFound();

    var encounter = await _context.Encounters
        .FirstOrDefaultAsync(m => m.Id == id);

    if (encounter == null) return NotFound();

    return View(encounter);
}

// POST: Encounter/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var encounter = await _context.Encounters.FindAsync(id);
    _context.Encounters.Remove(encounter);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
        }
    }
}
