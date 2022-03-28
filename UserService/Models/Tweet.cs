using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models
{
    public class Tweet
    {
        public Tweet()
        {
            reactions = new List<Reaction>();
            likes = new List<Like>();
            user = new User();
        }

        public int tweetID { get; set; }
        public string text { get; set; }
        public DateTime uploadTime { get; set; }
        public User user { get; set; }
        public List<Like> likes { get; set; }
        public List<Reaction> reactions { get; set; }


    }
}
