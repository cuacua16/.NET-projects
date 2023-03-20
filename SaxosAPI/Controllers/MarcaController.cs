using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaxosAsp.Models;
using System;

namespace SaxosAsp.Controllers {
    public class MarcaController : Controller {

        private readonly AsphdContext _context;

        //el contexto si no es inyectado en program no podemos obtenerlo en el constructor
        public MarcaController(AsphdContext context)
         => _context = context;
        //se puede usar el arrow acá tambien


        public async Task<IActionResult> Index() {
            //con el await no recibe el Task sino el tipo, sino recibiria el task
            return View(await _context.Marcas.ToListAsync());

        }
    }
}
