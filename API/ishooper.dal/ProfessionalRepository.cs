using System;
using System.Collections.Generic;
using System.Linq;
using Ishooper.Dal.Enuns;
using Ishooper.Dal.Interfaces;
using Ishooper.Dal.Models;
using MongoDB.Driver;

namespace Ishooper.Dal
{
    public class ProfessionalRepository: IDisposable
    {

        protected IMongoContext _context;
        protected IMongoCollection<User> DbSetUser;
        protected IMongoCollection<UserProfession> DbSetUserProfession;
        protected IMongoCollection<UserCurrentLocation> DbSetUserCurrentLocation;

        public ProfessionalRepository(IMongoContext context)
        {
            _context = context;
            DbSetUser = _context.GetCollection<User>("user");
            DbSetUserProfession = _context.GetCollection<UserProfession>("userprofession");
            DbSetUserCurrentLocation = _context.GetCollection<UserCurrentLocation>("usercurrentlocation");
        }

        public IQueryable<Professional> Search(string professionId, double longitude, double latitude, int maxdistanceKm)
        {
            var r = from t1 in DbSetUserCurrentLocation.AsQueryable()
                    join t2 in DbSetUser.AsQueryable() on t1.UserId equals t2.Id
                    join t3 in DbSetUserProfession.AsQueryable() on new { key1 = t1.UserId, key2 = professionId }
                                                             equals new { key1 = t3.UserId, key2 = t3.ProfessionId.ToString() }
                    where t2.Profile == (int)ProfileType.Professional
                    && Distance(t1.Latitude, t1.Longitude, latitude, longitude, "K") <= maxdistanceKm
                    select new Professional()
                    {
                        ProfessionalId = t2.Id.ToString(),
                        Profession = t2.Occupation.Description,
                        Calls = t2.Calls,
                        Name = t2.Name,
                        Photo = t2.Photo,
                        Points = t2.Points,
                        Price = t3.Price
                    };

            return r;
        }


        /// <summary>
        /// Calcula a distância entre dois pontos
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lon1"></param>
        /// <param name="lat2"></param>
        /// <param name="lon2"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        private double Distance(double lat1, double lon1, double lat2, double lon2, String unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(Deg2Rad(lat1)) * Math.Sin(Deg2Rad(lat2)) + Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) * Math.Cos(Deg2Rad(theta));
            dist = Math.Acos(dist);
            dist = Rad2Deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == "K")
            {
                dist *= 1.609344;
            }
            else if (unit == "N")
            {
                dist *= 0.8684;
            }

            return (dist);
        }

        /*:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::*/
        /*::    This function converts decimal degrees to radians                         :*/
        /*:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::*/
        private static double Deg2Rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        /*:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::*/
        /*::    This function converts radians to decimal degrees                         :*/
        /*:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::*/
        private static double Rad2Deg(double rad)
        {
            return (rad * 180 / Math.PI);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
