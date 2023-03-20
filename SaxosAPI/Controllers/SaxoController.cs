using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaxosAsp.Models;
using SaxosAsp.Models.ViewModels;

namespace SaxosAsp.Controllers {
	public class SaxoController : Controller {

		private readonly AsphdContext _context;

		public SaxoController(AsphdContext context) {
			_context = context;
		}

		//click derecho al Index de abajo para agregar vista
		public async Task<IActionResult> Index() {
			var saxos = _context.Saxos.Include((m) => m.Marca);

			return View(await saxos.ToListAsync());
		}

		public IActionResult Create() {
			//select mandando Id y recibiendo Nombre:
			ViewData["Marcas"] = new SelectList(_context.Marcas, "Id", "Nombre");
			return View();
		}


		//Metodo para post
		[HttpPost]
		[ValidateAntiForgeryToken] //solo recibe la info del propio dominio (form)
		public async Task<IActionResult> Create(SaxoViewModel model) {

			//Guardado de Informacion
			if(ModelState.IsValid) {
				//crear saxo del tipo de Entity framework q hace referencia a la tabla de EF
				var saxo = new Saxo() {
					Tipo = model.Tipo,
					MarcaId = model.MarcaId,
				};
				//Indicar a EF
				_context.Add(saxo);
				//MANDAR A DB LA INFORMACION:
				await _context.SaveChangesAsync();

				//Redireccion a Listado de saxos
				return RedirectToAction(nameof(Index));
			}

			//select mandando Id y recibiendo Nombre:
			ViewData["Marcas"] = new SelectList(_context.Marcas, "Id", "Nombre", model.MarcaId); //new SelectList(fuenteDeInformacion, valorEntrada, valorSalida, seleccionado)
			return View(model);
		}
	}
}
