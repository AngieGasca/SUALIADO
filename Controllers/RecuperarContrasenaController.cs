using Sualiado.Models;
using Sualiado.Models.Request;
using Sualiado.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Sualiado.Controllers
{
    public class RecuperarContrasenaController : Controller
    {


        private SualiadoEntities db = new SualiadoEntities();



        // GET: RecuperarContrasena
        public ActionResult Index()
        {
            RecuperarContraModel model = new RecuperarContraModel();
            model.Correo = "";

            return View(model);
        }



        [AllowAnonymous]
        [HttpPost]
        public ActionResult Recuperar(RecuperarContraModel model)
        {
            string mensaje = "";


            try
            {
                string bdMs = "Ingrese el link para cambiar la contraseña https://localhost:44370/RecuperarContrasena/NuevaContrasena?correo=" + model.Correo.ToString() + "";
                var fromAddress = new MailAddress("sualiado2@gmail.com", "sualiado2@gmail.com");
                var toAddress = new MailAddress(model.Correo, model.Correo);
                const string fromPassword = "SUALIADO";
                const string subject = "Recuperar contraseña";
                string body = bdMs.ToString();

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                mensaje = "Se envio con exito el correo";

            }
            catch (Exception ex)
            {

                mensaje = ex.Message.ToString();
            }


            model.Mensaje = mensaje;

            return View("Index",model);
        }



        // GET: RecuperarContrasena
        public ActionResult NuevaContrasena(string correo)
        {
            RecuperarContraModel model = new RecuperarContraModel();
            model.Correo = correo;

            return View(model);
        }


        [AllowAnonymous]
        [HttpPost]
        // GET: RecuperarContrasena
        public ActionResult ActualizarContrasena(RecuperarContraModel model)
        {
            string mensaje = "";
            try

            {
                using (db)
                {

                   
                    db.EditarContrasena(model.Correo, Encrypt.GetSHA256(model.Contrasena) );
                    db.SaveChanges();

                    mensaje = "Se actualizo con exito la contraseña";

                }
            }

            catch (Exception ex)

            {

                mensaje = ex.Message.ToString();

            }

            model.Mensaje = mensaje;
            return View("NuevaContrasena",model);
        }


    }
}