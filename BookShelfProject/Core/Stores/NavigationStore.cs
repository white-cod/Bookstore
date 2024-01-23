using BookShelfProject.Context;
using BookShelfProject.Core.Services;
using BookShelfProject.MVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShelfProject.Core.Stores
{
    public class NavigationStore
    {
        public event Action CurrentViewModelChanged;
        public List<ViewModelBase> ViewModelsHistory { get; }

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel 
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public NavigationStore()
        {
            ViewModelsHistory = new List<ViewModelBase>();
        }

        private void OnCurrentViewModelChanged()
        {
             CurrentViewModelChanged?.Invoke();
        }

        public void NavigatePrevious()
        {
            if(ViewModelsHistory.Count > 0)
            {
                int CurrentPageIndex = ViewModelsHistory.IndexOf(CurrentViewModel);
                if (CurrentPageIndex > 0)
                {
                    CurrentViewModel = ViewModelsHistory[CurrentPageIndex - 1];
                }             
            }
        }
        public void NavigateNext()
        {
            if (ViewModelsHistory.Count > 1)
            {
                int CurrentPageIndex = ViewModelsHistory.IndexOf(CurrentViewModel);
                if((ViewModelsHistory.Count - 1 - CurrentPageIndex) > 0) 
                {
                    CurrentViewModel = ViewModelsHistory[CurrentPageIndex+1];
                }
            }
        }
        public void RewriteViewModelsHistory()
        {
            if (ViewModelsHistory.Count > 1) 
            {
                int CurrentPageIndex = ViewModelsHistory.IndexOf(CurrentViewModel);

                if (CurrentPageIndex >= 0 && CurrentPageIndex < ViewModelsHistory.Count-1) 
                {
                    ViewModelsHistory.RemoveRange(CurrentPageIndex + 1, ViewModelsHistory.Count - CurrentPageIndex - 1);
                }
            }
        }
    }
}
