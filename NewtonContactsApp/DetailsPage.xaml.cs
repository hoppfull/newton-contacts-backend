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

namespace NewtonContactsApp {
    class DetailsPageState {
        public Model.IContactsRepository DB { get; set; }
        public Model.Contact SelectedContact { get; set; }
    }
    public sealed partial class DetailsPage : Page {
        private DetailsPageState Details;
        public DetailsPage() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            Details = e.Parameter as DetailsPageState;
            if(Details != null) {

            }
        }
    }
}
