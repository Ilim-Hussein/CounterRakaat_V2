﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CounterRakaat_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyFlyoutPageFlyout : ContentPage
    {
        public ListView ListView;

        public MyFlyoutPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MyFlyoutPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MyFlyoutPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MyFlyoutPageFlyoutMenuItem> MenuItems { get; set; }

            public MyFlyoutPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MyFlyoutPageFlyoutMenuItem>(new[]
                {
                    new MyFlyoutPageFlyoutMenuItem { Id = 0, Title = "Главное"          ,IconSourse = "home.png",   TargetType = typeof(MainPage)},
                    new MyFlyoutPageFlyoutMenuItem { Id = 1, Title = "Как пользоваться" ,IconSourse = "help.png",   TargetType = typeof(MyFlyoutPageDetail)},
                    new MyFlyoutPageFlyoutMenuItem { Id = 2, Title = "О нас"            ,IconSourse = "aboutus.png",TargetType = typeof(MyFlyoutPageDetail_1)},
                    new MyFlyoutPageFlyoutMenuItem { Id = 3, Title = "Контакты"         ,IconSourse = "contact.png",TargetType = typeof(MyFlyoutPageDetail_2) },

                }); ;
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void Image_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}