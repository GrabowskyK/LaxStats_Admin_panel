using LaxStats_Admin_panel.Commands;
using LaxStats_Admin_panel.Model.DTO;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LaxStats_Admin_panel.ViewModels
{
    public class CreateLeagueViewModel : BaseViewModel
    {
        private MainViewModel mainViewModel;
        private string leagueYear;
        private string leagueName;
        private ICommand createLeague;
        private bool createButtonEnable = false;
        private string errorText;

        public CreateLeagueViewModel(MainViewModel _mainViewModel)
        {
            mainViewModel = _mainViewModel;
            UpdateViewCommand = new UpdateViewCommand(mainViewModel);
            CreateLeague = new RelayCommand(AddLeagueToDatabase);
        }

        public ICommand UpdateViewCommand { get; set; }
        public ICommand CreateLeague
        {
            get => createLeague;
            set
            {
                createLeague = value;
                OnPropertyChanged(nameof(CreateLeague));
            }
        }

        public string LeagueYear
        {
            get => leagueYear;
            set{
                leagueYear = value;
                OnPropertyChanged(nameof(LeagueYear));
                if(string.IsNullOrEmpty(leagueYear))
                {
                    CreateButtonEnable = false;
                }
                if (!string.IsNullOrEmpty(leagueYear) && !string.IsNullOrEmpty(leagueName))
                {
                    CheckIsYearNumber(leagueYear);
                }
            }
        }
        
        public string LeagueName
        {
            get => leagueName;
            set
            {
                leagueName = value;
                OnPropertyChanged(nameof(leagueName));
                if (string.IsNullOrEmpty(leagueName))
                {
                    CreateButtonEnable = false;
                }
                else if (!string.IsNullOrEmpty(leagueYear) && !string.IsNullOrEmpty(leagueName))
                {
                    CheckIsYearNumber(leagueYear);
                }
                
            }
        }

        
        public bool CreateButtonEnable 
        {  
            get => createButtonEnable;
            set {
                createButtonEnable = value;
                OnPropertyChanged(nameof(CreateButtonEnable));
               }
        }
        
        public string ErrorText
        {
            get => errorText;
            set
            {
                errorText = value;
                OnPropertyChanged(nameof(ErrorText));
            }
        }

        private async void AddLeagueToDatabase(object obj)
        {
            var leagueDTO = new LeagueDTO
            {
                Name = leagueName,
                Year = int.Parse(leagueYear)
            };

            var httpClient = new HttpClient();
            var url = "https://localhost:7006/League/AddLeague";

            try
            {
                var json = JsonConvert.SerializeObject(leagueDTO);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, httpContent);

                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                MessageBox.Show("Successfully added");
                UpdateViewCommand.Execute("League");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            finally
            {
                httpClient.Dispose();
            }
        }

        private void CheckIsYearNumber(string year)
        {
            if (string.IsNullOrEmpty(year))
            {
                ErrorText = string.Empty;
                CreateButtonEnable = false;
            }
            else if (int.TryParse(year, out int n) == false && !string.IsNullOrEmpty(year))
            {
                CreateButtonEnable = false;
                ErrorText = "Number is not a number!";
            }
            else
            {
                if (n <= 0)
                {
                    ErrorText = "Number has a wrong value!";
                }
                else
                {
                    CreateButtonEnable = true;
                    ErrorText = "";
                }
            }
        }

    }
}
