using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NewtonContactsApp {
    // Management of the list view:
    public sealed partial class MasterListView : Page {
        // No need for code behind to manage reference to database!
        public MasterListView() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            // Retrieve reference object to database and store content GUI-side: 
            Model.IContactsRepository DB = e.Parameter as Model.IContactsRepository;
            if (DB != null)
                lsv_View.ItemsSource = DB.GetAll();
        }

        // Event method for navigating to Detail view on selecting item on list view:
        private void lsv_View_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ListView lsv_Item = sender as ListView;
            // Pass selected record item to Detail view and navigate there:
            if (lsv_Item != null)
                ((MasterRoot)((Grid)Frame.Parent).Parent)
                    .ShowDetails((Model.Contact)lsv_View.SelectedItem);
        }
    }
}
