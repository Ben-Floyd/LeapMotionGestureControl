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
        private bool _gPressed = false;

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

        void SlideShowStart(PowerPoint.SlideShowWindow window)
        {
            _gestureMap.HandSwipeDetected += HandleHandSwipe;
            _gestureMap.CircleDetected += HandleCircle;
            _gestureMap.ZoomInDetected += HandleZoomIn;
            _gestureMap.ZoomOutDetected += HandleZoomOut;
        }

        void SlideShowEnd(PowerPoint.Presentation presentation)
        {
            Print("Slide Show Ended");
            _gestureMap.HandSwipeDetected -= HandleHandSwipe;
            _gestureMap.CircleDetected -= HandleCircle;
            _gestureMap.ZoomInDetected -= HandleZoomIn;
            _gestureMap.ZoomOutDetected -= HandleZoomOut;
        }

        void HandleHandSwipe(object sender, LeapMotionGestureMap.Events.HandSwipeEvent swipeEvent)
        {
            Print("Hand Swipe Event Recieved");
            Thread.CurrentThread.SetApartmentState(ApartmentState.STA);//allow access to UI

            if (swipeEvent.Swipe.Direction.Equals(
                LeapMotionGestureMap.Gestures.HandSwipe.SwipeDirection.RIGHT))
            {
                Print("Next");
                if (_gPressed)
                {
                    System.Windows.Forms.SendKeys.SendWait("{RIGHT}");
                }
                else
                {
                    Application.ActivePresentation.SlideShowWindow.View.Next();
                }
            }
            else
            {
                Print("Prev");
                if (_gPressed)
                {
                    System.Windows.Forms.SendKeys.SendWait("{LEFT}");
                }
                else
                {
                    Application.ActivePresentation.SlideShowWindow.View.Previous();
                }
            }
        }

        void HandleCircle(object sender, LeapMotionGestureMap.Events.CircleEvent circleEvent)
        {
            Print("Circle Event Recieved");
            Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

            System.Windows.Forms.SendKeys.SendWait("^l");
        }

        void HandleZoomIn(object sender, LeapMotionGestureMap.Events.ZoomInEvent zoomInEvent)
        {
            Print("ZoomIn Event Recieved");
            Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

            if (!_gPressed)
            {
                Print("Pressed G");
                System.Windows.Forms.SendKeys.SendWait("g");
                _gPressed = true;
            }
        }

        void HandleZoomOut(object sender, LeapMotionGestureMap.Events.ZoomOutEvent zoomOutEvent)
        {
            Print("ZoomOut Event Recieved");
            Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

            if (_gPressed)
            {
                Print("Pressed Enter");
                System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                _gPressed = false;
            }
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
