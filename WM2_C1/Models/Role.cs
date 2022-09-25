using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WM2_C1
{
    public partial class Role
    {

        public Role()
        {
            Users = new HashSet<User>();
        }

        [Display(Name = "ID")]
        public int RoleId { get; set; }

        [Display(Name = "Роль")]
        public string? RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
