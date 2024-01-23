using BookShelfProject.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BookShelfProject.Core.Converters
{
    public class DataToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PersonalCabinetViewModel vm = (PersonalCabinetViewModel)value;

            if (string.IsNullOrEmpty(vm.Username) ||
               string.IsNullOrEmpty(vm.Email) ||
               !vm.BirthDate.HasValue)
            {
                return false;
            }
            else return true;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
