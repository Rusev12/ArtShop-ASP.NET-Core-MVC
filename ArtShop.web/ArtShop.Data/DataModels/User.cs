using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ArtShop.Data.DataModels
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PostCode { get; set; }

        public string City { get; set; }

        public string StreetAddress { get; set; }

        public List<ArtProduct> ArtProducts { get; set; } = new List<ArtProduct>();
    }
}
