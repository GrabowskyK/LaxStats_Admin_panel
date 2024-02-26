using LaxStats_Admin_panel.Model;
using LaxStats_Admin_panel.Model.DTO;
using LaxStats_Admin_panel.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaxStats_Admin_panel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var gameDTO = new GameDTO
            {
                HomeTeamId = 1004,
                AwayTeamId = 1002,
                DateTime = "2024-12-20",
                Place = "Warszawa",
                LeagueId = 5
            };

            var httpClient = new HttpClient();
            var url = "https://localhost:7006/AddGame";

            try
            {
                var json = JsonConvert.SerializeObject(gameDTO);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, httpContent);

                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseContent);
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Error: {ex}");
            }
            finally
            {
                httpClient.Dispose();
            }
        }
        public static async Task Main(string[] args)
        {
            
        }

        private async void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            var playerDTO = new PlayerDTO
            {
                Name = "Kamil",
                Surname = "Grabowski",
                Born = "2001-08-01",
                ShirtNumber = 21,
                TeamId = 1004
            };

            var httpClient = new HttpClient();
            var url = "https://localhost:7006/Player/AddPlayerToTeam";

            try
            {
                var json = JsonConvert.SerializeObject(playerDTO);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, httpContent);

                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseContent);
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

        private async void AddLeague_Click(object sender, RoutedEventArgs e)
        {
            var leagueDTO = new LeagueDTO
            {
                Name = "Ekstraliga",
                Year = 2020
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

                Console.WriteLine(responseContent);
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

        private async void AddTeam_Click(object sender, RoutedEventArgs e)
        {
            var teamDTO = new TeamDTO
            {
                Name = "Ukraina",
                ShortName = "UK",
                LeagueId = 5
            };

            var httpClient = new HttpClient();
            var url = "https://localhost:7006/Team/AddTeam";

            try
            {
                var json = JsonConvert.SerializeObject(teamDTO);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, httpContent);

                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseContent);
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

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            Button button = new Button();
            button.Content = "Test"; // Załóżmy, że nazwa ligi jest przechowywana w polu "Name"
            button.Click += (sender, e) =>
            {
                // Obsługa zdarzenia kliknięcia przycisku
                // Możesz dodać tutaj kod reagujący na kliknięcie, na przykład wyświetlenie szczegółów ligi
            };

            // Dodanie przycisku do kontrolki ItemsControl
            itemsControl.Items.Add(button);
        }
    }

    public class GameDTO
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string DateTime { get; set; }
        public string Place { get; set; }
        public int LeagueId { get; set; }
    }
}