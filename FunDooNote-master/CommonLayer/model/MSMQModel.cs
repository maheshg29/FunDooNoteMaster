using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonLayer.model
{
    public class MSMQModel
    {
        MessageQueue MessageQ = new MessageQueue();

        public void SendData(string token)
        {
            MessageQ.Path = @".\private$\tokens";
            if (!MessageQueue.Exists(MessageQ.Path))
            {
                MessageQueue.Create(MessageQ.Path);
            }
            MessageQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            MessageQ.ReceiveCompleted += ReceiveHandler;
            MessageQ.Send(token);
            MessageQ.BeginReceive();
            MessageQ.Close();
        }

        private void ReceiveHandler(object sender, ReceiveCompletedEventArgs e)
        {
            var msg = MessageQ.EndReceive(e.AsyncResult);
            string token = msg.Body.ToString();
            string subject = "Fundoo Notes Reset Link";
            string body = token;
            var SMTP = new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,//
                Credentials = new NetworkCredential("mmgangurde29@gmail.com", "zfcreaahxpryfzze"),
                EnableSsl = true
            };
            SMTP.Send("mmgangurde29@gmail.com", "mmgangurde29@gmail.com", subject, body);
 
        }
    }
}
