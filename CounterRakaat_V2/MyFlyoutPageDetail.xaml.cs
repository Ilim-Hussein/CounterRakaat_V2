using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CounterRakaat_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyFlyoutPageDetail : ContentPage
    {
        public MyFlyoutPageDetail()
        {
            InitializeComponent();
          MainPage control= new MainPage();
          control.Accelerometer_Stop();
        }
    }
}