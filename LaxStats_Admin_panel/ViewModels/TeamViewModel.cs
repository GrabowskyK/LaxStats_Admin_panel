using LaxStats_Admin_panel.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LaxStats_Admin_panel.ViewModels
{
    public class TeamViewModel : BaseViewModel
    {
        private MainViewModel mainViewModel;

        public ICommand UpdateViewCommand { get; set; }

        public TeamViewModel(MainViewModel _mainViewModel)
        {
            mainViewModel = _mainViewModel;
            UpdateViewCommand = new UpdateViewCommand(mainViewModel);
            Test = new RelayCommand(TestFunc);
        }


        private ICommand _Test;
        public ICommand Test
        {
            get { return _Test; }
            set {
                _Test = value;
                UpdateViewCommand?.Execute(nameof(mainViewModel.SelectedViewModel));
            }
        }

        public void TestFunc(object obj)
        {
            Test = null;
        }
    }
}
