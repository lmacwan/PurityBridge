using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbraco7.Models
{
    public class ContactModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Message { get; set; }
    }
}