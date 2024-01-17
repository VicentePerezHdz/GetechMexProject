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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void botonGuardar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text.ToString();
            string apellidoPaterno = ApellidoPaterno.Text.ToString();
            string apellidoMaterno = ApellidoMaterno.Text.ToString();
            string identificacion = Identificacion.Text.ToString();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El campo de nombre es obligatorio!", "Alerta", MessageBoxButton.OK, MessageBoxImage.Information);
            }else if (string.IsNullOrEmpty(apellidoPaterno))
            {
                MessageBox.Show("El campo de apellido paterno es obligatorio!", "Alerta", MessageBoxButton.OK, MessageBoxImage.Information);

            }else if (string.IsNullOrEmpty(identificacion))
            {
                MessageBox.Show("El campo de identificacion es obligatorio!", "Alerta", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea dar de alta la persona?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {

                        string apiBaseUrl = ConfigurationManager.AppSettings["ApiUrl"];
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(apiBaseUrl);
                            var requestData = new
                            {
                                nombre = nombre,
                                apellidoPaterno = apellidoPaterno,
                                apellidoMaterno = apellidoMaterno,
                                identificacion = identificacion
                            };
                            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                            var responseTask = client.PostAsync("DirectorioRestService", content);
                            responseTask.Wait();
                            if (responseTask.Result.IsSuccessStatusCode)
                            {
                                var result1 = responseTask.Result;
                                txtNombre.Text = string.Empty;
                                ApellidoPaterno.Text = string.Empty;
                                ApellidoMaterno.Text = string.Empty;
                                Identificacion.Text = string.Empty;
                                MessageBox.Show("Se dio de alta la Persona", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo dar de alta la persona", "Alerta", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hubo un error al comunicar con la API", "Alerta", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }

                }
                else
                {

                }
            }
        }

        private void btnVerLista_Click(object sender, RoutedEventArgs e)
        {
            ListaUsuarios listausuarios = new ListaUsuarios();
            listausuarios.Show();
        }
    }
}