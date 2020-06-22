using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using iSh.Entities;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace iSh.Forms
{
    public partial class Result : ContentPage
    {

        private readonly int _professionId; 
        private readonly string _busca;
        //public IObservable<string> Tipo => _busca;
        //public ObservableCollection<Provider> ResultadoBusca { get; set; }
        public List<Provider> ResultadoBusca { get; set; }

        public Result(string busca, int professionId)
        {
            InitializeComponent();

            _busca = busca;
            _professionId = professionId;
            LabelTipoBusca.Text = _busca;
            ResultadoBusca = Utils.GetProviders(_busca);
            ListaBusca.ItemsSource = ResultadoBusca;
            NavigationPage.SetBackButtonTitle(this, "Home");
        }

        async protected void BtVoltar_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void ListaBusca_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var item = (Provider)e.SelectedItem;
                await Navigation.PushAsync(new Profile(item.Id, _busca), true);
            }
        }
    }
}
