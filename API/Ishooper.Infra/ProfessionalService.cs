using System;
using System.Linq;
using data = Ishooper.Dal;
using Ishooper.Infra.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Ishooper.Infra
{
    public class ProfessionalService
    {
        private readonly IConfiguration _configuration;

        public ProfessionalService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IQueryable<Professional> Search(string professionId, double longitude, double latitude, int maxdistanceKm)
        {
            using var context = new data.MongoContext(_configuration);
            using var record = new data.ProfessionalRepository(context);
            try
            {
                List<Professional> result = record.Search(professionId, longitude, latitude, maxdistanceKm).Select(p => new Professional()
                {
                    Name = p.Name,
                    Profession = p.Profession,
                    Calls = p.Calls,
                    ProfessionalId = p.ProfessionalId,
                    Photo = p.Photo,
                    Points = p.Points,
                    Price = p.Price
                }).ToList();

                return result.AsQueryable();
            }
            catch (Exception e)
            {
                (new LogErrorService(_configuration)).Insert(e);
                return null;
            }
        }


    }
}
