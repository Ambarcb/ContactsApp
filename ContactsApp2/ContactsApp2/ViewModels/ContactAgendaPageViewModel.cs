using ContactsApp2.Models;
using ContactsApp2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactsApp2.ViewModels
{
    public class ContactAgendaPageViewModel : INotifyPropertyChanged
    {
        Contact _SelectedContact;
        public ICommand AddContactCommand { get; set; }
        public ICommand DeleteElementCommand { get; set; }
        public ICommand GoToAddContactPageCommand { get; set; }
        public ICommand EditContactCommand { get; set; }
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public event PropertyChangedEventHandler PropertyChanged;

        public Contact SelectedContact
        {
            get
            {
                return _SelectedContact;
            }
            set
            {
                _SelectedContact = value;

                if (_SelectedContact != null)
                    DisplayElementSelected();

            }
        }

        //Calling method
        public void PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        // Contact ActionSheet 

        public async void DisplayElementSelected()
        {
            string answer = await App.Current.MainPage.DisplayActionSheet("Choose an option", "CANCEL", "", "Call " + SelectedContact.FirstName + "  " + SelectedContact.LastName);

           if (Answer == "Call")
           {
                PlacePhoneCall(_SelectedContact.PhoneNumber);
           }

                
            
        }

        public ContactAgendaPageViewModel(ObservableCollection<Contact> contacts)
        {
            GoToAddContactPageCommand = new Command<Contact>(async (_SelectedContact) =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new AddNewContactPage(Contacts));
            });

            DeleteElementCommand = new Command<Contact>((_SelectedContact) =>
            {
                Contacts.Remove(_SelectedContact);
            });

            EditContactCommand = new Command<Contact>(async (_SelectedContact) =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new AddNewContactPage(Contacts, _SelectedContact));
            });
        }

    }
}
