using GestionClasesGimFront.Data.DTOs;

namespace GestionClasesGimFront.ViewModels
{
    public class ClasesViewModel
    {
        public string Nombre { get; set; }
        public DateTime FechaHorario { get; set; }
        public int CapacidadMax { get; set; }
        public int Cupos { get; set; }
        public string imagenUrl { get; set; }
        public bool Activo { get; set; }

        public static implicit operator ClasesViewModel(ClaseDto alumno)
        {
            var clasesViewModel = new ClasesViewModel();
            clasesViewModel.Nombre = alumno.Nombre;
            clasesViewModel.Cupos = alumno.Cupos;
            clasesViewModel.CapacidadMax = alumno.CapacidadMax;
            clasesViewModel.FechaHorario = alumno.FechaHorario;
            clasesViewModel.imagenUrl = alumno.imagenUrl;
            clasesViewModel.Activo = alumno.Activo;

            return clasesViewModel;
        }
    }
}
