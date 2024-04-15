using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Data.Models
{
    public class Icerik
    {
        [Key]
        public int IcerikId { get; set; }
        public string IcerikName { get; set; }

        public string IcerikConn { get; set; }
        public string IcerikDescription { get; set; }

        public string ImageURL { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
