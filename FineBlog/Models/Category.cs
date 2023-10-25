using System.ComponentModel.DataAnnotations;

namespace FineBlog.Models
{
    public class Category
    {
            public int? CateID { get; set; }
        public string? catename { get; set; }
        public List<Post>? Posts { get; set; }
            public ApplicationUser? ApplicationUser { get; set; }


    }
}
