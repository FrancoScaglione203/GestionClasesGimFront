using GestionClasesGimFront.Data.DTOs;

namespace GestionClasesGimFront.ViewModels
{
    public class AlumnosViewModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public int RoleId { get; set; }
        public string Clave { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public bool Activo { get; set; }

        public static implicit operator AlumnosViewModel(AlumnoDto alumno)
        {
            var alumnosViewModel = new AlumnosViewModel();
            alumnosViewModel.Nombre = alumno.Nombre;
            alumnosViewModel.Apellido = alumno.Apellido;
            alumnosViewModel.Dni = alumno.Dni;
            alumnosViewModel.Clave = alumno.Clave;
            alumnosViewModel.RoleId = alumno.RoleId;
            alumnosViewModel.FechaInscripcion = alumno.FechaInscripcion;
            alumnosViewModel.Activo = alumno.Activo;

            return alumnosViewModel;
        }
    }
}
