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
    public sealed partial class MasterRoot : Page {
        public MasterRoot() {
            InitializeComponent();
            initViewButtonState();
        }

        private void btn_AppBarAdd_Click(object sender, RoutedEventArgs e) {

        }

        private void btn_AppBarView_Click(object sender, RoutedEventArgs e) {
            AppBarButton btn = sender as AppBarButton;

            if (btn != null) {
                switchViewButtonState();
                setMasterViewPage();
            }

        }

        private void setMasterViewPage() {
            if(!btn_AppBarList.IsEnabled)
                frm_MasterRoot.Navigate(typeof(MasterListView));
            else if (!btn_AppBarGrid.IsEnabled)
                frm_MasterRoot.Navigate(typeof(MasterGridView));
        }

        private void initViewButtonState() {
            btn_AppBarGrid.IsEnabled = !btn_AppBarList.IsEnabled;
            setMasterViewPage();
        }

        private void switchViewButtonState() {
            btn_AppBarList.IsEnabled = !btn_AppBarList.IsEnabled;
            btn_AppBarGrid.IsEnabled = !btn_AppBarGrid.IsEnabled;
        }
    }
}
