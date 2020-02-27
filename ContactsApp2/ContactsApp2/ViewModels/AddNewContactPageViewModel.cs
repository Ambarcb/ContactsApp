using ContactsApp2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsApp2.ViewModels
{
    public class AddNewContactPageViewModel : INotifyPropertyChanged
    {
        Contact _selectedContact;
        public ICommand AddContactCommand { get; set; }
        public ICommand ReturnToMainCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public Contact SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
               
            }
        }
        
        public AddNewContactPageViewModel(ObservableCollection<Contact> contacts)
        {
            SelectedContact = new Contact() { Picture = "ic_pp" };

            AddContactCommand = new Command(async () =>
            {
                contacts.Add(SelectedContact);
                await App.Current.MainPage.Navigation.PopModalAsync();
            });

            ReturnToMainCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        public AddNewContactPageViewModel(ObservableCollection<Contact> contacts, Contact _selectedContact)
        {
            SelectedContact = _selectedContact;
            AddContactCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PopModalAsync();
            });
        }
    }
}
