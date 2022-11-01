using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MangersDAL.Models
{
    public class User : IdentityUser
    {
        [Key]
        public override string UserName { get; set; }
        public double Balance { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
        public List<Manga> History { get; set; }
        public string AvatarPicture { get; set; }
    }
}
