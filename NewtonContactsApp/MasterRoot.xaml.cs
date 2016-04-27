using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NewtonContactsApp {
    // Main root for managing Master/Detail pattern: 
    public sealed partial class MasterRoot : Page {
        // Field for storing reference to application state:
        private Model.IContactsRepository DB;
        public MasterRoot() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            DB = e.Parameter as Model.IContactsRepository;
            if (DB != null)
                initViewButtonState();
        }

        // Method for hiding and showing commandbar:
        public void EnableCommandBar(bool enable) {
            cdb_NavigationBar.Visibility = enable
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        // Method for managing navigation to Detail view:
        public void ShowDetails(Model.Contact contact) {
            // When navigating to detail view, hide commandbar:
            EnableCommandBar(false);
            // Pass given (selected) contact object and reference to database to Details:
            frm_MasterRoot.Navigate(typeof(DetailsPage), Tuple.Create(contact, DB));
        }

        // Event method for creating a new database record and navigating to Detail view:
        private void btn_AppBarAdd_Click(object sender, RoutedEventArgs e) {
            // Record is not immediately added to database in case user aborts interaction:
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

        // Event method for switching between list view and grid view:
        private void btn_AppBarView_Click(object sender, RoutedEventArgs e) {
            AppBarButton btn = sender as AppBarButton;
            if (btn != null) {
                switchViewButtonState();
                setMasterViewPage();
            }
        }

        // Method for navigating subframe to appropriate Master view:
        private void setMasterViewPage() {
            // Pass database reference object to Master views:
            if(!btn_AppBarList.IsEnabled)
                frm_MasterRoot.Navigate(typeof(MasterListView), DB);
            else if (!btn_AppBarGrid.IsEnabled)
                frm_MasterRoot.Navigate(typeof(MasterGridView), DB);
        }

        // Method for setting up initial Master view state:
        private void initViewButtonState() {
            // Assure one button for navigating to appropriate Master view is disabled and the other is enabled:
            btn_AppBarGrid.IsEnabled = !btn_AppBarList.IsEnabled;
            setMasterViewPage();
        }

        // Method for switching enabled/disabled state for buttons (buttons for navigating between Master views):
        private void switchViewButtonState() {
            btn_AppBarList.IsEnabled = !btn_AppBarList.IsEnabled;
            btn_AppBarGrid.IsEnabled = !btn_AppBarGrid.IsEnabled;
        }
    }
}
