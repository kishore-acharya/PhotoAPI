using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAPI.Models
{
    public class ImageFile
    {
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }

    }
}
