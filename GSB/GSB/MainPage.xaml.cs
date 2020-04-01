using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;

namespace GSB
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            recuperation();
        }

        public List<Categorie> lesCategories { get; set; }


       


        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            
        }

        private void lvCategories_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Categorie laCateg = lvCategories.SelectedItem as Categorie;
            Navigation.PushAsync(new Antibiotiques(laCateg.getId()) { 
                Title = laCateg.getLibelle()
            });
        }

        public async void recuperation()

        {
           HttpClient wc = new HttpClient();
           HttpResponseMessage reponse = await wc.GetAsync(new Uri("https://asenut.000webhostapp.com/php/gsb/categories.php", UriKind.Absolute));
           string json = reponse.Content.ReadAsStringAsync().Result;
            List<Categorie> unelisteCategories = null;
           unelisteCategories = JsonConvert.DeserializeObject<List<Categorie>>(json);
            lesCategories = unelisteCategories;
           lvCategories.ItemsSource = unelisteCategories.ToList();
               
        }


        private void CategoriesSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = CategoriesSearchBar.Text;
            List<Categorie> suggestions = lesCategories.Where(c => c.getLibelle().ToLower().Contains(keyword.ToLower())).ToList<Categorie>();
            lvCategories.ItemsSource = suggestions.ToList();
        }

        private void CategoriesSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            string keyword = CategoriesSearchBar.Text;
            List<Categorie> suggestions =lesCategories.Where(c => c.getLibelle().ToLower().Contains(keyword.ToLower())).ToList<Categorie>();
            lvCategories.ItemsSource = suggestions.ToList();
        }
    }
}
