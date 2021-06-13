using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace diplom.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_surname { get; set; }
        public string user_password { get; set; }
        public string user_avatar { get; set; }
        private string user_telegram;
        private string user_category;
    }
}
