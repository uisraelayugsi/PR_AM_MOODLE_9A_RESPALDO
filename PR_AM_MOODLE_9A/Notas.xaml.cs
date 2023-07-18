using Newtonsoft.Json;
using PR_AM_MOODLE_9A.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static PR_AM_MOODLE_9A.Foro;

namespace PR_AM_MOODLE_9A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notas : ContentPage
    {

        public Calificaciones[] DatosCalificaciones { get; set; }

        public class Calificaciones
        {
            [JsonProperty("finalgrade")]
            public string FinalGrade { get; set; }

            [JsonProperty("itemname")]
            public string Materia { get; set; }

            [JsonProperty("0")]
            public string Valor0 { get; set; }

            [JsonProperty("1")]
            public int Valor1 { get; set; }
        }


        public Notas(string usuario)
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
            var contenido = await client.GetStringAsync("https://campusvirtual.rfd.org.ec/webservices/ws_notas.php?userid=" + lblId.Text);
            var notas = JsonConvert.DeserializeObject<List<Calificaciones>>(contenido);

            DatosCalificaciones = notas.ToArray();
            ListNotas_ItemSelected.ItemsSource = DatosCalificaciones;
        }
    }
}