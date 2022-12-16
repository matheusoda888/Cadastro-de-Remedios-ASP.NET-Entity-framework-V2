using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FFF.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Horario> Horarios { get; } = new List<Horario>();
}
