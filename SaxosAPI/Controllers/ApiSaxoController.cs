using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaxosAsp.Models;
using SaxosAsp.Models.ViewModels;

namespace SaxosAsp.Controllers {

	// path: /api/apisaxo

	[Route("api/[controller]")]
	[ApiController]
	public class ApiSaxoController : ControllerBase {
		//una clase que implementa ControllerBase retorna un JSON automaticamente

		private readonly AsphdContext _context;

		public ApiSaxoController(AsphdContext context) {
			_context = context;
		}

		public async Task<List<SaxoMarcaViewModel>> Get() => await _context.Saxos.Include(s => s.Marca).Select(s => new SaxoMarcaViewModel {
			Tipo = s.Tipo,
			Marca = s.Marca.Nombre
		}).ToListAsync();
	}
}
