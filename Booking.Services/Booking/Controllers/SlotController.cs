

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.Data;
using Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Data;


[Route("API/[controller]")]
[ApiController]
public class SlotController : ControllerBase
{
    private readonly AppDbContext _context;

    public SlotController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Slot>>> GetSlot()
    {
        return await _context.Slots.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Slot>> GetSlotById(int id)
    {
        var article = await _context.Slots.FindAsync(id);

        if (article == null)
        {
            return NotFound();
        }

        return article;
    }

    [HttpPost]
    public async Task<ActionResult<Slot>> PostSlot(Slot article)
    {
        article.isBooked = false;
        _context.Slots.Add(article);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSlot", new { id = article.Id }, article);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutSlot(int id, Slot article)
    {
        if (id != article.Id)
        {
            return BadRequest();
        }

        _context.Entry(article).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SlotExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSlot(int id)
    {
        var article = await _context.Slots.FindAsync(id);

        if (article == null)
        {
            return NotFound();
        }

        _context.Slots.Remove(article);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SlotExists(int id)
    {
        return _context.Slots.Any(e => e.Id == id);
    }
}