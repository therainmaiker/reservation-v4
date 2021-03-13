using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reservation_V4.Data;
using Reservation_V4.Models;

namespace Reservation_V4.Controllers
{
    public class ReservationController : Controller
    {
        private ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;

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
            
            
            return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection ,Reservation reservation , ReservationType reservationType )
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                _context.SaveChanges();



                //ViewBag.res = reservationType;
                //var ReservationTypeList = (from VAR in _context.ReservationTypes
                //    select new SelectListItem()
                //    {
                //        Text = VAR.ReservationName,
                //        Value = VAR.Id.ToString(),

                //    }).ToList();

              
               

                return RedirectToAction(nameof(Index));
            }
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
