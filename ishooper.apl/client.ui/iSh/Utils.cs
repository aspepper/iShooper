using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iSh.Entities;
using Xamarin.Essentials;
using System.Linq;
using Xamarin.Forms;

namespace iSh
{
    public class Utils
    {
        public Utils()
        {
        }

        #region Busca Providers
        //private ObservableCollection<Provider> GetProviders()
        static public List<Provider> GetProviders(string busca)
        {
            string profession = busca switch
            {
                "Mecânicos" => "Mecânico",
                "Encanadores" => "Encanador",
                "Eletricistas" => "Eletricista",
                "Pedreiros" => "Pedreiro",
                "Pintores" => "Pintor",
                "Babas" => "Baba",
                "Professores" => "Professor",
                _ => busca,
            };

            var lista = new List<Provider>() {
                new Provider
                {
                    Id = 1,
                    UserProfile =  new User
                    {
                        Id = 1,
                        Name = "Alex Pimenta",
                        Latitude = -23.9457388,
                        Longitude = -46.3344748,
                        Occupation = new Profession
                        {
                             Id = 1,
                             Description = profession
                        },
                        Photo = "http://blob.ishooper.com/profiles/alex.png",
                        Points = 9.73,
                        CreatedDate = new DateTime(2020, 05, 31),
                        Languages = "Inglês",
                        ProfessionalQualification = "Engenharia",
                        Courses = "Acabamentos Senai"
                    },
                    DistanceKm = 0
                },
                new Provider
                {
                    Id = 2,
                    UserProfile =  new User
                    {
                        Id = 2,
                        Name = "Claudio Cunha",
                        Latitude = -23.966344,
                        Longitude = -46.323883,
                        Occupation = new Profession
                        {
                             Id = 1,
                             Description = profession
                        },
                        Photo = "http://blob.ishooper.com/profiles/ClaudioCunha.png",
                        Points = 9.9,
                        CreatedDate = new DateTime(2020, 05, 31),
                        Languages = "Inglês, Espanhol",
                        ProfessionalQualification = "Eletrica",
                        Courses = "Eletrica Senai"
                    },
                    DistanceKm = 0
                },
                new Provider
                {
                    Id = 3,
                    UserProfile =  new User
                    {
                        Id = 2,
                        Name = "Bruno Silvestre",
                        Latitude = -23.976344,
                        Longitude = -46.313883,
                        Occupation = new Profession
                        {
                             Id = 1,
                             Description = profession
                        },
                        Photo = "http://blob.ishooper.com/profiles/BrunoSilvestre.png",
                        Points = 9.2,
                        CreatedDate = new DateTime(2020, 05, 31),
                        Languages = "",
                        ProfessionalQualification = "Auxiliar de Pedreiro",
                        Courses = "Construção Civil Senai"
                    },
                    DistanceKm = 0
                }
            };

            CalculateAllDistance(ref lista);
            //return new ObservableCollection<Provider>(lista);
            return lista.OrderBy(e => e.DistanceKm).ToList();

        }

        static private void CalculateAllDistance(ref List<Provider> lista)
        {
            foreach (Provider p in lista)
            {
                p.DistanceKm = GetDistanceKm(new Location(p.UserProfile.Latitude, p.UserProfile.Longitude)).Result;
            }
        }

        static private async Task<double> GetDistanceKm(Location localizationFrom)
        {
            double dist;
            try
            {
                var locationTo = await Geolocation.GetLastKnownLocationAsync();

                if (locationTo == null)
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, new TimeSpan(0, 0, 3));
                    locationTo = await Geolocation.GetLocationAsync(request);
                }

                dist = Math.Round(Location.CalculateDistance(localizationFrom, locationTo, DistanceUnits.Kilometers), 3);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível obter a sua localização. Altere as permissões do seu aplicativo para que consiga obter a sua localização. (" + ex.Message + ")");
            }

            return dist;
        }
        #endregion

        #region Lista Avaliações
        static public List<Evaluation> GetEvaluations()
        {
            return new List<Evaluation>
            {
                new Evaluation
                {
                    Id = 1,
                    UserProfile = new User
                    {
                        Id = 1,
                        Name = "André Luiz",
                        Photo = "http://blob.ishooper.com/profiles/user0.jpg"
                    },
                    Commendation001 = ImageSource.FromFile("Elogio_Curtiu.png"),
                    Commendation002 = ImageSource.FromFile("Elogio_Pontualidade.png"),
                    Commendation003 = ImageSource.FromFile("Elogio_Satisfacao.png"),
                    Commendation004 = ImageSource.FromFile("Elogio_Rapidez.png"),
                    Comments = "Trabalho com seriedade, limpeza e rapidez."
                },
                new Evaluation
                {
                    Id = 1,
                    UserProfile = new User
                    {
                        Id = 1,
                        Name = "Maria Lucia",
                        Photo = "http://blob.ishooper.com/profiles/user1.jpg"
                    },
                    Commendation001 = ImageSource.FromFile("Elogio_Curtiu.png"),
                    Commendation002 = ImageSource.FromFile("Elogio_Pontualidade.png"),
                    Commendation003 = ImageSource.FromFile("Elogio_Satisfacao.png"),
                    Commendation004 = ImageSource.FromFile("Elogio_Excelente.png"),
                    Comments = "Pontual e execução rápida. Vale o preço."
                }
            };
        }
        #endregion

    }
}
