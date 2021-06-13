using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace diplom.Models
{
    public class Lot
    {
        [Key]
        public int lot_id { get; set; }
        public int user_id { get; set; }
        public string lot_name { get; set; }
        public string lot_description { get; set; }
        public string lot_category { get; set; }
        public string lot_photo { get; set; }
        public DateTime lot_data { get; set; }
    }
}
