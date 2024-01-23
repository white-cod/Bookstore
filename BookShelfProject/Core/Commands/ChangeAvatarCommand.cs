using BookShelfProject.MVVM.ViewModels;
using Microsoft.Identity.Client;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.Core.Commands
{
    public class ChangeAvatarCommand : CommandBase
    {
        private readonly PersonalCabinetViewModel _personalCabinetViewModel;
        public ChangeAvatarCommand(PersonalCabinetViewModel personalCabinetViewModel)
        {
            _personalCabinetViewModel = personalCabinetViewModel;
        }
        public override void Execute(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                _personalCabinetViewModel.AvatarPath = openFileDialog.FileName;
            }
        }
    }
}
