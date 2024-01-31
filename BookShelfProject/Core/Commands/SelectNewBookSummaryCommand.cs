using BookShelfProject.MVVM.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.Core.Commands
{
    public class SelectNewBookSummaryCommand : CommandBase
    {
        private readonly AddBookViewModel _addBookViewModel;
        public SelectNewBookSummaryCommand(AddBookViewModel addBookViewModel)
        {
            _addBookViewModel = addBookViewModel;
        }
        public override void Execute(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                _addBookViewModel.BookSummaryPath = openFileDialog.FileName;
            }
        }
    }
}
