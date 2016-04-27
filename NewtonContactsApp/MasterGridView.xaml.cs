using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NewtonContactsApp {
    // Management of the grid view:
    public sealed partial class MasterGridView : Page {
        // No need for code behind to manage reference to database!
        public MasterGridView() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            // Retrieve reference object to database and store content GUI-side: 
            Model.IContactsRepository DB = e.Parameter as Model.IContactsRepository;
            if (DB != null)
                grv_View.ItemsSource = DB.GetAll();
        }

        // Event method for navigating to Detail view on selecting item on grid view:
        private void grv_View_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            GridView grv_Item = sender as GridView;
            // Pass selected record item to Detail view and navigate there:
            if (grv_Item != null)
                ((MasterRoot)((Grid)Frame.Parent).Parent)
                    .ShowDetails((Model.Contact)grv_Item.SelectedItem);
        }
    }
}
