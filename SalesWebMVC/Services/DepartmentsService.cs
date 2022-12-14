using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class DepartmentsService
    {
        private readonly SalesWebMVCContext _context;

        public DepartmentsService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Departments>> FindAll()
        {
            return await _context.Departments.OrderBy(x => x.Name).ToListAsync();
        }

    }
}
