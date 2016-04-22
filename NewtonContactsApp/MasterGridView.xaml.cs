using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NewtonContactsApp {
    public sealed partial class MasterGridView : Page {
        private Model.IContactsRepository DB;
        public MasterGridView() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            DB = e.Parameter as Model.IContactsRepository;
            if (DB != null)
                grv_View.ItemsSource = DB.GetAll();
        }

        private void grv_View_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}
