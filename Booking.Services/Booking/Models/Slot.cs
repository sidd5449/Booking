using System;

namespace Booking.Models
{
    public class Slot
    {
        public int Id { get; set; }
        public bool isBooked { get; set; }

        public string bookedBy { get; set; }
    }
}
