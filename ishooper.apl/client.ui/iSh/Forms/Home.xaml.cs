using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iSh.Forms
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "Home");
        }

        async void ImageButton_Clicked(Object sender, EventArgs args)
        {
            ImageButton botao = (ImageButton)sender;
            string busca = "";
            int professionId = 0;

            if (botao.Id == btProf01.Id) { busca = "Mecânicos"; professionId = 1; }
            if (botao.Id == btProf02.Id) { busca = "Mecânico de Ar Condicionados"; professionId = 2; }
            if (botao.Id == btProf03.Id) { busca = "Encanadores"; professionId = 3; }
            if (botao.Id == btProf04.Id) { busca = "Eletricistas"; professionId = 4; }
            if (botao.Id == btProf05.Id) { busca = "Pedreiros"; professionId = 5; }
            if (botao.Id == btProf06.Id) { busca = "Pintores"; professionId = 6; }
            if (botao.Id == btProf07.Id) { busca = "Babas"; professionId = 7; }
            if (botao.Id == btProf08.Id) { busca = "Professores"; professionId = 8; }

            //Application.Current.MainPage = new NavigationPage(new Result(busca, professionId));
            await Navigation.PushAsync(new Result(busca, professionId));
        }

        async void BtBuscar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Result(txtBusca.Text, 0), true);
        }

    }
}
