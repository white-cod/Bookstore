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


namespace BookShelf.Core.Managers
{
    public static class PagesHistoryManager // Support class for the pages history in the application
    {
        public static List<BaseViewModel> pagesHistory { get; } = new List<BaseViewModel>();
        // RewriteHistory() method rewrites the page history if the user goes back a few pages in the history and decides to go to a completely different page
        public static void RewriteHistory(BaseViewModel CurrentViewModel)
        {
            if (pagesHistory.Count > 1) // Checks if there is more than 1 page, if not just there is no need to rewrite history
            {
                int CurrentPageIndex = pagesHistory.IndexOf(CurrentViewModel); // Get the current page index(the page from which one the user goes to another page)

                if (CurrentPageIndex < pagesHistory.Count - 1 && CurrentPageIndex != -1) // With the current index just delete previous history from the current index + 1 and to the end of the history list 
                {
                    pagesHistory.RemoveRange(CurrentPageIndex + 1, pagesHistory.Count - CurrentPageIndex - 1);
                }
            }
        }
    }
}
