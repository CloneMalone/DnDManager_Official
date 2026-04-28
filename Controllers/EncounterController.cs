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

        // GET: /Encounter/Index?sessionLogId=1
        public IActionResult Index(int sessionLogId)
        {
            List<Encounter> encounters = _context.Encounters
                .Where(e => e.SessionLogId == sessionLogId)
                .ToList();

            ViewBag.SessionLogId = sessionLogId;
            return View(encounters);
        }

        // GET: /Encounter/Details/1
        public IActionResult Details(int id)
        {
            Encounter? encounter = _context.Encounters
                .Include(e => e.LogEntries)
                .Where(e => e.EncounterId == id)
                .FirstOrDefault();

            if (encounter == null)
            {
                return NotFound();
            }

            return View(encounter);
        }

        // GET: /Encounter/Create?sessionLogId=1
        public IActionResult Create(int sessionLogId)
        {
            ViewBag.SessionLogId = sessionLogId;
            return View();
        }

        // POST: /Encounter/Create
        [HttpPost]
        public IActionResult Create([Bind("Name,Description,Outcome,SessionLogId")] Encounter encounter)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SessionLogId = encounter.SessionLogId;
                return View(encounter);
            }

            _context.Encounters.Add(encounter);
            _context.SaveChanges();

            return RedirectToAction("Index", new { sessionLogId = encounter.SessionLogId });
        }

        // GET: /Encounter/Edit/1
        public IActionResult Edit(int id)
        {
            Encounter? encounter = _context.Encounters.Find(id);

            if (encounter == null)
            {
                return NotFound();
            }

            return View(encounter);
        }

        // POST: /Encounter/Edit/1
        [HttpPost]
        public IActionResult Edit([Bind("EncounterId,Name,Description,Outcome,SessionLogId")] Encounter encounter)
        {
            if (!ModelState.IsValid)
            {
                return View(encounter);
            }

            _context.Encounters.Update(encounter);
            _context.SaveChanges();

            return RedirectToAction("Index", new { sessionLogId = encounter.SessionLogId });
        }

        // POST: /Encounter/Delete/1
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Encounter? encounter = _context.Encounters.Find(id);

            if (encounter != null)
            {
                int sessionLogId = encounter.SessionLogId;
                _context.Encounters.Remove(encounter);
                _context.SaveChanges();
                return RedirectToAction("Index", new { sessionLogId = sessionLogId });
            }

            return RedirectToAction("Index");
        }
    }
}
