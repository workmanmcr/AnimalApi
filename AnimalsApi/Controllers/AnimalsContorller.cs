using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalsApi.Models;

namespace AnimalsApi.Controllers;

[ApiController]
[Route("/api/[controller]")]

public class AnimalsController : ControllerBase
{
  private readonly AnimalsContext _db;

  public AnimalsController(AnimalsContext db)
  {
    _db = db;
  }
}