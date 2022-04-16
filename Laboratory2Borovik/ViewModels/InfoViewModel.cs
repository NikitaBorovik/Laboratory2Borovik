using Laboratory2Borovik.Models;
using Laboratory2Borovik.Navigation;
using Laboratory2Borovik.Sending;
using Laboratory2Borovik.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory2Borovik.ViewModels
{
    internal class InfoViewModel : INavigatable
    {
        public NavigationTypes ViewType => NavigationTypes.Info;
        private Action gotoLogin;
        private RelayCommand<object>? gotoLoginCommand;
        public string FirstName
        {
            get => PersonSender.person.FirstName;
        }
        public string LastName
        {
            get => PersonSender.person.LastName;
        }
        public string? Email
        {
            get => PersonSender.person.Email;
        }
        public string Birthday
        {
            get => PersonSender.person.Birthday.ToShortDateString();
        }
        public string ChineseSign
        {
            get => PersonSender.person.ChineseSign;
        }
        public string SunSign
        {
            get => PersonSender.person.SunSign;
        }
        public bool IsAdult
        {
            get => PersonSender.person.IsAdult;
        }
        public string IsBirthday
        {
            get
            {
                if (PersonSender.person.IsBirthday)
                {
                    return "Today is your birthday.\nHappy birthday!";
                }else
                {
                    return "Today is not your birthday";
                }
            }
            
        }
        public RelayCommand<object> GotoLoginCommand
        {
            get
            {
                return gotoLoginCommand ??= new RelayCommand<object>(_ => GotoLogin());
            }
        }

        public InfoViewModel(Action gotoLogin)
        {
            this.gotoLogin = gotoLogin;
        }

        
        private void GotoLogin()
        {
            gotoLogin.Invoke();
        }
        
    }
}
