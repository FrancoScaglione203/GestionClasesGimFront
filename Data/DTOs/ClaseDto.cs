namespace GestionClasesGimFront.Data.DTOs
{
    public class ClaseDto
    {
        public string Nombre { get; set; }
        public DateTime FechaHorario { get; set; }
        public int CapacidadMax { get; set; }
        public int Cupos { get; set; }
        public string imagenUrl { get; set; }
        public bool Activo { get; set; }
    }
}
