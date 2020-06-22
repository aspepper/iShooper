using System;
namespace iSh.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Points { get; set; }
        public string Photo { get; set; }
        public Profession Occupation { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Languages { get; set; }
        public string ProfessionalQualification { get; set; }
        public string Courses { get; set; }

        public User()
        { }
    }
}
