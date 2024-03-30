using System;
using System.Collections.Generic;

namespace Api_Smart_Counters.Models
{
    public partial class User
    {
        public User()
        {
            Devices = new HashSet<Device>();
        }

        public int IdUsers { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string PasswordUser { get; set; } = null!;
        public string EMail { get; set; } = null!;

        public virtual ICollection<Device> Devices { get; set; }
    }
}
