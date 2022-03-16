using BookCave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Abstracts
{
    public interface ICommentService
    {
        Task<Comment> AddCommentAsync(Comment comment);
    }
}
