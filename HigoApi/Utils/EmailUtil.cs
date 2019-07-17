using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using HigoApi.Models;

namespace HigoApi.Utils
{
    public static class EmailUtil
    {
        private static void Enviar(MailMessage mailMessage)
        {
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("higo.hireandgo@gmail.com", "hire&Go1")
            };
            try
            {
                smtp.Send(mailMessage);
            }
            catch(SmtpException ex)
            {
                ex.Message.ToString();
            }
            catch(Exception x)
            {
                x.Message.ToString();
            }
        }

        private static MailMessage Nuevo(MailAddress toAddress)
        {
            return new MailMessage(fromAddress, toAddress)
            {
                IsBodyHtml = true
            };
        }

        private static readonly MailAddress fromAddress = new MailAddress("no-reply@gmail.com", "higo");

        private static readonly string HIGO_HEADER = "<h1 style='background-color:#7a3994;'><span style='color:#dadada;'>hi</span><span style='color:white;'>go</span></h1>";

        public static void EmailNuevaSolicitud(Operacion operacion)
        {
            MailAddress toAddress = new MailAddress(operacion.IdVehiculoNavigation.IdPrestadorNavigation.Email);
            MailMessage mailMessage = Nuevo(toAddress);

            string mailBody = HIGO_HEADER;
            mailBody += "<h2>Nueva solicitud de alquiler</h2>";
            mailBody += "<p>";
            mailBody += "El usuario ";
            mailBody += operacion.IdAdquirenteNavigation.Nombre + " " + operacion.IdAdquirenteNavigation.Apellido;
            mailBody += " ha solicitado tu vehículo ";
            mailBody += operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion + " " + operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.Descripcion;
            mailBody += " desde el " + operacion.FechaHoraDesde.GetValueOrDefault().ToShortDateString() + " a las " + operacion.FechaHoraDesde.GetValueOrDefault().ToShortTimeString();
            mailBody += " hasta el " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortDateString() + " a las " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortTimeString();
            mailBody += "</p>";
            mailBody += "<p>";
            mailBody += "Para aprobar o rechazar la solicitud, haga click ";
            mailBody += "<a href='#'>aquí</a>";
            mailBody += "</p>";

            mailMessage.Subject = "Nueva solicitud de alquiler";
            mailMessage.Body = mailBody;


            Enviar(mailMessage);
        }


        public static void EmailRechazarSolicitud(Operacion operacion)
        {
            MailAddress toAddress = new MailAddress(operacion.IdAdquirenteNavigation.Email);
            MailMessage mailMessage = Nuevo(toAddress);

            string mailBody = HIGO_HEADER;
            mailBody += "<h2>Alquiler rechazado</h2>";
            mailBody += "<p>";
            mailBody += "El usuario ";
            mailBody += operacion.IdVehiculoNavigation.IdPrestadorNavigation.Nombre + " " + operacion.IdVehiculoNavigation.IdPrestadorNavigation.Apellido;
            mailBody += " ha rechazado tu solicitud para el vehículo ";
            mailBody += operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion + " " + operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.Descripcion;
            mailBody += " desde el " + operacion.FechaHoraDesde.GetValueOrDefault().ToShortDateString() + " a las " + operacion.FechaHoraDesde.GetValueOrDefault().ToShortTimeString();
            mailBody += " hasta el " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortDateString() + " a las " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortTimeString();
            mailBody += "</p>";
            mailBody += "<p>";
            mailBody += "Para ver el estado de la solicitud, haga click ";
            mailBody += "<a href='#'>aquí</a>";
            mailBody += "</p>";

            mailMessage.Subject = "Alquiler rechazado";
            mailMessage.Body = mailBody;


            Enviar(mailMessage);

        }

        public static void EmailAprobarSolicitud(Operacion operacion)
        {
            MailAddress toAddress = new MailAddress(operacion.IdAdquirenteNavigation.Email);
            MailMessage mailMessage = Nuevo(toAddress);

            string mailBody = HIGO_HEADER;
            mailBody += "<h2>Alquiler rechazado</h2>";
            mailBody += "<p>";
            mailBody += "El usuario ";
            mailBody += operacion.IdVehiculoNavigation.IdPrestadorNavigation.Nombre + " " + operacion.IdVehiculoNavigation.IdPrestadorNavigation.Apellido;
            mailBody += " ha aprobado tu solicitud para el vehículo ";
            mailBody += operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion + " " + operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.Descripcion;
            mailBody += " desde el " + operacion.FechaHoraDesde.GetValueOrDefault().ToShortDateString() + " a las " + operacion.FechaHoraDesde.GetValueOrDefault().ToShortTimeString();
            mailBody += " hasta el " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortDateString() + " a las " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortTimeString();
            mailBody += "</p>";
            mailBody += "<p>";
            mailBody += "Para ver el estado de la solicitud, haga click ";
            mailBody += "<a href='#'>aquí</a>";
            mailBody += "</p>";

            mailMessage.Subject = "Alquiler rechazado";
            mailMessage.Body = mailBody;


            Enviar(mailMessage);
        }

