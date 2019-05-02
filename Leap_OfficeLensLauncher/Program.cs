using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leap_OfficeLensLauncher
{
    class Program
    {
        private static LeapMotionGestureMap.GestureMap _gestureMap;
        private static readonly object consoleLock = new object();

        private static void HandleCircle(object sender, LeapMotionGestureMap.Events.CircleEvent cricle)
        {
            System.Management.Automation.PowerShell shell;
            shell = System.Management.Automation.PowerShell.Create().AddCommand("explorer.exe").AddArgument("shell:appsFolder\\Microsoft.OfficeLens_8wekyb3d8bbwe!App");
            shell.Invoke();
            Console.WriteLine("CircleEventRecieved");
        }

        private void Print(String output)
        {
            lock (consoleLock)
            {
                Console.WriteLine("[OL] " + output);
                System.Diagnostics.Debug.WriteLine("[OL] " + output);
            }
        }

        static void Main(string[] args)
        {
            _gestureMap = new LeapMotionGestureMap.GestureMap();

            while (Properties.Settings1.Default.Running)
            {

                if (Properties.Settings1.Default.Active)
                {
                    _gestureMap.CircleDetected += HandleCircle;
                }

                while (Properties.Settings1.Default.Active)
                {
                    System.Threading.Thread.Sleep(500);//idle
                }

                _gestureMap.CircleDetected += HandleCircle;

            }
        }
    }
}
