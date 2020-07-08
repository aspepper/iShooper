using System;
using Ishooper.Infra.Models;
using data = Ishooper.Dal;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Collections.Generic;

namespace Ishooper.Infra
{
    public class ProfessionService
    {

        private readonly IConfiguration _configuration;

        public ProfessionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Profession Select(string Id)
        {
            using var context = new data.MongoContext(_configuration);
            using var record = new data.ProfessionRepository(context);
            try
            {
                var result = record.GetById(Id).Result;

                return new Profession
                {
                    Id = result.Id.ToString(),
                    Description = result.Description,
                    Status = result.Status,
                    CreatedDate = result.CreatedDate,
                    ModifiedDate = result.ModifiedDate
                };
            }
            catch (Exception e)
            {
                (new LogErrorService(_configuration)).Insert(e);
                return null;
            }
        }

        public IQueryable<Profession> GetAll()
        {
            using var context = new data.MongoContext(_configuration);
            using var record = new data.ProfessionRepository(context);
            try
            {
                List<Profession> result = record.GetList().Select(p => new Profession()
                {
                    Id = p.Id.ToString(),
                    Description = p.Description,
                    Status = p.Status,
                    Administrative = p.Administrative,
                    CreatedDate = p.CreatedDate,
                    ModifiedDate = p.ModifiedDate
                }).ToList();

                return result.AsQueryable();
            }
            catch (Exception e)
            {
                (new LogErrorService(_configuration)).Insert(e);
                return null;
            }
        }

        public IQueryable<Profession> GetComercialList()
        {
            using var context = new data.MongoContext(_configuration);
            using var record = new data.ProfessionRepository(context);
            try
            {
                List<Profession> result = record.GetComercialList().Select(p => new Profession()
                {
                    Id = p.Id.ToString(),
                    Description = p.Description,
                    Status = p.Status,
                    Administrative = p.Administrative,
                    CreatedDate = p.CreatedDate,
                    ModifiedDate = p.ModifiedDate
                }).ToList();

                return result.AsQueryable();
            }
            catch (Exception e)
            {
                (new LogErrorService(_configuration)).Insert(e);
                return null;
            }
        }

        public IQueryable<Profession> GetAdminlList()
        {
            using var context = new data.MongoContext(_configuration);
            using var record = new data.ProfessionRepository(context);
            try
            {
                List<Profession> result = record.GetAdminList().Select(p => new Profession()
                {
                    Id = p.Id.ToString(),
                    Description = p.Description,
                    Status = p.Status,
                    Administrative = p.Administrative,
                    CreatedDate = p.CreatedDate,
                    ModifiedDate = p.ModifiedDate
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
