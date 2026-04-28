using DnDManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace DnDManager.Controllers
{
    public class LogEntryController : Controller
    {
        private readonly AppDbContext _context;

        public LogEntryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /LogEntry/Index?encounterId=1
        public IActionResult Index(int encounterId)
        {
            List<LogEntry> entries = _context.LogEntries
                .Where(l => l.EncounterId == encounterId)
                .OrderBy(l => l.RoundNumber)
                .ThenBy(l => l.TurnOrder)
                .ToList();

            ViewBag.EncounterId = encounterId;
            return View(entries);
        }

        // GET: /LogEntry/Details/1
        public IActionResult Details(int id)
        {
            LogEntry? entry = _context.LogEntries.Find(id);

            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // GET: /LogEntry/Create?encounterId=1
        public IActionResult Create(int encounterId)
        {
            ViewBag.EncounterId = encounterId;
            return View();
        }

        // POST: /LogEntry/Create
        [HttpPost]
        public IActionResult Create([Bind("RoundNumber,TurnOrder,ActorName,TargetName,ActionType,ActionDescription,AttackRoll,DamageDealt,HealingDone,ConditionApplied,HpAfterAction,Notes,EncounterId")] LogEntry entry)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EncounterId = entry.EncounterId;
                return View(entry);
            }

            _context.LogEntries.Add(entry);
            _context.SaveChanges();

            return RedirectToAction("Details", "Encounter", new { id = entry.EncounterId });
        }

        // GET: /LogEntry/Edit/1
        public IActionResult Edit(int id)
        {
            LogEntry? entry = _context.LogEntries.Find(id);

            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: /LogEntry/Edit/1
        [HttpPost]
        public IActionResult Edit([Bind("LogEntryId,RoundNumber,TurnOrder,ActorName,TargetName,ActionType,ActionDescription,AttackRoll,DamageDealt,HealingDone,ConditionApplied,HpAfterAction,Notes,EncounterId")] LogEntry entry)
        {
            if (!ModelState.IsValid)
            {
                return View(entry);
            }

            _context.LogEntries.Update(entry);
            _context.SaveChanges();

            return RedirectToAction("Details", "Encounter", new { id = entry.EncounterId });
        }

        // POST: /LogEntry/Delete/1
        [HttpPost]
        public IActionResult Delete(int id)
        {
            LogEntry? entry = _context.LogEntries.Find(id);

            if (entry != null)
            {
                int encounterId = entry.EncounterId;
                _context.LogEntries.Remove(entry);
                _context.SaveChanges();
                return RedirectToAction("Details", "Encounter", new { id = encounterId });
            }

            return RedirectToAction("Index");
        }
    }
}
