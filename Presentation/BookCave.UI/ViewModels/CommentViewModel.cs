using System;

namespace BookCave.UI.ViewModels
{
    public class CommentViewModel
    {
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public string BookName { get; set; }
        public string PictureUri { get; set; }
        public string ISBN { get; set; }

    }
}
