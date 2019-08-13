using DispatchingModule.Data;
using DispatchingModule.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Timers;

namespace DispatchingModule.Business
{
    public class DispatchingService
    {
        public void Start()
        {
            var runningtimer = new Timer();
            runningtimer.Interval = 60000;
            runningtimer.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
            runningtimer.Enabled = true;
            Console.WriteLine("Service has been started");
        }
        private void timer1_Tick(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Preparing to Send Notifications in 60 Seconds");
            Console.WriteLine(SendNotifications());
            EmailSend("teste@teste.com", SendNotifications());
        }

        public void Stop()
        {
            Console.WriteLine("Stopped");
        }

        public void EmailSend(string recipient, string body)
        {
            SmtpClient mailclient = new SmtpClient("smtpserver");
            mailclient.UseDefaultCredentials = false;
            mailclient.Credentials = new NetworkCredential("user", "pass");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("Itmonitoring.com");
            mailMessage.To.Add(recipient);
            mailMessage.Body = body;
            mailMessage.Subject = "Monitoring Framework";
            mailclient.Send(mailMessage);
        }


        private static string SendNotifications()
        {
           using (var db = new SqlContext())
            {
                int ComputersOnline = db.Capture.Where(i => DateTime.Now.Subtract(i.CaptureDate).Hours < 0).Select(m => m.ComputerName).Distinct().Count();
                int ComputersAlert = db.Capture.Where(i => DateTime.Now.Subtract(i.CaptureDate).Hours <= 0 * 1.5).Select(m => m.ComputerName).Distinct().Count();
                int ComputersOffline = db.Capture.Where(i => DateTime.Now.Subtract(i.CaptureDate).Hours > 1 * 1.5).Select(m => m.ComputerName).Distinct().Count();
                return "Online Computers : " + ComputersOnline + " Computers In Alert : " + ComputersAlert + " Computers Offline : " + ComputersOffline;
            }
        }
    }
}
