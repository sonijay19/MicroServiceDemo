using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Domain.Entities.Models
{
    public partial class UserTypeStatus
    {
        public UserTypeStatus()
        {
            UserDetails = new HashSet<UserDetail>();
        }

        public int TypeId { get; set; }
        public string StatusCode { get; set; }

        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
