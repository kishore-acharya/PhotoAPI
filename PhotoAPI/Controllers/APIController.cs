using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhotoAPI.Models;
namespace PhotoAPI.Controllers
{
    public class APIController : Controller
    {
        private readonly UserContext _context;
        public Result GeneratedResult = new Result();

        public APIController(UserContext context)
        {
            _context = context;
        }

        // GET: /api/
        public async Task<IActionResult> Index()
        {
            return Json(await _context.User.ToListAsync());
        }

        // GET: /api/details/?UserId=SomeUserId
        public async Task<IActionResult> Details(string UserId)
        {
            if (UserId == null)
            {
                return NotFound();
            }

            var user =  await _context.User.SingleOrDefaultAsync (m => m.UserId== UserId);//experimental

            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        // GET: API/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: API/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProfileImagePath,UserId")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();

                GeneratedResult.StatusCodeOk = true;
                return Json(GeneratedResult);

            }
            
            
            return Json(GeneratedResult.StatusCodeOk=false);

        }

       


        // GET: API/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return Json(GeneratedResult.StatusCodeOk=false);
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                 return Json(GeneratedResult.StatusCodeOk = false);
            }
             user = await _context.User.FindAsync(id);
            _context.User.Remove(user);//db call to delete
            await _context.SaveChangesAsync();
            if(_context.User.Contains(user))
            {
                return Json(GeneratedResult.StatusCodeOk = false);
            }
            else
            {
                return Json(GeneratedResult.StatusCodeOk = true);
            }
        }

       

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
