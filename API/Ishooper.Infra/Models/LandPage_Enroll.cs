using System;
namespace Ishooper.Infra.Models
{
    public class LandPage_Enroll
    {

        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Telephone { get; set; } = string.Empty;

        public int Occupation { get; set; } = 0;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
