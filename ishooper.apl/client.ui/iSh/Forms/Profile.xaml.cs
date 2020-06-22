using System;
using System.Collections.Generic;
using iSh.Entities;
using Xamarin.Forms;
using System.Linq;

namespace iSh.Forms
{
    public partial class Profile : ContentPage
    {

        private readonly int  _id;
        private readonly string _busca;
        public Provider UserProvider { get; set; }

        public Profile(int id, string busca)
        {
            InitializeComponent();

            _id = id;
            _busca = busca;
            NavigationPage.SetBackButtonTitle(this, "Perfil");

            UserProvider = Utils.GetProviders(busca).Where(e => e.Id == id).FirstOrDefault();
            LabelTipo.Text = UserProvider.UserProfile.Occupation.Description;
            UserPhoto.Source = ImageSource.FromUri(new Uri(UserProvider.UserProfile.Photo));
            LabelDistance.Text = UserProvider.DistanceKm.ToString();
            LabelName.Text = UserProvider.UserProfile.Name;
            LabelPoints.Text = UserProvider.UserProfile.Points.ToString();
            LabelCreatedDate.Text = UserProvider.UserProfile.CreatedDate.ToString("dd/MM/yyyy");
            LabelLanguages.Text = UserProvider.UserProfile.Languages;
            LabelProfessionalQualification.Text = UserProvider.UserProfile.ProfessionalQualification;
            LabelCourses.Text = UserProvider.UserProfile.Courses;

            ListaEvaluation.ItemsSource = Utils.GetEvaluations();


        }

        void BtContratar_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
