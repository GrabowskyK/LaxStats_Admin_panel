using LaxStats_Admin_panel.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaxStats_Admin_panel.ViewModels
{
    public class LeagueViewModel : BaseViewModel
    {
        private MainViewModel mainViewModel;

        public ICommand UpdateViewCommand { get; set; }

        public LeagueViewModel(MainViewModel _mainViewModel) 
        {
            mainViewModel = _mainViewModel;
            TestV2 = new RelayCommand(Testv2Func);
            UpdateViewCommand = new UpdateViewCommand(mainViewModel);
        }

        private string _Napis;
        public string Napis
        {
            get
            {
                return _Napis;
            }
            set
            {
                _Napis = value;
                OnPropertyChanged(nameof(Napis));
            }
        }

        private ICommand _TestV2;
        public ICommand TestV2
        {
            get
            {
                Napis = "Polibuda";
                return _TestV2;
            }
            set
            {
                _TestV2 = value;
                UpdateViewCommand?.Execute(nameof(mainViewModel.SelectedViewModel));
            }
        }

        public void Testv2Func(object obj) 
        {
            TestV2 = null;
        }
    }
}
