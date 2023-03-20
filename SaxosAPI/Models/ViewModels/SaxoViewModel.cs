using System.ComponentModel.DataAnnotations;

namespace SaxosAsp.Models.ViewModels {
	public class SaxoViewModel {

		//para formulario:

		[Required]
		[Display(Name = "Tipo de Saxo")] //para definir el DisplayFor del html
		public string Tipo { get; set; }

		[Required]
		[Display(Name = "Marca del Saxo")]
		public int MarcaId { get; set; }
	}
}
