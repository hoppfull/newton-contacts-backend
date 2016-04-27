using Windows.UI.Xaml.Controls;

namespace NewtonContactsApp {
    // Starting point of application:
    public sealed partial class MainPage : Page {
        // Initialize mock database for use throughout application execution:
        private Model.IContactsRepository DB = new Model.MockContactsRepo();

        public MainPage() {
            InitializeComponent();
            // Load root page into main frame:
            frm_MainRoot.Navigate(typeof(MasterRoot), DB);
        }
    }
}
