using BookCave.Domain.Abstracts;
using BookCave.Domain.Entities.Common;
using System;

namespace BookCave.Domain.Entities
{
    public class Comment : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsSecretName { get; set; }
        public string ISBN { get; set; }
        public Book Book { get; set; }
        //TODO: user gelecek
    }
}
