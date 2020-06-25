using System;
using System.Collections.Generic;
using System.Linq;
using iSh.Entities;
using Xamarin.Forms;

namespace iSh.Forms
{
    public partial class Confirm : ContentPage
    {

        private readonly int _id;
        private readonly string _busca;
        public Provider UserProvider { get; set; }

        public Confirm(int id, string busca)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "Confirmar");

            _id = id;
            _busca = busca;

            UserProvider = Utils.GetProviders(busca).Where(e => e.Id == id).FirstOrDefault();
            LabelTipo.Text = UserProvider.UserProfile.Occupation.Description;
            UserPhoto.Source = ImageSource.FromUri(new Uri(UserProvider.UserProfile.Photo));
            LabelDistance.Text = UserProvider.DistanceKm.ToString();
            LabelName.Text = UserProvider.UserProfile.Name;
            LabelPoints.Text = UserProvider.UserProfile.Points.ToString();

        }

        void BtConfirmar_Clicked(System.Object sender, System.EventArgs e)
        {
        }

    }
}
