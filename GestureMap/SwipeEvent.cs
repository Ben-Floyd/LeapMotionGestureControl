using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapMotionGestureMap
{
    public class SwipeEvent : EventArgs
    {
        private Leap.SwipeGesture swipe;

        public SwipeEvent(Leap.SwipeGesture swipe)
        {
            this.swipe = swipe;
        }

        public Leap.SwipeGesture Swipe
        {
            get { return swipe; }
            set { swipe = value; }
        }
    }
}
