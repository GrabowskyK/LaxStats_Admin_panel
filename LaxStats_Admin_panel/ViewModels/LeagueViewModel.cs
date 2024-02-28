using LaxStats_Admin_panel.Commands;
using LaxStats_Admin_panel.Model.DTO;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
            UpdateViewCommand = new UpdateViewCommand(mainViewModel);
            LoadLeagues();
        }

        private ObservableCollection<LeagueDTO> league;
        public ObservableCollection<LeagueDTO> League
        {
            get => league;
            set
            {
                league = value;
                OnPropertyChanged(nameof(League));
            }
        }

        private async Task LoadLeagues()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string url = "https://localhost:7006/League/GetLeagues";

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        List<LeagueDTO> leagues = JsonConvert.DeserializeObject<List<LeagueDTO>>(jsonResponse);
                        League = new ObservableCollection<LeagueDTO>(leagues);
                        Console.WriteLine(jsonResponse);
                    }
                    else
                    {
                        Console.WriteLine("Błąd: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Błąd: " + ex.Message);
                }
            }
        }

    }
}
