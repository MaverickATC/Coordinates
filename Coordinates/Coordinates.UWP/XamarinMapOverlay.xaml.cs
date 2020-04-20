using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace Coordinates.UWP
{
    public sealed partial class XamarinMapOverlay : UserControl
    {
        CustomPin customPin;
        public XamarinMapOverlay(CustomPin pin)
        {
            this.InitializeComponent();
            customPin = pin;
            PointName.Text = customPin.point.Name;
        }
    }
}
