﻿using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitCSV
{
    internal class ExternalApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            /// <summary>
            /// Create a new Tab on Ribbon Bar.
            /// </summary>

            const string RIBBON_TAB = "Revit API Extension";
            Ribbon.CreateRibbonTab(application, RIBBON_TAB);

            /// <summary>
            /// Create a new Panel on Ribbon Tab.
            /// </summary>

            const string RIBBON_PANEL = "My Addins";
            RibbonPanel ribbonPanel = Ribbon.CreateRibbonPanel(application, RIBBON_PANEL, RIBBON_TAB);

            /// <summary>
            /// Create new Buttons on Panel.
            /// </summary>
            /// 
            const string PUSH_BUTTON_NAME = "Revit Push Button";
            const string PUSH_BUTTON_TEXT = "Revit Plugin";

            PushButtonData pushDataButton = Ribbon.CreatePushButtonData(PUSH_BUTTON_NAME, PUSH_BUTTON_TEXT, "RevitCSV.ExternalCommand");

            pushDataButton.LongDescription = "Long description of the command tooltip";
            pushDataButton.ToolTip = "The description that appears as a ToolTip for the item";

            PushButton pushButton = ribbonPanel.AddItem(pushDataButton) as PushButton;
            System.Drawing.Bitmap ico = Properties.Resources.icon;
            System.Windows.Media.Imaging.BitmapSource icon30 = Ribbon.Icon(ico);
            pushButton.LargeImage = icon30;

            return Result.Succeeded;



        }
    }
}
