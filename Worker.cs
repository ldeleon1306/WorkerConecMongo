using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerConecMongo
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var client = new MongoClient("mongodb://10.20.2.46:27017");
                Console.WriteLine("conecto a mongo 21");
                Console.WriteLine("entra a mongo 22");
                List<string> NombrebaseDatos = client.ListDatabaseNames().ToList();
                Console.WriteLine("entra a mongo 23");
                var database = client.GetDatabase("APIAlmacenes");
                Console.WriteLine(database);
                Console.WriteLine("entrando al mail");
                try
                {
                    MailMessage mail = new MailMessage();
                    //Console.WriteLine(_mailFrom.ToString());
                    //Console.WriteLine(_mailTo);
                    mail.From = new MailAddress("appdesabrdcsrv@andreani.com");
                    mail.To.Add("ldeleon@andreani.com");
                    //var multiple = _mailTo.Split(';');
                    //foreach (var to in multiple)
                    //{
                    //    if (to != string.Empty)
                    //        mail.To.Add(to);
                    //}              
                    System.Net.Mail.Attachment attachment;
                    //attachment = new System.Net.Mail.Attachment("output.txt");
                    //mail.Attachments.Add(attachment);
                    //if (!String.IsNullOrEmpty(txterror))
                    //{
                    //  attachment = new System.Net.Mail.Attachment(txterror);
                    //  mail.Attachments.Add(attachment);
                    //}
                    string cliente = "prueba";
                    string subject = string.Format($"Prueba {cliente} Mail");
                    string bodyMsg = string.Format($"Se procesó un mongo {cliente}");
                    mail.Subject = subject;
                    mail.Body = bodyMsg;
                    mail.IsBodyHtml = true;
                    Console.WriteLine(bodyMsg);
                    SmtpClient smtp = new SmtpClient("10.20.2.41");
                    smtp.EnableSsl = false;
                    smtp.Port = 25;
                    smtp.UseDefaultCredentials = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("dentro de casa mail");
                    //Console.WriteLine(_mailFrom);
                    //Console.WriteLine(_mailTo);
                    Console.WriteLine(ex.Message);
                    //_logger.LogError(ex, "Se produjo una excepción en el metodo SendEmail: ", ex.Message);
                    throw ex;
                }
               

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
