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
    public partial class MyFlyoutPageDetail_2 : ContentPage
    {
        public MyFlyoutPageDetail_2()
        {
            InitializeComponent();
            MainPage control = new MainPage();
            control.Accelerometer_Stop();
            Contacts_table_of_contents.Text = Recource.Resource.Contacts_table_of_contents;
            Contacts_text_mail.Text = Recource.Resource.Contacts_text_mail;
            Contacts_text_website.Text = Recource.Resource.Contacts_text_website;
        }
    }
}