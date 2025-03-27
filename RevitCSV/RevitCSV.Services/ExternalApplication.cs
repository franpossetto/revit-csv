using Autodesk.Revit.UI;
using RevitCSV.Common;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace RevitCSV.Services
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

            const string RIBBON_TAB = "Revit CSV";
            Ribbon.CreateRibbonTab(application, RIBBON_TAB);

            /// <summary>
            /// Create a new Panel on Ribbon Tab.
            /// </summary>

            const string RIBBON_PANEL = "Export";
            RibbonPanel ribbonPanel = Ribbon.CreateRibbonPanel(application, RIBBON_PANEL, RIBBON_TAB);

            /// <summary>
            /// Create new Buttons on Panel.
            /// </summary>
            /// 
            PushButtonData csvExporter = new PushButtonData(
                "Revit CSV \nExporter",
                "Revit CSV \nExporter",
                typeof(ExportCommand).Assembly.Location,
                typeof(ExportCommand).FullName)
            {
                LargeImage = GetImage(Common.Properties.Resources.icon.GetHbitmap())
            };

            ribbonPanel.AddItem(csvExporter);


            return Result.Succeeded;
        }

        private static BitmapSource GetImage(IntPtr bm)
        {
            BitmapSource bmSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bm,
                    IntPtr.Zero,
                    System.Windows.Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());

            return bmSource;
        }
    }
}
