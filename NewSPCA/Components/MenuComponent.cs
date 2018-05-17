using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewSPCA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewSPCA.Components
{
    public class MenuComponent : ViewComponent
    {
        private readonly AnimalContext _context;

        public MenuComponent(AnimalContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Species.OrderBy(g => g.Species_Name).ToListAsync());
        }
    }
}
