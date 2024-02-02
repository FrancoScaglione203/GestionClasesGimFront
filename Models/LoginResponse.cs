namespace GestionClasesGimFront.Models
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public long Dni { get; set; }
        public string Token { get; set; }
        public int roleId { get; set; }
    }
}
