using System.ComponentModel.DataAnnotations;

namespace uploadImage.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
    }
}
