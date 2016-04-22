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
    public sealed partial class MasterListView : Page {
        private Model.IContactsRepository DB;
        public MasterListView() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            DB = e.Parameter as Model.IContactsRepository;
            if (DB != null)
                lsv_View.ItemsSource = DB.GetAll();
        }

        private void lsv_View_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}
