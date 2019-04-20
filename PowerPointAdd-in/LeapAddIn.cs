using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;

namespace LeapMotionPowerPointAdd_in
{
    public partial class LeapAddIn
    {
        private static readonly object _slideShowLock = new object();
        private LeapMotionGestureMap.GestureMap _gestureMap;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _gestureMap = new LeapMotionGestureMap.GestureMap();

            Application.SlideShowBegin +=
                new PowerPoint.EApplication_SlideShowBeginEventHandler(SlideShowStart);

            Application.SlideShowEnd +=
                new PowerPoint.EApplication_SlideShowEndEventHandler(SlideShowEnd);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        void HandleFingerSwipe(object sender, LeapMotionGestureMap.Events.FingerSwipeEvent swipe)
        {
            Print("Finger Swipe Event Received");

            if (swipe.Swipe.Direction.x > 0)
            {
                Print("Finger Next");
                //Application.ActivePresentation.SlideShowWindow.View.Next();
            }
            else
            {
                Print("Finger Prev");
                //Application.ActivePresentation.SlideShowWindow.View.Previous();
            }
        }

        void HandleHandSwipe(object sender, LeapMotionGestureMap.Events.HandSwipeEvent swipe)
        {
            Print("Hand Swipe Event Recieved");

            if (swipe.Swipe.Direction.Equals(
                LeapMotionGestureMap.Gestures.HandSwipe.SwipeDirection.RIGHT))
            {
                Print("Next");
                Application.ActivePresentation.SlideShowWindow.View.Next();
            }
            else
            {
                Print("Prev");
                Application.ActivePresentation.SlideShowWindow.View.Previous();
            }
        }

        void SlideShowStart(PowerPoint.SlideShowWindow window)
        {
            _gestureMap.FingerSwipeDetected += HandleFingerSwipe;
            _gestureMap.HandSwipeDetected += HandleHandSwipe;
        }

        void SlideShowEnd(PowerPoint.Presentation presentation)
        {
            Print("Slide Show Ended");
            _gestureMap.FingerSwipeDetected -= HandleFingerSwipe;
            _gestureMap.HandSwipeDetected -= HandleHandSwipe;
        }

        void Print(string message)
        {
            Debug.WriteLine("[PP] " + message);
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
