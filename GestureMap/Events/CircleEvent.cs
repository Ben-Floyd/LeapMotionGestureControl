using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapMotionGestureMap.Events
{
    public class CircleEvent : EventArgs
    {
        private Leap.CircleGesture _circle;

        public CircleEvent(Leap.CircleGesture circle)
        {
            _circle = circle;
        }

        public Leap.CircleGesture Swipe
        {
            get { return _circle; }
            set { _circle = value; }
        }
    }
}