using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTBook.Models
{
    public class Book
    {
        [Key]
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }

        // khong tham chieu property nay voi column trong table Book
        [NotMapped]
        public string CategoryName { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }
        public string? ImgUrl { get; set; }
        public int StoreId { get; set; }
        public Store? Store { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        public virtual ICollection<Cart>? Carts { get; set; }

    }
}