using System.Collections.ObjectModel;
using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Azure;
using Azure.Core;
using BookShelf.MVVM.ViewModel;


namespace BookShelf.Core
{
    public static class PagesHistoryManager
    {
        public static List<BaseViewModel> pagesHistory { get; } = new List<BaseViewModel>();
        public static void RewriteHistory(BaseViewModel CurrentViewModel)
        {
            if(pagesHistory.Count > 1)
            {
                int CurrentPageIndex = pagesHistory.IndexOf(CurrentViewModel);

                if(CurrentPageIndex < pagesHistory.Count-1 && CurrentPageIndex != -1)
                {
                    pagesHistory.RemoveRange(CurrentPageIndex + 1, (pagesHistory.Count - CurrentPageIndex - 1));
                }
            }
        }
    }
}
