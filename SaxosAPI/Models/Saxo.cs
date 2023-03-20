using System;
using System.Collections.Generic;

namespace SaxosAsp.Models;

public partial class Saxo
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public int MarcaId { get; set; }

    public virtual Marca Marca { get; set; } = null!;
}
