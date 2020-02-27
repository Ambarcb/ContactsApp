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
        Contact _NewContact;
        public ICommand AddContactCommand { get; set; }
        public ICommand ReturnToMainCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public Contact NewContact
        {
            get
            {
                return _NewContact;
            }
            set
            {
                _NewContact = value;
                if (_NewContact != null)
                    return;
            }
        }
        
        public AddNewContactPageViewModel(ObservableCollection<Contact> contacts)
        {
            NewContact = new Contact() { Picture = "ic_pp" };

            AddContactCommand = new Command(async () =>
            {
                contacts.Add(NewContact);
                await App.Current.MainPage.Navigation.PopModalAsync();
            });

            ReturnToMainCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        public AddNewContactPageViewModel(ObservableCollection<Contact> contacts, Contact _SelectedContact)
        {
            NewContact = _SelectedContact;
            AddContactCommand = new Command(async () =>
            {
                contacts.Add(NewContact);
                await App.Current.MainPage.Navigation.PopModalAsync();
            });
        }
    }
}
