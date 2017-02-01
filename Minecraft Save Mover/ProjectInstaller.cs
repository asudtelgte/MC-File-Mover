using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Minecraft_Save_Mover
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();

            if (! EventLog.SourceExists("Personal Services"))
            {
                EventLog.CreateEventSource("Personal Services", "Personal Services Log");
            }
        }
    }
}
