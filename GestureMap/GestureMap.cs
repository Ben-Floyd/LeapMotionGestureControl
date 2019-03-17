using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;

namespace LeapMotionGestureMap
{

    public class GestureMap
    {
        private static Leap.Controller controller;
        public static Leap.GestureList standardGestures;

        private LeapListener listener;

        public GestureMap()
        {
            controller = new Leap.Controller();
            listener = new LeapListener();

            controller.EnableGesture(Leap.Gesture.GestureType.TYPE_SWIPE);
            controller.AddListener(listener);

            standardGestures = null;
        }

        public static void processFrame()
        {
            Leap.Frame frame = controller.Frame();
            standardGestures = frame.Gestures();
        }

        static void Main()
        {

        }
    }
}
