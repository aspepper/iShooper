using data = Ishooper.Dal;
using Ishooper.Infra.Models;
using Microsoft.Extensions.Configuration;
using System;
using Ishooper.Dal;

namespace Ishooper.Infra
{
    public class LandPage_EnrollService
    {

        private readonly IConfiguration _configuration;

        public LandPage_EnrollService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Insert(LandPage_Enroll record)
        {
            if (record is null) { return string.Empty; }
            var context = new MongoContext(_configuration);
            var lpEnrollRec = new data.LandPage_EnrollRepository(context);

            var recSave = new data.Models.LandPage_Enroll
            {
                Name = record.Name,
                Email = record.Email,
                Telephone = record.Telephone,
                Occupation = record.Occupation,
                CreatedDate = DateTime.Now
            };

            var recLoad = lpEnrollRec.GetBy("email", record.Email).Result;
            if (recLoad == null)
            {
                _ = lpEnrollRec.Add(recSave);
            }
            else
            {
                recSave.Id = recLoad.Id;
                lpEnrollRec.Update(recSave.Id.ToString(), recSave);
            }
            
            _ = context.SaveChanges();

            return lpEnrollRec.GetBy("email", record.Email).Result.Id.ToString();
        }

    }
}
