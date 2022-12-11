using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tryitter.Data.Repository.Interfaces;
using Tryitter.Models;
using Tryitter.Models.DTOs.PostDTO;

namespace Tryitter.Data
{
    public class PostRepository : IPostRepository
    {
        protected readonly TryitterContext _context;

        public PostRepository(TryitterContext context) => _context = context;

        public IList<PostDTO> GetAll()
        {
            var posts = _context
                .Posts
                .AsNoTracking()
                .Select(p => new PostDTO
                {
                    PostId = p.Id,
                    Title = p.Title,
                    Body = p.Body,
                    Image = p.Image,
                    LastUpdateDate = p.LastUpdateDate,
                    StudentId = p.StudentId,
                })
                .ToList();

            return posts;
        }

        public PostDTO GetById(Guid id)
        {
            var post = _context
                .Posts
                .AsNoTracking()
                .Select(p => new PostDTO
                {
                    PostId = p.Id,
                    Title = p.Title,
                    Body = p.Body,
                    Image = p.Image,
                    LastUpdateDate = p.LastUpdateDate,
                    StudentId = p.StudentId,
                })
                .FirstOrDefault(p => p.PostId == id);

            return post;
        }

        public PostDTOStudent Create(PostDTOCreate post)
        {
            var postInstance = new Post
            {
                Id = new Guid(),
                Title = post.Title,
                Body = post.Body,
                Image = post.Image,
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                StudentId = post.StudentId,
            };

            _context.Posts.Add(postInstance);
            _context.SaveChanges();

            return new PostDTOStudent
            {
                PostId = postInstance.Id,
                Title = postInstance.Title,
                Body = postInstance.Body,
                Image = postInstance.Image,
                LastUpdateDate = postInstance.LastUpdateDate,
                StudentId = postInstance.StudentId,
            };
        }

        public PostDTOStudent Update(PostDTOUpdate post, Guid id)
        {
            var postFound = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (postFound != null)
            {
                postFound.Title = post.Title;
                postFound.Body = post.Body;
                postFound.Image = post.Image;
                postFound.LastUpdateDate = DateTime.Now;

                _context.Posts.Update(postFound);
                _context.SaveChanges();
            }

            return new PostDTOStudent
            {
                PostId = postFound.Id,
                Title = postFound.Title,
                Body = postFound.Body,
                Image = postFound.Image,
                LastUpdateDate = postFound.LastUpdateDate,
                StudentId = postFound.StudentId,
            };
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Guid StudentId { get; set; }

        public void Remove(Guid id)
        {
            var postFound = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (postFound != null)
            {
                _context.Posts.Remove(postFound);
                _context.SaveChanges();
            }
        }
    }
}

