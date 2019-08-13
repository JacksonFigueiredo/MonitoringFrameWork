using ClientCapture.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Timers;

namespace ClientCapture.Business
{
    public class ClientService
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
            Console.WriteLine("Preparing to Send Event in 60 Seconds");
            SendEvent();
            Console.WriteLine("Event Sent");
        }

        public void Stop()
        {
            Console.WriteLine("Stopped");
        }


        private async void SendEvent()
        {
            try
            {
                string endPoint = "https://localhost:5000/api/Computer/v1";

                Capture eventObject = new Capture();

                eventObject.ComputerName = System.Environment.MachineName.ToString();
                eventObject.CaptureDate = DateTime.Now;

                using (var httpClient = new HttpClient())
                {
                    var serializedObject = JsonConvert.SerializeObject(eventObject);
                    var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                    await httpClient.PostAsync(endPoint, content);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Something Went Wrong : "+ exp.ToString());
            }

        }
    }
}
