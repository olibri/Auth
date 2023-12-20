using Microsoft.AspNetCore.Mvc;
using Sprint16.Data;
using Microsoft.EntityFrameworkCore;
using Sprint16.Models;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;

namespace Sprint16.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingContext _context;
        public OrderController(ShoppingContext context)
        {
            _context = context;
        }
        [Authorize(Roles ="admin, buyer")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Edit(int id)
        {

            return View();
        }
    }
}
