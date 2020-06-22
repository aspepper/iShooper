using System.Linq;
using Ishooper.Dal.Interfaces;
using Ishooper.Dal.Models;
using MongoDB.Driver;

namespace Ishooper.Dal
{
    public class LandPage_EnrollRepository : BaseRepository<LandPage_Enroll>, ILandPage_EnrollRepository
    {

        public LandPage_EnrollRepository(IMongoContext context) : base(context)
        {

        }


    }
}
