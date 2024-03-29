﻿using LaxStats_Admin_panel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LaxStats_Admin_panel.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "League")
            {
                viewModel.SelectedViewModel = viewModel.leagueViewModel;
            }
            else if (parameter.ToString() == "Team")
            {
                viewModel.SelectedViewModel = viewModel.teamViewModel;
            }
            else if (parameter.ToString() == "AddLeague")
            {
                viewModel.SelectedViewModel = viewModel.createLeagueViewModel;
            }
        }
    }
}
