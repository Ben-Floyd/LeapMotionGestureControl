using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;

namespace LeapMotionPowerPointAdd_in
{

    public partial class ThisAddIn
    {
        private LeapMotionGestureMap.GestureMap gestureMap;

        private bool slideShowRunnning;

        private Object thisLock = new Object();

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            slideShowRunnning = false;
            gestureMap = new LeapMotionGestureMap.GestureMap();

            Application.SlideShowBegin +=
                new PowerPoint.EApplication_SlideShowBeginEventHandler(
                    SlideShowStart);

            Application.SlideShowEnd +=
                new PowerPoint.EApplication_SlideShowEndEventHandler(
                    SlideShowEnd);

            Application.PresentationNewSlide +=
                new PowerPoint.EApplication_PresentationNewSlideEventHandler(
                NewSlide);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        void NewSlide(PowerPoint.Slide slide)
        {
            PowerPoint.Shape textBox = slide.Shapes.AddTextbox(
                Office.MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, 500, 50);
            textBox.TextFrame.TextRange.InsertAfter("Hello");
        }

        void SlideShowStart(PowerPoint.SlideShowWindow window)
        {
            slideShowRunnning = true;

            while (slideShowRunnning)
            {
                if ((LeapMotionGestureMap.GestureMap.standardGestures != null) 
                    && !(LeapMotionGestureMap.GestureMap.standardGestures.IsEmpty))
                {
                    foreach(Leap.Gesture gesture in LeapMotionGestureMap.GestureMap.standardGestures)
                    {
                        HandleGesture(gesture);
                    }
                }
            }
        }

        void SlideShowEnd(PowerPoint.Presentation presentation)
        {
            slideShowRunnning = false;
        }

        void HandleGesture(Leap.Gesture gesture)
        {
            if (gesture.Type.Equals(Leap.Gesture.GestureType.TYPE_SWIPE))
            {
                Leap.SwipeGesture swipe = new Leap.SwipeGesture(gesture);

                if (gesture.State.Equals(Leap.Gesture.GestureState.STATESTOP))
                {
                    if (swipe.Direction.x > 0)
                    {
                        Application.ActivePresentation.SlideShowWindow.View.Next();
                    }
                    else if (!Application.ActivePresentation.SlideShowWindow.View.CurrentShowPosition.Equals(0))
                    {
                        Application.ActivePresentation.SlideShowWindow.View.Previous();
                    }
                }
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
