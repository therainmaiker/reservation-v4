using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reservation_V4.Data;
using Reservation_V4.Models;

namespace Reservation_V4.Controllers
{
    public class ReservationController : Controller
    {
        private ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public ReservationController(ApplicationDbContext context ,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        // GET: ReservationController
        public async Task <ActionResult> Index()
        {
            var jointuretables =await _context.Reservations
                .Include(x=>x.ReservationType)
                .ToListAsync();
            
            return View(jointuretables);
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            List<ReservationType> reservationTypes = _context.ReservationTypes.ToList();
            ViewBag.reservatiolist = new SelectList(reservationTypes, "Id", "ReservationName");

            ViewBag.getuserid = _userManager.GetUserId(HttpContext.User);
            return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection ,Reservation reservation , ReservationType reservationType , UserManager<Student> userManager)
        {
           string userid = HttpContext.User.Identity.Name;



            return View(reservation);
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
