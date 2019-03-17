/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using Leap;

namespace LeapMotionPowerPointAdd_in
{
    
    class LeapEventListener : Listener
    {
        private Object thisLock = new Object();
        private PowerPoint.Application application;
        private String message = "Placeholder";
        private bool slideShowRunnning = false;

        public LeapEventListener(PowerPoint.Application application)
        {
            this.application = application;
        }

        void NewSlide(PowerPoint.Slide slide)
        {
            PowerPoint.Shape textBox = slide.Shapes.AddTextbox(
                Office.MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, 500, 50);
            textBox.TextFrame.TextRange.InsertAfter(message);
        }

        void SlideShowStart(PowerPoint.SlideShowWindow window)
        {
            slideShowRunnning = true;
        }

        void SlideShowEnd(PowerPoint.Presentation presentation)
        {
            slideShowRunnning = false;
        }

        public override void OnConnect(Controller controller)
        {
            message = "Controller Connected";
            application.PresentationNewSlide +=
                new PowerPoint.EApplication_PresentationNewSlideEventHandler(
                NewSlide);
        }

        public override void OnFrame(Controller controller)
        {
            Frame frame = controller.Frame();

            //message = frame.Hands.Count.ToString();

            GestureList gestures = frame.Gestures();

            application.SlideShowBegin +=
                new PowerPoint.EApplication_SlideShowBeginEventHandler(
                    SlideShowStart);

            application.SlideShowEnd +=
                new PowerPoint.EApplication_SlideShowEndEventHandler(
                    SlideShowEnd);

            if(!gestures.IsEmpty && slideShowRunnning)
            {
                foreach(Gesture gesture in gestures)
                {
                    if (gesture.Type.Equals(Gesture.GestureType.TYPE_SWIPE))
                    {
                        SwipeGesture swipe = new SwipeGesture(gesture);

                        if (gesture.State.Equals(Gesture.GestureState.STATESTOP))
                        {
                            lock (thisLock)
                            {
                                if (swipe.Direction.x > 0)
                                {
                                    application.ActivePresentation.SlideShowWindow.View.Next();
                                }
                                else if (!application.ActivePresentation.SlideShowWindow.View.CurrentShowPosition.Equals(0))
                                {     
                                    application.ActivePresentation.SlideShowWindow.View.Previous();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}*/
