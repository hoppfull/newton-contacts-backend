using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NewtonContactsApp {
    public sealed partial class MasterListView : Page {
        public MasterListView() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            Model.IContactsRepository DB = e.Parameter as Model.IContactsRepository;
            if (DB != null)
                lsv_View.ItemsSource = DB.GetAll();
        }

        private void lsv_View_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ListView lsv_Item = sender as ListView;
            if (lsv_Item != null)
                ((MasterRoot)((Grid)Frame.Parent).Parent)
                    .ShowDetails((Model.Contact)lsv_View.SelectedItem);
        }
    }
}
