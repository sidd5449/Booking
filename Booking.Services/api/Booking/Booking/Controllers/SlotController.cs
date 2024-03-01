using Booking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SlotController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]

        public class SlotsController : ControllerBase
        {
            private UsersDbContext _slots;
            public SlotsController(UsersDbContext slots)
            {
                _slots = slots;
            }
            [HttpGet]
            public IActionResult Get()
            {
                var slot = _slots.Slots;
                return Ok(slot);
            }

            public Slots GetById(int id)
            {
                var slots = _slots.Slots.Find(id);
                if (slots == null) { throw new KeyNotFoundException("Slot not found"); }
                return slots;
            }
            [AllowAnonymous]
            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                var emp = _slots.Slots.Find(id);
                return Ok(emp);
            }

            [HttpPut("{id}")]
            public IActionResult Put([FromBody] Slots model) {
                _slots.Slots.Attach(model);
                _slots.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _slots.SaveChanges();

                return Ok(new {Message = "Updated"});
            }
        }
    }
}
