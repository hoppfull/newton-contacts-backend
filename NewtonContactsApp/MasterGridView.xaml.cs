using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NewtonContactsApp {
    public sealed partial class MasterGridView : Page {
        public MasterGridView() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            Model.IContactsRepository DB = e.Parameter as Model.IContactsRepository;
            if (DB != null)
                grv_View.ItemsSource = DB.GetAll();
        }

        private void grv_View_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            GridView grv_Item = sender as GridView;
            if (grv_Item != null)
                ((MasterRoot)((Grid)Frame.Parent).Parent)
                    .ShowDetails((Model.Contact)grv_Item.SelectedItem);
        }
    }
}
