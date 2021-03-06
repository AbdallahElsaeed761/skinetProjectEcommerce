using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Products:ControllerBase
    {
    public StoreContext? _context { get; }
    public Products(StoreContext context)
    {
      _context = context;
    }

    [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
           var products=await _context.products.ToListAsync();
           return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.products.FindAsync(id);
        }
    }
}