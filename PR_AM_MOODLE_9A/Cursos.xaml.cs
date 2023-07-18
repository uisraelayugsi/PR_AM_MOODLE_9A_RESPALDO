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

namespace PR_AM_MOODLE_9A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cursos : ContentPage
    {

        public List<Curso> CursosList { get; set; }

        public class Curso
        {
            public int enrolid { get; set; }
            public int userid { get; set; }
            public int courseid { get; set; }
            public string lastname { get; set; }
            public string firstname { get; set; }
            public int category { get; set; }
            public string fullname { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string intro { get; set; }
        }

        public Cursos(string usuario)
        {
            InitializeComponent();

            var datos = JsonConvert.DeserializeObject<WebService.Usuario>(usuario);

            lblNombre.Text = "Estudiante: " + datos.firstname + " " + datos.lastname;
            lblId.Text = datos.id.ToString();

            obtener();



        }

        public async void obtener()
        {
            HttpClient client = new HttpClient();
            var contenido = await client.GetStringAsync("https://campusvirtual.rfd.org.ec/webservices/ws_curso.php?userid=" + lblId.Text);
            var cursos = JsonConvert.DeserializeObject<List<Curso>>(contenido);

            CursosList = cursos;
            ListCurso_ItemSelected.ItemsSource = CursosList;
        }
    }
}