using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string ProfileImagePath { get; set; }
        
        public string UserId { get; set; }
       
    }
}
