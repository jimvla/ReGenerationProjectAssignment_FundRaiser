using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReGenerationProjectAssignment_FundRaiser.DbContexts;
using ReGenerationProjectAssignment_FundRaiser.Models;

namespace ReGenerationProjectAssignment_FundRaiser.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly CrmDbContext _context;

        public APIController(CrmDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [Route("Categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
          if (_context.Category == null)
          {
              return NotFound();
          }
            return await _context.Category.ToListAsync();
        }

        // GET: api/Categories/5
        [Route("Category")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
          if (_context.Category == null)
          {
              return NotFound();
          }
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // GET: api/FundingPackages
        [Route("FundingPackages")]
        public async Task<ActionResult<IEnumerable<Funding_Package>>> GetFundingPackage()
        {
            if (_context.Category == null)
            {
                return NotFound();
            }
            return await _context.Funding_Packages.ToListAsync();
        }

        // GET: api/FundingPackages/5
        [Route("FundingPackage")]
        public async Task<ActionResult<Funding_Package>> GetFundingPackage(int id)
        {
            if (_context.Funding_Packages == null)
            {
                return NotFound();
            }
            var package = await _context.Funding_Packages.FindAsync(id);

            if (package == null)
            {
                return NotFound();
            }

            return package;
        }

        // GET: api/Project
        [Route("Projects")]
        public async Task<ActionResult<IEnumerable<Project>>> Project()
        {
            if (_context.Projects == null)
            {
                return NotFound();
            }
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Project/5
        [Route("Project")]
        public async Task<ActionResult<Project>> Project(int id)
        {
            if (_context.Projects == null)
            {
                return NotFound();
            }
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // GET: api/ProjectTrackers
        [Route("ProjectTrackers")]
        public async Task<ActionResult<IEnumerable<Project_Tracker>>> ProjectTracker()
        {
            if (_context.Project_Tracker == null)
            {
                return NotFound();
            }
            return await _context.Project_Tracker.ToListAsync();
        }

        // GET: api/ProjectTracker/5
        [Route("ProjectTracker")]
        public async Task<ActionResult<Project_Tracker>> ProjectTracker(int id)
        {
            if (_context.Project_Tracker == null)
            {
                return NotFound();
            }
            var project_Tracker = await _context.Project_Tracker.FindAsync(id);

            if (project_Tracker == null)
            {
                return NotFound();
            }

            return project_Tracker;
        }

        // GET: api/StatusUpdates
        [Route("StatusUpdates")]
        public async Task<ActionResult<IEnumerable<Status_Update>>> StatusUpdate()
        {
            if (_context.Status_Updates == null)
            {
                return NotFound();
            }
            return await _context.Status_Updates.ToListAsync();
        }

        // GET: api/StatusUpdate/5
        [Route("StatusUpdate")]
        public async Task<ActionResult<Status_Update>> StatusUpdate(int id)
        {
            if (_context.Status_Updates == null)
            {
                return NotFound();
            }
            var Status_Update = await _context.Status_Updates.FindAsync(id);

            if (Status_Update == null)
            {
                return NotFound();
            }

            return Status_Update;
        }
        // GET: api/Users
        [Route("Users")]
        public async Task<ActionResult<IEnumerable<User>>> Users()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [Route("User")]
        public async Task<ActionResult<User>> Users(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var User = await _context.Users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }
    }
}
