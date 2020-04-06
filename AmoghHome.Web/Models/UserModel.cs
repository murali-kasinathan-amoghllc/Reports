using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmoghHome.Web.Models
{
    public class UserModel
    {
        //[Required(ErrorMessage = "Please enter Email Id.")]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Please enter password.")]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        public string Password { get; set; }
    }
}