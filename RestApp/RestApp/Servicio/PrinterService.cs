using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.Servicio
{
    public class PrinterService
    {
        public static string ImpresoraBebidas { get; set; }
        public static string ImpresoraComidas { get; set; }

        public async Task SendText(string printerIp, string text)
        {
            using (var client = new TcpClient())
            {
                await client.ConnectAsync(printerIp, 9100);
                var buffer = Encoding.UTF8.GetBytes(text);
                using (var stream = client.GetStream())
                {
                    await stream.WriteAsync(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
