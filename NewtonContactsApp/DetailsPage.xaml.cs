using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NewtonContactsApp {
    public sealed partial class DetailsPage : Page {
        private Model.IContactsRepository DB;
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

        private void exitDetails() {
            ((MasterRoot)((Grid)Frame.Parent).Parent).EnableCommandBar(true);
            Frame.GoBack();
        }

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

            if(DB.Get(SelectedContact.Index) == null)
                DB.Create(SelectedContact);
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e) {
            updateContact();
            exitDetails();
        }

        private void btn_Apply_Click(object sender, RoutedEventArgs e) {
            updateContact();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e) {
            DB.Delete(SelectedContact.Index);
            exitDetails();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e) {
            exitDetails();
        }
    }
}
