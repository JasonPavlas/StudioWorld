using Microsoft.AspNetCore.Mvc;
using StudioWorld.API.Models;

namespace StudioWorld.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private static readonly List<Booking> _bookings = new();
    private static int _nextId = 1;

    [HttpGet]
    public IEnumerable<Booking> Get()
    {
        return _bookings;
    }

    [HttpGet("{id}")]
    public ActionResult<Booking> Get(int id)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == id);
        if (booking == null)
        {
            return NotFound();
        }
        return booking;
    }

    [HttpPost]
    public ActionResult<Booking> Post(Booking booking)
    {
        booking.Id = _nextId++;
        booking.Status = BookingStatus.Pending;
        _bookings.Add(booking);
        
        return CreatedAtAction(nameof(Get), new { id = booking.Id }, booking);
    }

    [HttpPut("{id}/status")]
    public IActionResult UpdateStatus(int id, [FromBody] BookingStatus status)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == id);
        if (booking == null)
        {
            return NotFound();
        }

        booking.Status = status;
        return NoContent();
    }
}
