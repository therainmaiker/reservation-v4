using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Reservation_V4.Models
{
    public class Reservation
    {
        
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Cause { get; set; }

        public List<Reservation> Reservations { get; set; }
        
     
        public ReservationType ReservationType { get; set; }
        
        
        public IdentityUser User { get; set; }
        

    }


    //public class CreateReservationViewModel
    //{
    //    public List<SelectListItem> ReservationTypes { get; set; }
    //    [Display(Name = "Reservation Type")]
    //    public int ReservationTypeId { get; set; }
    //    public DateTime Date { get; set; }
    //}
}
