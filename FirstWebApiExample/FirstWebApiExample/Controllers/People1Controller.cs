﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstWebApiExample.Data;
using FirstWebApiExample.Models;

namespace FirstWebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class People1Controller : ControllerBase
    {
        private readonly FirstWebApiExampleContext _context;

        public People1Controller(FirstWebApiExampleContext context)
        {
            _context = context;
        }

        // GET: api/People1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
          if (_context.Person == null)
          {
              return NotFound();
          }
            return await _context.Person.ToListAsync();
        }

        // GET: api/People1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
          if (_context.Person == null)
          {
              return NotFound();
          }
            var person = await _context.Person.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/People1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
          if (_context.Person == null)
          {
              return Problem("Entity set 'FirstWebApiExampleContext.Person'  is null.");
          }
            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            if (_context.Person == null)
            {
                return NotFound();
            }
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return (_context.Person?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
