using GestionClasesGimFront.ViewModels;

namespace GestionClasesGimFront.Data.DTOs
{
    public class AlumnoDto
    {


        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public int RoleId { get; set; }
        public string Clave { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string imagenUrl { get; set; }
        public bool Activo { get; set; }     
    }
}
