using System;
using System.Collections.Generic;

namespace Guia2_Unidad3_AlfredoAlas.Models
{
    public partial class Estudiante
    {
        public int IdEstudiante { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public DateTime? FechaInscripción { get; set; }
        public int? Edad { get; set; }
    }
}
