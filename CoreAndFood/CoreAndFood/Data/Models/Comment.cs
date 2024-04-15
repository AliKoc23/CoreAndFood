namespace CoreAndFood.Data.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string CommentUserName { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }

        public bool CommentStatus { get; set; }


        public int IcerikId { get; set; }

        public virtual Icerik Icerik { get; set; }
    }
}
