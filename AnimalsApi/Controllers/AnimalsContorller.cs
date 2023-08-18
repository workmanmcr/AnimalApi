using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalsApi.Models;

namespace AnimalsApi.Controllers;


[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]

public class AnimalsController : ControllerBase
{
  private readonly AnimalsContext _db;

  public AnimalsController(AnimalsContext db)
  {
    _db = db;
  }

  [HttpGet]
  public ActionResult<IEnumerable<Animal>> Get(string name, string species, int age)
  {
    var query = _db.Animals.AsQueryable();

    if (name != null)
    {
      query = query.Where(entry => entry.Name == name);
    }
    if (species != null)
    {
      query = query.Where(entry => entry.Species == species);
    }
    if (age != 0)
    {
      query = query.Where(entry => entry.Age == age);
    }
  
    return query.ToList();
  }



    // route for posting new animals
    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(Get), new { id = animal.AnimalId }, animal);
    }
    
    //  route for editing Animals
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId)
      {
        return BadRequest();
      }

      _db.Animals.Update(animal);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
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

    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(a => a.AnimalId == id);
    }
    // add route to delete animals
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      Animal animal = await _db.Animals.FindAsync(id);

      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
  

