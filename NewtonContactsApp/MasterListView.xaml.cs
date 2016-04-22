using Windows.UI.Xaml.Controls;
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
            ListView lsv_Item = sender as ListView;
            if(lsv_Item != null) {
                Frame.Navigate(typeof(DetailsPage), new DetailsPageState {
                    DB = DB, SelectedContact = (Model.Contact)lsv_View.SelectedItem
                });
            }
        }
    }
}
