using PimaDoctor.Utilities;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PimaDoctor.Views
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<AbstractChangingWindow, UserControl>))]
    public abstract class AbstractChangingWindow : UserControl
    {
        public Action<AbstractChangingWindow> Change_Window;
    }
}
