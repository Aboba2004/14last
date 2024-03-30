using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Smart_Counters.Models;

namespace Api_Smart_Counters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeakSensorsController : ControllerBase
    {
        private readonly Smart_CountersContext _context;

        public LeakSensorsController(Smart_CountersContext context)
        {
            _context = context;
        }

        // GET: api/LeakSensors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeakSensor>>> GetLeakSensors()
        {
          if (_context.LeakSensors == null)
          {
              return NotFound();
          }
            return await _context.LeakSensors.ToListAsync();
        }

        // GET: api/LeakSensors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeakSensor>> GetLeakSensor(int? id)
        {
          if (_context.LeakSensors == null)
          {
              return NotFound();
          }
            var leakSensor = await _context.LeakSensors.FindAsync(id);

            if (leakSensor == null)
            {
                return NotFound();
            }

            return leakSensor;
        }

        // PUT: api/LeakSensors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeakSensor(int? id, LeakSensor leakSensor)
        {
            if (id != leakSensor.IdLeakSensors)
            {
                return BadRequest();
            }

            _context.Entry(leakSensor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeakSensorExists(id))
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

        // POST: api/LeakSensors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LeakSensor>> PostLeakSensor(LeakSensor leakSensor)
        {
          if (_context.LeakSensors == null)
          {
              return Problem("Entity set 'Smart_CountersContext.LeakSensors'  is null.");
          }
            _context.LeakSensors.Add(leakSensor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeakSensor", new { id = leakSensor.IdLeakSensors }, leakSensor);
        }

        // DELETE: api/LeakSensors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeakSensor(int? id)
        {
            if (_context.LeakSensors == null)
            {
                return NotFound();
            }
            var leakSensor = await _context.LeakSensors.FindAsync(id);
            if (leakSensor == null)
            {
                return NotFound();
            }

            _context.LeakSensors.Remove(leakSensor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeakSensorExists(int? id)
        {
            return (_context.LeakSensors?.Any(e => e.IdLeakSensors == id)).GetValueOrDefault();
        }
    }
}
