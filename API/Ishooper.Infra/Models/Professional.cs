using System;
namespace Ishooper.Infra.Models
{
    public class Professional
    {

        public string ProfessionalId { get; set; } = string.Empty;

        public string Photo { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Profession { get; set; } = string.Empty;

        public int Calls { get; set; } = 0;

        public double Points { get; set; } = 0;

        public double Price { get; set; } = 0;

    }
}
