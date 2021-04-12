using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class UserBO
    {
        public int UserId { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User name is required. ")]
        public string UserName { get; set; }

        [Display(Name = "User Address")]
        [Required(ErrorMessage = "User Address is required.")]
        public string UserAddress { get; set; }

        [Display(Name = "User Email")]
        [Required(ErrorMessage = "User Email is required")]
        public string UserEmail { get; set; }

        [Display(Name = "User Phone")]
        [Required(ErrorMessage = "User Phone is required.")]
        public string UserPhone { get; set; }
    }
}
