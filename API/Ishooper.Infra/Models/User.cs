using System;
using System.Collections.Generic;
using System.Text;

namespace Ishooper.Infra.Models
{
    public class User
    {

        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string UserLogon { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Telephone { get; set; }

        public string Gender { get; set; }

        public int Profile { get; set; } = 0;

        public Profession Occupation { get; set; } = new Profession();

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        public DateTime DeletedDate { get; set; } = DateTime.MinValue;

        public string UrlPhoto { get; set; } = string.Empty;

    }
}
