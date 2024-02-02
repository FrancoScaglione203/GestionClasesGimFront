namespace GestionClasesGimFront.Data.DTOs
{
    public class UsuarioDto
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Clave { get; set; }
        public int RoleId { get; set; }
        public bool Activo { get; set; }
    }
}
