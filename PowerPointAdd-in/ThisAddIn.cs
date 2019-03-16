using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using Leap;

namespace LeapMotionPowerPointAdd_in
{
    
    public partial class ThisAddIn
    {
        Controller controller;
        LeapEventListener listener;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            controller = new Controller();
            listener = new LeapEventListener(this.Application);
            controller.AddListener(listener);

            controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            controller.RemoveListener(listener);
            controller.Dispose();
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
