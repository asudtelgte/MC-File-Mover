using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Save_Mover
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Starting watch for Minecraft Launcher.");

            // Set up a timer and its corresponding event.
            System.Timers.Timer time = new System.Timers.Timer();
            time.Interval = 60000; // This is every minute
            time.Elapsed += new System.Timers.ElapsedEventHandler(this.onTimer);
            time.Start();
        }

        protected override void OnStop()
        {
        }

        protected void onTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            if (watchForProg())
            {
                //TODO Move folder from oneDrive to local MC directory
                //becuase I'm dumb and didn't make the user account on each of my computers the same, I will have to do a nested try catch statement to see if the folders exist and which to copy to
            }
        }

        static bool watchForProg()
        {
            Boolean running = false;

            foreach (Process p in Process.GetProcesses())
            {

                if (p.MainModule.FileName.Contains("Minecraft Launcher"))
                {
                    running = true;
                }
            }
            return running;
        }
    }
}
