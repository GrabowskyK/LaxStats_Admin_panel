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
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }
        public LeagueViewModel leagueViewModel { get;}
        public CreateLeagueViewModel createLeagueViewModel { get; }
        public TeamViewModel teamViewModel { get; }
        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            leagueViewModel = new LeagueViewModel(this);
            createLeagueViewModel = new CreateLeagueViewModel(this);
            teamViewModel = new TeamViewModel(this);
        }
    }
}
