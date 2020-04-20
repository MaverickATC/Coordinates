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

namespace Coordinates.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            Xamarin.FormsMaps.Init("g4y71VqlllBcweUKiyF8~pvkYE-dM1rJ_JytH4_1D2g~AokTRogsIOvGkIHdoOeDQv9Q4LhwWf9IcUYEEESjbyxS_oVB8cPP8jjLZdzq4Bab");

            LoadApplication(new Coordinates.App());
        }
    }
}
