using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models
{
    public class Following
    {
        [Key]
        public int FollowingID { get; set; }
        public int UserID_1 { get; set; }
        public int UserID_2 { get; set; }

    }
}
