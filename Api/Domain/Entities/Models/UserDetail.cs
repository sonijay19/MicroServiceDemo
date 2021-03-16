using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Domain.Entities.Models
{
    public partial class UserDetail
    {
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string PhoneNumber { get; set; }
        public int UserTypeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual UserTypeStatus UserType { get; set; }
    }
}
