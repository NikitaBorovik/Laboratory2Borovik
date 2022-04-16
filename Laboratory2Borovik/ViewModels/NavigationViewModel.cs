using Laboratory2Borovik.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory2Borovik.ViewModels
{
    
    internal class NavigationViewModel : BaseNavigationViewModel
    {
        
        public NavigationViewModel()
        {
            Navigate(NavigationTypes.Login);
        }

        protected override INavigatable CreateNewViewModel(NavigationTypes type)
        {
            switch (type)
            {
                case NavigationTypes.Login:
                    return new LoginViewModel(() => Navigate(NavigationTypes.Info));
                case NavigationTypes.Info:
                    return new InfoViewModel(() => Navigate(NavigationTypes.Login));
                default:
                    return null;
            }
        }

    }
}
