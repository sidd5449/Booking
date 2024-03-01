using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Booking.Models;




namespace Booking.Models
{
    public class Slots
    {
        [Key]

        public int Id { get; set; }
        public bool IsBooked { get; set; }
        public int BookedBy {  get; set; }
    }
}
