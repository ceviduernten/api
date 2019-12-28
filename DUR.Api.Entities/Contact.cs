using System;
using System.Collections.Generic;
using DUR.Api.Entities.Default;

namespace DUR.Api.Entities
{
    public class Contact : Base
    {
        public Guid IdContact { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Stress { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

    }
}
