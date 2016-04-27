using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NewtonContactsApp {
    // Management of the Detail view:
    public sealed partial class DetailsPage : Page {
        // Field for managing reference to database:
        private Model.IContactsRepository DB;
        // Field for managing reference to selected record for editing:
        private Model.Contact SelectedContact;
        public DetailsPage() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            var t = e.Parameter as Tuple<Model.Contact, Model.IContactsRepository>;
            if (t != null) {
                SelectedContact = t.Item1;
                DB = t.Item2;
                grd_TextFields.DataContext = SelectedContact;
                tbx_CareOfField.Text = SelectedContact.CareOf != ""
                    ? SelectedContact.CareOf.Split(' ')[1]
                    : "";
            }
        }

        // Method for managing exit from Detail view and returning to Master view:
        private void exitDetails() {
            ((MasterRoot)((Grid)Frame.Parent).Parent).EnableCommandBar(true);
            Frame.GoBack();
        }

        // Method for saving data in appropriate text fields on gui to database:
        private void updateContact() {
            SelectedContact.Name = tbx_NameField.Text;
            SelectedContact.PhoneNumber = tbx_PhoneNumberField.Text;
            SelectedContact.PostalCode = tbx_PostalCodeField.Text;
            SelectedContact.EmailAddress = tbx_EmailAddressField.Text;
            SelectedContact.Address = tbx_AddressField.Text;
            SelectedContact.City = tbx_CityField.Text;
            SelectedContact.Country = tbx_CountryField.Text;
            SelectedContact.CareOf = tbx_CareOfField.Text != ""
                ? string.Format($"c/o {tbx_CareOfField.Text}")
                : "";

            // If the selected contact isn't in database (if it is recently created), create new record entry in database:
            if(DB.Get(SelectedContact.Index) == null)
                DB.Create(SelectedContact);
            /* The reason behind this little piece of logic is that if a new record is created but user
             * regrets adding it, the record isn't added to database until user decides to actually save
             * changes.
             */
        }

        // Event method for saving data and exiting Detail view:
        private void btn_Save_Click(object sender, RoutedEventArgs e) {
            updateContact();
            exitDetails();
        }

        // Event method for saving data:
        private void btn_Apply_Click(object sender, RoutedEventArgs e) {
            updateContact();
        }

        // Event method for removing selected record from database:
        private void btn_Delete_Click(object sender, RoutedEventArgs e) {
            DB.Delete(SelectedContact.Index);
            exitDetails();
        }

        // Event method for exiting Detail view without applying changes:
        private void btn_Cancel_Click(object sender, RoutedEventArgs e) {
            exitDetails();
        }
    }
}
