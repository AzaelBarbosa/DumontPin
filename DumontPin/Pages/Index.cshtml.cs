using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace DumontPin.Pages
{
    public class IndexModel : PageModel
    {
        public string claveSecreta = "Dumont";
        public List<string> Usuarios { get; set; } = new() { "Norita", "Nora", "Administrador" };
        public string UsuarioSeleccionado { get; set; }
        public string PinGenerado { get; set; }
        private readonly ILogger<IndexModel> _logger;
        public void OnPost(string usuario)
        {
            UsuarioSeleccionado = usuario;
            PinGenerado = GenerarPin(usuario);
        }

        private string GenerarPin(string usuario)
        {
            const string claveSecreta = "Dumont"; // puedes mover esto a configuración
            string fecha = DateTime.UtcNow.ToString("yyyyMMddHHmm"); // cambia el PIN cada minuto

            string baseString = claveSecreta + usuario + fecha;

            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(baseString));
                int hash = BitConverter.ToInt32(hashBytes, 0);
                hash = Math.Abs(hash);

                return (hash % 10000).ToString("D4"); // PIN de 4 dígitos
            }
        }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
