using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FFF.Models;

public partial class Horario
{
    public int Id { get; set; }


    public int IdRemedio { get; set; }

    public int IdPaciente { get; set; }
    [Display(Name = "Tempo")]
    public int Tempo { get; set; }
    [Display(Name = "Horário")]
    public TimeSpan Horario1 { get; set; }
    [Display(Name = "Nome do paciente")]
    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
    [Display(Name = "Nome do remédio")]
    public virtual Remedio IdRemedioNavigation { get; set; } = null!;
}
