using BookShelfProject.MVVM.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.Core.Commands
{
    public class EditBookSummaryCommand : CommandBase
    {
        private readonly EditBookViewModel _editBookViewModel;
        public EditBookSummaryCommand(EditBookViewModel editBookViewModel)
        {
            _editBookViewModel = editBookViewModel;
        }
        public override void Execute(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                _editBookViewModel.BookSummaryPath = openFileDialog.FileName;
            }
        }
    }
}
