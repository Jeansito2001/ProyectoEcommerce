using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;
using System.Net;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace BL
{
    public class CN_Recursos
    {
        public static string GenerarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0,6);
            return clave;
        }


        //ENCRIPTACION de texto en SHA256

        public static string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();
            
            using(SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach(byte b in result )
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }


        public static bool EnviarCorreo(string correo, string asunto, string mensaje)
        {
            bool resultado = false;

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("testeo.ecommerce002@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient() //servidor cliente se encarga de la operaciond e enviar el correo
                {
                    Credentials = new NetworkCredential("testeo.ecommerce002@gmail.com", "eqzu sxiy zzhz flut"),  //correo y contraseña 
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true
                };

                smtp.Send(mail);
                resultado = true;

            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;
        }

        public static string ConvertirBase64(string ruta, out bool conversion)
        {
            string textoBse64 = string.Empty;
            conversion = true;

            try
            {
                byte[] bytes = File.ReadAllBytes(ruta);
                textoBse64 = Convert.ToBase64String(bytes);

            } catch (Exception ex) {
                conversion = false;
            }
            return textoBse64;
        }

    }
}
