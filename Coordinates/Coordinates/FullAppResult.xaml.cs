using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Coordinates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullAppResult : ContentPage
    {

        List<Coords> fl = new List<Coords>();
        List<Coords> ml = new List<Coords>();
        List<Coords> gl = new List<Coords>();

        public FullAppResult(List<Coords> final, List<Coords> marks, List<Coords> gate)
        {
            InitializeComponent();

            fl = final;
            ml = marks;
            gl = gate;

            finalList.ItemsSource = fl;
            marksList.ItemsSource = ml;
            gateList.ItemsSource = gl;
        }
    }
}