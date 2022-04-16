using System;
using Laboratory2Borovik.Tools;
using Laboratory2Borovik.Models;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Laboratory2Borovik.Navigation;
using System.Threading.Tasks;
using Laboratory2Borovik.Sending;

namespace Laboratory2Borovik.ViewModels
{
    internal class LoginViewModel : INotifyPropertyChanged, INavigatable
    {
        private RelayCommand<object>? exitCommand;
        private RelayCommand<object>? gotoInfoCommand;
        private Person ourPerson;
        private Action gotoInfo;
        private DateTime birthDate = DateTime.Today;
        public event PropertyChangedEventHandler? PropertyChanged;
        public NavigationTypes ViewType => NavigationTypes.Login;
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        
        
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return gotoInfoCommand ??= new RelayCommand<object>(_ => Proceed(), CanExecute);
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public RelayCommand<object> ExitCommand
        {
            get
            {
                return exitCommand ??= new RelayCommand<object>(o => Close());
            }
        }

        public LoginViewModel(Action gotoInfo)
        {
            this.gotoInfo = gotoInfo;
        }


        private void Close()
        {
            Environment.Exit(0);
        }

        private async void Proceed()
        {
            ourPerson = new Person(FirstName, LastName, Email, BirthDate);
            int age = await Task.Run(() => ourPerson.Age());
            if (age < 0)
            {
                MessageBox.Show("Wrong data!You must be older than 0");
            }
            else if (age >= 135)
            {
                MessageBox.Show("Wrong data!Your must be younger than 135");
            }
            else
            {
                Task t1 = Task.Run(() => ourPerson.CalculateIsBirthday());
                Task t2 = Task.Run(() => ourPerson.CalculateIsAdult());
                Task t3 = Task.Run(() => ourPerson.CalculateChineseSign());
                Task t4 = Task.Run(() => ourPerson.CalculateSunSign());
                await t1;
                await t2;
                await t3;
                await t4;
                PersonSender.person = ourPerson;
                gotoInfo.Invoke();
            }
        }
        private bool CanExecute(object o)
        {
            return !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName) && !String.IsNullOrWhiteSpace(Email);
        }
    }
}
