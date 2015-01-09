using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace problema_bal
{
    public class mail_bal
    {
        public bool envioMailNotificacion(String num, String estado, String usr_mail) 
        {
            String para = usr_mail + "@dts.cl";
            String cuerpo = "Estimado: <br>" +
                            "Se le ha enviado este mail ya que ha ingresado una nueva mejora al sistema con numero "+ num +". Se ha generado un nuevo seguimiento en estado "+ estado +" para la mejora ingresada. <br>" +
                            "Favor no responder a este mail. <br>" +
                            "Gracias.";


            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(para);
            msg.From = new MailAddress("adminmantocal@dts.cl", "Admin Manto - Cal", System.Text.Encoding.UTF8);
            msg.Subject = "Ingreso Nuevo Problema";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "post2";
            client.EnableSsl = false;

            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }

        public bool emailNuevoSeguimiento(String usrForMail, String num, String estado, String fcompromiso)
        {
            String para = usrForMail + "@dts.cl";
            String cuerpo = "Estimado: <br>" +
                            "Se le ha enviado este mail ya que se ha ingresado un nuevo seguimiento al sistema para la mejora numero " + num + ", con el estado " + estado + ", con fecha de compromiso para "+ fcompromiso +". <br>" +
                            "Favor no responder a este mail. <br>" +
                            "Gracias.";


            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(para);
            msg.From = new MailAddress("adminmantocal@dts.cl", "Admin Manto - Cal", System.Text.Encoding.UTF8);
            msg.Subject = "Ingreso Nuevo Seguimiento";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "post2";
            client.EnableSsl = false;

            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }

        public bool emailResponsableSgto(String usrForMail, String num, String estado, String fcompromiso)
        {
            String para = usrForMail + "@dts.cl";
            String cuerpo = "Estimado: <br>" +
                            "Se le ha enviado este mail ya que usted ha sido asignado como responsable de un seguimiento para la mejora numero " + num + ", con el estado " + estado + ", con fecha de compromiso para " + fcompromiso + ". <br>" +
                            "Favor no responder a este mail. <br>" +
                            "Gracias.";


            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(para);
            msg.From = new MailAddress("adminmantocal@dts.cl", "Admin Manto - Cal", System.Text.Encoding.UTF8);
            msg.Subject = "Responsable Nuevo Seguimiento";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "post2";
            client.EnableSsl = false;

            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }

        public bool envioMailRenueva(String usr_name)
        {
            String para = usr_name + "@dts.cl";
            String cuerpo = "Estimado: <br>" +
                            "Se le ha enviado este mail ya que solicito renovacion de su contraseña. Su contraseña temporal es <h1>password</h1>, recuerde cambiarla por la que estime conveniente. <br>" +
                            "Favor no responder a este mail. <br>" +
                            "Gracias.";


            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(para);
            msg.From = new MailAddress("adminmantocal@dts.cl", "Admin Manto - Cal", System.Text.Encoding.UTF8);
            msg.Subject = "Renovación Contraseña";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "post2";
            client.EnableSsl = false;

            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }

        public bool envioMailCambia(String usr_name)
        {
            String para = usr_name + "@dts.cl";
            String cuerpo = "Estimado: <br>" +
                            "Se ha realizado exitosamente el cambio de su contraseña. <br>" +
                            "Favor no responder a este mail. <br>" +
                            "Gracias.";


            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(para);
            msg.From = new MailAddress("adminmantocal@dts.cl", "Admin Manto - Cal", System.Text.Encoding.UTF8);
            msg.Subject = "Cambio de Contraseña";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "post2";
            client.EnableSsl = false;

            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }
    }
}
