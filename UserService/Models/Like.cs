using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models
{
    public class Like
    {
        public Like()
        {

        }

        public int likeID { get; set; }
        public int tweetID { get; set; }
        public int userID { get; set; }

    }
}
