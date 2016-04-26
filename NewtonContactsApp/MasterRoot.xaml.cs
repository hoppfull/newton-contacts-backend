using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NewtonContactsApp {
    public sealed partial class MasterRoot : Page {
        private Model.IContactsRepository DB;
        public MasterRoot() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            DB = e.Parameter as Model.IContactsRepository;
            if (DB != null)
                initViewButtonState();
        }

        public void EnableCommandBar(bool enable) {
            cdb_NavigationBar.Visibility = enable
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public void ShowDetails(Model.Contact contact) {
            EnableCommandBar(false);
            frm_MasterRoot.Navigate(typeof(DetailsPage), Tuple.Create(contact, DB));
        }

        private void btn_AppBarAdd_Click(object sender, RoutedEventArgs e) {
            Model.Contact newContact = new Model.Contact {
                Name = "",
                EmailAddress = "",
                PhoneNumber = "",
                CareOf = "",
                Address = "",
                PostalCode = "",
                City = "",
                Country = "",
                AppData = ""
            };
            ShowDetails(newContact);
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
                frm_MasterRoot.Navigate(typeof(MasterListView), DB);
            else if (!btn_AppBarGrid.IsEnabled)
                frm_MasterRoot.Navigate(typeof(MasterGridView), DB);
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
