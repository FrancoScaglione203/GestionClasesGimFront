using GestionClasesGimFront.Data.DTOs;

namespace GestionClasesGimFront.ViewModels
{
    public class UsuariosViewModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public int RoleId { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }

        public static implicit operator UsuariosViewModel(UsuarioDto usuario)
        {
            var usuariosViewModel = new UsuariosViewModel();
            usuariosViewModel.Nombre = usuario.Nombre;
            usuariosViewModel.Apellido = usuario.Apellido;
            usuariosViewModel.Dni = usuario.Dni;
            usuariosViewModel.Clave = usuario.Clave;
            usuariosViewModel.RoleId = usuario.RoleId;
            return usuariosViewModel;
        }
    }
}

