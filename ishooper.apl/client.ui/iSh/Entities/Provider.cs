using System;
namespace iSh.Entities
{
    public class Provider
    {

        public int Id { get; set; }
        public User UserProfile { get; set; }
        public double DistanceKm { get; set; }

        public Provider()
        {
        }
    }
}
