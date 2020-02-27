using ContactsApp2.Models;
using ContactsApp2.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewContactPage : ContentPage
    {
        public AddNewContactPage(ObservableCollection<Contact> contact)
        {
            InitializeComponent();
            BindingContext = new AddNewContactPageViewModel(contact);
        }

        public AddNewContactPage(ObservableCollection<Contact> contact, Contact _selectedContact)
        {
            InitializeComponent();
            BindingContext = new AddNewContactPage(contact, _selectedContact);
        }
    }
}