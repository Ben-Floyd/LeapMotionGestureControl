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
        private Leap.GestureList _standardGestures = null;
        private Leap.Vector _pointerPosition = null;

        public event EventHandler<Events.FingerSwipeEvent> FingerSwipeDetected;
        public event EventHandler<Events.HandSwipeEvent> HandSwipeDetected;
        public event EventHandler<Events.CircleEvent> CircleDetected;
        public event EventHandler<Events.ZoomInEvent> ZoomInDetected;
        public event EventHandler<Events.ZoomOutEvent> ZoomOutDetected;
        public event EventHandler<Events.ScreenTapEvent> ScreenTapDetected;

        public GestureMap()
        {
            _controller = new Leap.Controller();

            _controller.EnableGesture(Leap.Gesture.GestureType.TYPE_SWIPE);
            _controller.EnableGesture(Leap.Gesture.GestureType.TYPE_CIRCLE);
            _controller.EnableGesture(Leap.Gesture.GestureType.TYPE_SCREEN_TAP);
            
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

            Leap.InteractionBox interactionBox = frame.InteractionBox;
            _pointerPosition =
                interactionBox.NormalizePoint(frame.Pointables.Frontmost.TipPosition);

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

                    if (gesture.Type.Equals(Leap.Gesture.GestureType.TYPE_CIRCLE))
                    {
                        Print("Circle Gesture Detected");
                        Leap.CircleGesture circle = new Leap.CircleGesture(gesture);
                        Events.CircleEvent circleEvent = new Events.CircleEvent(circle);
                        OnCircleDetected(circleEvent);
                    }

                    if (gesture.Type.Equals(Leap.Gesture.GestureType.TYPE_SCREEN_TAP))
                    {
                        Print("Screen Tap Detected");
                        Leap.ScreenTapGesture screenTap = new Leap.ScreenTapGesture(gesture);
                        Events.ScreenTapEvent screenTapEvent = new Events.ScreenTapEvent(screenTap);
                        OnScreenTapDetected(screenTapEvent);
                    }
                }
            }

            Gestures.HandSwipe handSwipe = Gestures.HandSwipe.IsHandSwipe(frame);
            if (handSwipe != null)
            {
                if (handSwipe.State.Equals(Gestures.GestureState.END))
                {
                    Print("Hand Swipe Detected");

                    Events.HandSwipeEvent swipeEvent = new Events.HandSwipeEvent(handSwipe);
                    OnHandSwipeDetected(swipeEvent);
                }
            }

            Gestures.ZoomIn zoomIn = Gestures.ZoomIn.IsZoomIn(frame);
            if (zoomIn != null)
            {
                if (zoomIn.State.Equals(Gestures.GestureState.END))
                {
                    Print("ZoomIn Detected");

                    Events.ZoomInEvent zoomInEvent = new Events.ZoomInEvent(zoomIn);
                    OnZoomInDetected(zoomInEvent);
                }
            }

            Gestures.ZoomOut zoomOut = Gestures.ZoomOut.IsZoomOut(frame);
            if (zoomOut != null)
            {
                if (zoomOut.State.Equals(Gestures.GestureState.END))
                {
                    Print("ZoomOut Detected");

                    Events.ZoomOutEvent zoomOutEvent = new Events.ZoomOutEvent(zoomOut);
                    OnZoomOutDetected(zoomOutEvent);
                }
            }
        }

        public Leap.Vector PointerPosition
        {
            get { return _pointerPosition; }
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

        protected virtual void OnCircleDetected(Events.CircleEvent circle)
        {
            EventHandler<Events.CircleEvent> handler = CircleDetected;

            if (handler != null)
            {
                Print("Circle Event Called");
                handler(this, circle);
            }
        }
        
        protected virtual void OnScreenTapDetected(Events.ScreenTapEvent screenTap)
        {
            EventHandler<Events.ScreenTapEvent> handler = ScreenTapDetected;

            if (handler != null)
            {
                Print("Screen Tap Event Called");
                handler(this, screenTap);
            }
        }
        
        protected virtual void OnHandSwipeDetected(Events.HandSwipeEvent swipe)
        {
            EventHandler<Events.HandSwipeEvent> handler = HandSwipeDetected;

            if (handler != null)
            {
                Print("Hand Swipe Event Called");
                handler(this, swipe);
            }
        }

        protected virtual void OnZoomInDetected(Events.ZoomInEvent zoomIn)
        {
            EventHandler<Events.ZoomInEvent> handler = ZoomInDetected;

            if (handler != null)
            {
                Print("ZoomIn Event Called");
                handler(this, zoomIn);
            }
        }

        protected virtual void OnZoomOutDetected(Events.ZoomOutEvent zoomOut)
        {
            EventHandler<Events.ZoomOutEvent> handler = ZoomOutDetected;

            if (handler != null)
            {
                Print("ZoomOut Event Called");
                handler(this, zoomOut);
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
