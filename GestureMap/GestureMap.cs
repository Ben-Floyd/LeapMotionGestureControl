#define Debug
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeapMotionGestureMap
{
    public class GestureMap : Leap.Listener
    {
        private static readonly object consoleLock = new object();

        private Leap.Controller controller = null;
        private Leap.GestureList standardGestures;
        public event EventHandler<SwipeEvent> SwipeDetected;

        public GestureMap()
        {
            standardGestures = null;
            controller = new Leap.Controller();

            controller.EnableGesture(Leap.Gesture.GestureType.TYPE_SWIPE);
            controller.AddListener(this);
        }

        ~GestureMap()
        {
            controller.RemoveListener(this);
            controller.Dispose();
        }

        public override void OnFrame(Leap.Controller controller)
        {
            Leap.Frame frame = controller.Frame();

            standardGestures = frame.Gestures();

            foreach (Leap.Gesture gesture in standardGestures)
            {
                if (gesture.State.Equals(Leap.Gesture.GestureState.STATESTOP))
                {
                    if (gesture.Type.Equals(Leap.Gesture.GestureType.TYPESWIPE))
                    {
                        Print("Swipe Detected");
                        Leap.SwipeGesture swipe = new Leap.SwipeGesture(gesture);
                        SwipeEvent swipeEvent = new SwipeEvent(swipe);
                        OnSwipeDetected(swipeEvent);
                    }
                }
            }
        }

        protected virtual void OnSwipeDetected(SwipeEvent swipe)
        {
            EventHandler<SwipeEvent> handler = SwipeDetected;

            if (handler != null)
            {
                Print("Swipe Event Called");
                handler(this, swipe);
            }
        }

        private void Print(String output)
        {
            lock (consoleLock)
            {
                Console.WriteLine("[GM] " + output);
                System.Diagnostics.Debug.WriteLine("[GM] " + output);
            }
        }

        static void Main()
        {
            GestureMap map  = new GestureMap();

            Console.ReadKey();
        }
    }
}
