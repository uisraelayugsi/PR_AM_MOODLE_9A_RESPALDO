using Newtonsoft.Json;
using PR_AM_MOODLE_9A.WebService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PR_AM_MOODLE_9A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Foro : ContentPage
    {
        public ObservableCollection<datosForo> dForo { get; set; }

        public class datosForo
        {
            public int id { get; set; }
            public int discussion { get; set; }
            public int parent { get; set; }
            public int userid { get; set; }
            public int created { get; set; }
            public int modified { get; set; }
            public int mailed { get; set; }
            public string subject { get; set; }
            public string message { get; set; }
            public int messageformat { get; set; }
            public int messagetrust { get; set; }
            public string attachment { get; set; }
            public int totalscore { get; set; }
            public int mailnow { get; set; }
            public int deleted { get; set; }
            public int privatereplyto { get; set; }
            public int wordcount { get; set; }
            public int charcount { get; set; }
        }


        public Foro(string usuario)
        {
            InitializeComponent();

            var datos = JsonConvert.DeserializeObject<PR_AM_MOODLE_9A.WebService.Usuario>(usuario);

            lblNombre.Text = "Estudiante: " + datos.firstname + " " + datos.lastname;
            lblId.Text = datos.id;

            obtener();



        }

        public async void obtener()
        {
            HttpClient client = new HttpClient();
            var contenido = await client.GetStringAsync("https://campusvirtual.rfd.org.ec/webservices/ws_foros.php?userid=" + lblId.Text);
            var foros = JsonConvert.DeserializeObject<List<datosForo>>(contenido);

            dForo = new ObservableCollection<datosForo>(foros);
            ListForo_ItemSelected.ItemsSource = dForo;

        }
    }
}