using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;

namespace LeapMotionGestureMap
{
    class LeapListener : Leap.Listener
    {
        private Object thisLock = new Object();

        public override void OnFrame(Controller controller)
        {
            lock (thisLock)
            {
                GestureMap.processFrame();
            }
        }
    }
}
