#define Debug
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Leap;

namespace LeapMotionGestureMap
{

    public static class GestureMap
    {
        private static readonly object consoleLock = new object();

        private static Leap.Controller controller = null;
        private static Leap.GestureList standardGestures = null;
        private static LeapListener listener = null;

        public static void Init()
        {
            controller = new Leap.Controller();
            listener = new LeapListener();

            controller.EnableGesture(Leap.Gesture.GestureType.TYPE_SWIPE);
            controller.AddListener(listener);
        }

        public static Leap.GestureList GetGestures()
        {
            return standardGestures;
        }

        class LeapListener : Leap.Listener
        {
            public override void OnFrame(Controller controller)
            {
                Leap.Frame frame = controller.Frame();

                standardGestures = frame.Gestures();

                foreach (Leap.Gesture gesture in standardGestures)
                {
                    if (gesture.State.Equals(Leap.Gesture.GestureState.STATESTOP))
                    {
                        if (gesture.Type.Equals(Leap.Gesture.GestureType.TYPESWIPE))
                        {
                            Print("Detected Swipe");
                        }
                    }
                }
            }
        }

        private static void Print(String output)
        {
            lock (consoleLock)
            {
                Console.WriteLine("[GM] " + output);
                System.Diagnostics.Debug.WriteLine("[GM] " + output);
            }
        }

        static void Main()
        {
            Init();

            Console.ReadKey();
        }
    }
}
