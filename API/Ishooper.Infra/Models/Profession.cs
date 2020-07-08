using System;
using System.Collections.Generic;
using System.Text;

namespace Ishooper.Infra.Models
{
    public class Profession
    {

        public string Id { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool Status { get; set; } = true;

        public bool Administrative { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

    }
}
