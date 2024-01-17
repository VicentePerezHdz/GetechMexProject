using GetechMexProjecModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GetechMexProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ListaUsuarios : Window
    {
        public ListaUsuarios()
        {
            InitializeComponent();
            try
            {
                string apiBaseUrl = ConfigurationManager.AppSettings["ApiUrl"];

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                    var responseTask = client.GetAsync("DirectorioRestService");
                    responseTask.Wait();
                    if (responseTask.Result.IsSuccessStatusCode)
                    {
                        var content = responseTask.Result.Content;
                        var data = content.ReadAsStringAsync().Result;
                        List<Persona> listaUsuarios = JsonConvert.DeserializeObject<List<Persona>>(data);
                        tablaUsuarios.ItemsSource = listaUsuarios;
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }


    }
}