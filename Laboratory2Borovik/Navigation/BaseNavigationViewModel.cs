using Laboratory2Borovik.Navigation;
using Laboratory2Borovik.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory2Borovik.Navigation
{
    
    internal abstract class BaseNavigationViewModel : INotifyPropertyChanged
    {
        private INavigatable viewModel;
        List<INavigatable> viewModels = new List<INavigatable>();

        public event PropertyChangedEventHandler PropertyChanged;
        public INavigatable ViewModel 
        { 
            get
            {
                return viewModel;
            }
            set
            {
                viewModel = value;
                OnPropertyChanged(nameof(ViewModel));
            }
        }
        

        internal void Navigate(NavigationTypes type)
        {
            if(ViewModel != null && ViewModel.ViewType == type)
            {
                return;
            }
            INavigatable viewModel = GetViewModel(type);
            if(viewModel == null)
            {
                return;
            }
            ViewModel = viewModel;
            
        }

        protected abstract INavigatable CreateNewViewModel(NavigationTypes type);

        private INavigatable GetViewModel(NavigationTypes type)
        {
            INavigatable viewModel = viewModels.FirstOrDefault(vm => vm.ViewType == type);
            if(viewModel != null)
            {
                return viewModel;
            }
            viewModel = CreateNewViewModel(type);

            viewModels.Add(viewModel);

            return viewModel;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
    enum NavigationTypes
    {
        Login = 1,
        Info = 2,
    }
}
