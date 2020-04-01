using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GSB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Antibiotiques : ContentPage
    {
        public Antibiotiques(int idCategorie)
        {
            InitializeComponent();

            recuperationAntibios(idCategorie);
        }
        public async void recuperationAntibios(int idCategorie)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            HttpClient wc = new HttpClient();
            HttpResponseMessage reponse = await wc.GetAsync(new Uri("https://asenut.000webhostapp.com/php/gsb/antibiotiques.php?idCateg="+idCategorie.ToString(), UriKind.Absolute));
            string json = reponse.Content.ReadAsStringAsync().Result;
            List<Antibio> uneListeAntibios = null;
            uneListeAntibios = JsonConvert.DeserializeObject<List<Antibio>>(json, settings);
            lvAntibiotiques.ItemsSource = uneListeAntibios.ToList();
        }
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            
            
        }

        private void lvAntibiotiques_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Antibio antibio = lvAntibiotiques.SelectedItem as Antibio;
            if(antibio is AntibioParKilo)
            {
                stackPoids.IsVisible = true;
                
            }
            else
            {
                stackPoids.IsVisible = false;
            }

            Button.IsVisible = true;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string message = "";
            if (lvAntibiotiques.SelectedItem != null)
            {
                bool kilosSaisi = false;
                Antibio antibio = lvAntibiotiques.SelectedItem as Antibio;
               
                if(antibio is AntibioParKilo)
                {
                    if(inpPoids.Text != null)
                    {
                        kilosSaisi = true;
                    }
                }
                else
                {
                    kilosSaisi = true;
                }
                if (kilosSaisi)
                {
                    int nombreParJour = antibio.getNombre();
                    
                    if(antibio is AntibioParKilo)
                    {
                        AntibioParKilo d = (AntibioParKilo)antibio;
                        message = "Il faut la quantité de : " + (d.getDoseKilo() * Convert.ToInt32(inpPoids.Text)).ToString() + " " + d.getUnite() + " " + nombreParJour.ToString()+" fois par jour";
                        
                    }
                    else
                    {
                        AntibioParPrise d = (AntibioParPrise)antibio;
                        message = "Il faut la quantité de : " + (d.getDosePrise()).ToString() + " " + d.getUnite() + " " + nombreParJour.ToString() + " fois par jour";
                    }
                }
                else
                {
                    message = "Veuillez saisir le nombre de kilos";
                }
            }
            else
            {
               message = "Veuillez choisir un antibiotique";
            }
            DependencyService.Get<IMessage>().LongTime(message);    
        }
    }
}