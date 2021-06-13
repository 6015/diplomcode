using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace diplom.Models
{
    public class Comment
    {
        
        public  int lot_id { get; set; }
        public int user_id { get; set; }
        [Key]
        public int comm_id { get; set; }
        public string comm_text { get; set; }
        public DateTime comm_date { get; set; }
    }
}
