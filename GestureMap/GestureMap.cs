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

        private Leap.Controller _controller = null;
        private Leap.GestureList _standardGestures;
        public event EventHandler<Events.FingerSwipeEvent> FingerSwipeDetected;
        public event EventHandler<Events.HandSwipeEvent> HandSwipeDetected;

        public GestureMap()
        {
            _standardGestures = null;
            _controller = new Leap.Controller();

            _controller.EnableGesture(Leap.Gesture.GestureType.TYPE_SWIPE);
            _controller.AddListener(this);
        }

        ~GestureMap()
        {
            _controller.RemoveListener(this);
            _controller.Dispose();
        }

        public override void OnFrame(Leap.Controller controller)
        {
            Leap.Frame frame = controller.Frame();

            _standardGestures = frame.Gestures();

            foreach (Leap.Gesture gesture in _standardGestures)
            {
                if (gesture.State.Equals(Leap.Gesture.GestureState.STATESTOP))
                {
                    if (gesture.Type.Equals(Leap.Gesture.GestureType.TYPESWIPE))
                    {
                        Print("Finger Swipe Detected");
                        Leap.SwipeGesture swipe = new Leap.SwipeGesture(gesture);
                        Events.FingerSwipeEvent swipeEvent = new Events.FingerSwipeEvent(swipe);
                        OnFingerSwipeDetected(swipeEvent);
                    }
                }
            }

            Gestures.HandSwipe handSwipe = Gestures.HandSwipe.IsHandSwipe(frame);
            if (handSwipe != null)
            {
                //Print("Hand Swipe " + handSwipe.State.ToString());
                
                if (handSwipe.State.Equals(Gestures.GestureState.END))
                {
                    Print("Hand Swipe Detected");

                    Events.HandSwipeEvent swipeEvent = new Events.HandSwipeEvent(handSwipe);
                    OnHandSwipeDetected(swipeEvent);
                }
            }
        }

        protected virtual void OnFingerSwipeDetected(Events.FingerSwipeEvent swipe)
        {
            EventHandler<Events.FingerSwipeEvent> handler = FingerSwipeDetected;

            if (handler != null)
            {
                Print("Finger Swipe Event Called");
                handler(this, swipe);
            }
        }

        protected virtual void OnHandSwipeDetected(Events.HandSwipeEvent swipe)
        {
            EventHandler<Events.HandSwipeEvent> handler = HandSwipeDetected;

            if (handler != null)
            {
                Print("Finger Swipe Event Called");
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
