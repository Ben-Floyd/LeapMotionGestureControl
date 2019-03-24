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
        private static readonly object slideShowLock = new object();
        private bool slideShowRunnning;
        private Thread show;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            slideShowRunnning = false;
            LeapMotionGestureMap.GestureMap.Init();

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
            slideShowRunnning = true;
            show = new Thread(slideShow);
            show.Start();
        }

        void SlideShowEnd(PowerPoint.Presentation presentation)
        {
            Debug.WriteLine("Slide Show Ended");
            slideShowRunnning = false;
            show.Join();
        }

        void slideShow ()
        {
            lock (slideShowLock)
            {
                while (slideShowRunnning)
                {
                    Leap.GestureList gestures = LeapMotionGestureMap.GestureMap.GetGestures();
                    if ((gestures != null)
                        && !(gestures.IsEmpty))
                    {
                        foreach (Leap.Gesture gesture in gestures)
                        {
                            HandleGesture(gesture);
                        }
                    }
                }
            }
        }

        void HandleGesture(Leap.Gesture gesture)
        {
            if (gesture.Type.Equals(Leap.Gesture.GestureType.TYPE_SWIPE))
            {
                Leap.SwipeGesture swipe = new Leap.SwipeGesture(gesture);

                if (gesture.State.Equals(Leap.Gesture.GestureState.STATESTOP))
                {
                    Debug.WriteLine("SWIPE");
                    if (swipe.Direction.x > 0)
                    {
                        Debug.WriteLine("Next");
                        Application.ActivePresentation.SlideShowWindow.View.Next();
                    }
                    else
                    {
                        Debug.WriteLine("Prev");
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
