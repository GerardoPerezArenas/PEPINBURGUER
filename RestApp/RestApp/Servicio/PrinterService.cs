using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.Servicio
{
    public class PrinterService
    {
        public static string ImpresoraBebidas { get; set; }
        public static string ImpresoraComidas { get; set; }

        public async Task<bool> SendText(string printerIp, string text)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    var connectTask = client.ConnectAsync(printerIp, 9100);
                    if (await Task.WhenAny(connectTask, Task.Delay(5000)) != connectTask)
                    {
                        return false;
                    }

                    var buffer = Encoding.UTF8.GetBytes(text);
                    using (var stream = client.GetStream())
                    {
                        var writeTask = stream.WriteAsync(buffer, 0, buffer.Length);
                        if (await Task.WhenAny(writeTask, Task.Delay(5000)) != writeTask)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
