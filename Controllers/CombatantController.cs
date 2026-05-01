using DnDManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace DnDManager.Controllers
{
    public class CombatantController : Controller
    {
        private readonly AppDbContext _context;

        public CombatantController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Combatant/Index?campaignId=1
        public IActionResult Index(int campaignId)
        {
            List<Combatant> combatants = _context.Combatants
                .Where(c => c.CampaignId == campaignId)
                .OrderByDescending(c => c.Initiative)
                .ToList();

            ViewBag.CampaignId = campaignId;
            return View(combatants);
        }

        // GET: /Combatant/Details/1
        public IActionResult Details(int id)
        {
            Combatant? combatant = _context.Combatants.Find(id);

            if (combatant == null)
            {
                return NotFound();
            }

            return View(combatant);
        }

        // GET: /Combatant/Create?campaignId=1
        public IActionResult Create(int campaignId)
        {
            ViewBag.CampaignId = campaignId;
            return View();
        }

        // POST: /Combatant/Create
        [HttpPost]
        public IActionResult Create([Bind("Name,Type,MaxHP,CurrentHP,ArmorClass,Initiative,CampaignId")] Combatant combatant)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CampaignId = combatant.CampaignId;
                return View(combatant);
            }

            _context.Combatants.Add(combatant);
            _context.SaveChanges();

            return RedirectToAction("Index", new { campaignId = combatant.CampaignId });
        }

        // GET: /Combatant/Edit/1
        public IActionResult Edit(int id)
        {
            Combatant? combatant = _context.Combatants.Find(id);

            if (combatant == null)
            {
                return NotFound();
            }

            return View(combatant);
        }

        // POST: /Combatant/Edit/1
        [HttpPost]
        public IActionResult Edit([Bind("CombatantId,Name,Type,MaxHP,CurrentHP,ArmorClass,Initiative,IsDefeated,CampaignId")] Combatant combatant)
        {
            if (!ModelState.IsValid)
            {
                return View(combatant);
            }

            _context.Combatants.Update(combatant);
            _context.SaveChanges();

            return RedirectToAction("Index", new { campaignId = combatant.CampaignId });
        }

        // POST: /Combatant/UpdateHP
        [HttpPost]
        public IActionResult UpdateHP(int combatantId, int newHP)
        {
            Combatant? combatant = _context.Combatants.Find(combatantId);

            if (combatant == null)
            {
                return NotFound();
            }

            combatant.CurrentHP = newHP;

            if (combatant.CurrentHP <= 0)
            {
                combatant.CurrentHP = 0;
                combatant.IsDefeated = true;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", new { campaignId = combatant.CampaignId });
        }

        // POST: /Combatant/ToggleDefeated/1
        [HttpPost]
        public IActionResult ToggleDefeated(int id)
        {
            Combatant? combatant = _context.Combatants.Find(id);

            if (combatant == null)
            {
                return NotFound();
            }

            combatant.IsDefeated = !combatant.IsDefeated;
            _context.SaveChanges();

            return RedirectToAction("Index", new { campaignId = combatant.CampaignId });
        }

        // POST: /Combatant/Delete/1
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Combatant? combatant = _context.Combatants.Find(id);

            if (combatant != null)
            {
                int campaignId = combatant.CampaignId;
                _context.Combatants.Remove(combatant);
                _context.SaveChanges();
                return RedirectToAction("Index", new { campaignId = campaignId });
            }

            return RedirectToAction("Index");
        }
    }
}
