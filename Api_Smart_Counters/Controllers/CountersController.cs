﻿using System;
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
    public class CountersController : ControllerBase
    {
        private readonly Smart_CountersContext _context;

        public CountersController(Smart_CountersContext context)
        {
            _context = context;
        }

        // GET: api/Counters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Counter>>> GetCounters()
        {
          if (_context.Counters == null)
          {
              return NotFound();
          }
            return await _context.Counters.ToListAsync();
        }

        // GET: api/Counters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Counter>> GetCounter(int? id)
        {
          if (_context.Counters == null)
          {
              return NotFound();
          }
            var counter = await _context.Counters.FindAsync(id);

            if (counter == null)
            {
                return NotFound();
            }

            return counter;
        }

        // PUT: api/Counters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCounter(int? id, Counter counter)
        {
            if (id != counter.IdCounters)
            {
                return BadRequest();
            }

            _context.Entry(counter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CounterExists(id))
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

        // POST: api/Counters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Counter>> PostCounter(Counter counter)
        {
          if (_context.Counters == null)
          {
              return Problem("Entity set 'Smart_CountersContext.Counters'  is null.");
          }
            _context.Counters.Add(counter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCounter", new { id = counter.IdCounters }, counter);
        }

        // DELETE: api/Counters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCounter(int? id)
        {
            if (_context.Counters == null)
            {
                return NotFound();
            }
            var counter = await _context.Counters.FindAsync(id);
            if (counter == null)
            {
                return NotFound();
            }

            _context.Counters.Remove(counter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CounterExists(int? id)
        {
            return (_context.Counters?.Any(e => e.IdCounters == id)).GetValueOrDefault();
        }
    }
}
