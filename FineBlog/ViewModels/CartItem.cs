using FineBlog.Models;

namespace FineBlog.ViewModels
{
    public class CartItem
    {
        public Post post { get; set; }
        public int amount { get; set; }
    }
}
