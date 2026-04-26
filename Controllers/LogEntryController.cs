using DnDManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DnDManager.Controllers
{
    public class LogEntryController : Controller
    {
        private readonly AppDbContext _context;

        public LogEntryController(AppDbContext context)
        {
            _context = context;
        }

           // GET: LogEntry
public async Task<IActionResult> Index()
{
    var logEntries = _context.LogEntries.Include(l => l.Encounter);
    return View(await logEntries.ToListAsync());
}

// GET: LogEntry/Details/5
public async Task<IActionResult> Details(int? id)
{
    if (id == null) return NotFound();

    var logEntry = await _context.LogEntries
        .Include(l => l.Encounter)
        .FirstOrDefaultAsync(m => m.Id == id);

    if (logEntry == null) return NotFound();

    return View(logEntry);
}

// GET: LogEntry/Create
public IActionResult Create()
{
    return View();
}

// POST: LogEntry/Create
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(LogEntry logEntry)
{
    if (ModelState.IsValid)
    {
        _context.Add(logEntry);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(logEntry);
}

// GET: LogEntry/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null) return NotFound();

    var logEntry = await _context.LogEntries.FindAsync(id);
    if (logEntry == null) return NotFound();

    return View(logEntry);
}

// POST: LogEntry/Edit/5
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, LogEntry logEntry)
{
    if (id != logEntry.Id) return NotFound();

    if (ModelState.IsValid)
    {
        _context.Update(logEntry);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(logEntry);
}

// GET: LogEntry/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null) return NotFound();

    var logEntry = await _context.LogEntries
        .FirstOrDefaultAsync(m => m.Id == id);

    if (logEntry == null) return NotFound();

    return View(logEntry);
}

// POST: LogEntry/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var logEntry = await _context.LogEntries.FindAsync(id);
    _context.LogEntries.Remove(logEntry);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}
    }
}