        public static void EmailCancelarSolicitud(Operacion operacion)
        {
            MailAddress toAddress = new MailAddress(operacion.IdVehiculoNavigation.IdPrestadorNavigation.Email);
            MailMessage mailMessage = Nuevo(toAddress);

            string mailBody = HIGO_HEADER;
            mailBody += "<h2>Solicitud de alquiler cancelada</h2>";
            mailBody += "<p>";
            mailBody += "El usuario ";
            mailBody += operacion.IdAdquirenteNavigation.Nombre + " " + operacion.IdAdquirenteNavigation.Apellido;
            mailBody += " ha cancelado la solicitud de tu vehículo ";
            mailBody += operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion + " " + operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.Descripcion;
            mailBody += " desde el " + operacion.FechaHoraDesde.GetValueOrDefault().ToShortDateString() + " a las " + operacion.FechaHoraDesde.GetValueOrDefault().ToShortTimeString();
            mailBody += " hasta el " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortDateString() + " a las " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortTimeString();
            mailBody += "</p>";
            mailBody += "<p>";
            mailBody += "Para el estado de la solicitud, haga click ";
            mailBody += "<a href='#'>aquí</a>";
            mailBody += "</p>";

            mailMessage.Subject = "Solicitud de alquiler cancelada!";
            mailMessage.Body = mailBody;

            Enviar(mailMessage);
        }

        public static void EmailComenzarSolicitud(Operacion operacion, int idUsuario)
        {
            MailAddress toAddress;

            if (idUsuario == operacion.IdAdquirente)
            {
                toAddress = new MailAddress(operacion.IdAdquirenteNavigation.Email);
            }
            else
            {
                toAddress = new MailAddress(operacion.IdVehiculoNavigation.IdPrestadorNavigation.Email);
            }

            MailMessage mailMessage = Nuevo(toAddress);

            string mailBody = HIGO_HEADER;
            mailBody += "<h2>El alquiler de tu vehículo a comenzado!</h2>";
            mailBody += "<p>";
            mailBody += "El usuario ";
            mailBody += operacion.IdAdquirenteNavigation.Nombre + " " + operacion.IdAdquirenteNavigation.Apellido;
            mailBody += " ha comenzado el uso de tu vehículo ";
            mailBody += operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion + " " + operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.Descripcion;
            mailBody += "</p>";
            mailBody += "<p>";
            mailBody += "Será utilizado hasta el " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortDateString() + " a las " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortTimeString();
            mailBody += "</p>";
            mailBody += "<p>";
            mailBody += "Para ver el estado de la solicitud, haga click ";
            mailBody += "<a href='#'>aquí</a>";
            mailBody += "</p>";

            mailMessage.Subject = "El alquiler a comenzado";
            mailMessage.Body = mailBody;

            Enviar(mailMessage);
        }
        public static void EmailFinalizarSolicitud(Operacion operacion, int idUsuario)
        {
            MailAddress toAddress;

            if (idUsuario == operacion.IdAdquirente)
            {
                toAddress = new MailAddress(operacion.IdAdquirenteNavigation.Email);
            }
            else
            {
                toAddress = new MailAddress(operacion.IdVehiculoNavigation.IdPrestadorNavigation.Email);
            }

            MailMessage mailMessage = Nuevo(toAddress);

            string mailBody = HIGO_HEADER;
            mailBody += "<h2>El alquiler de tu vehículo a finalizado!</h2>";
            mailBody += "<p>";
            mailBody += "El usuario ";
            mailBody += operacion.IdAdquirenteNavigation.Nombre + " " + operacion.IdAdquirenteNavigation.Apellido;
            mailBody += " ha finalizado el uso de tu vehículo ";
            mailBody += operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion + " " + operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.Descripcion;
            mailBody += "</p>";
            mailBody += "<p>";
            mailBody += "Para ver el estado de la solicitud, haga click ";
            mailBody += "<a href='#'>aquí</a>";
            mailBody += "</p>";

            mailMessage.Subject = "El alquiler a finalizado";
            mailMessage.Body = mailBody;

            Enviar(mailMessage);
        }
    }
}
