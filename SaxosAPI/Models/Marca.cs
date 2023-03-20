using System;
using System.Collections.Generic;

namespace SaxosAsp.Models;

public partial class Marca
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Saxo> Saxos { get; } = new List<Saxo>();
}
