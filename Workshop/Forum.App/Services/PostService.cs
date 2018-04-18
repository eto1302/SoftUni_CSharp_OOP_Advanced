using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forum.App.Contracts;
using Forum.App.Contracts.ViewModels;
using Forum.Data;
using Forum.DataModels;

namespace Forum.App.Services
{
    public class PostService : IPostService
    {
        private ForumData forumData;
        private IUserService userService;
        private int currentId;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
            currentId = forumData.Categories.Count != 0 ? forumData.Categories.Last().Id : 1;
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            IEnumerable<ICategoryInfoViewModel> categories =
                this.forumData.Categories.Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));
            return categories;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            var posts = this.forumData.Posts
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new PostInfoViewModel(p.Id, p.Title, p.Replies.Count));

            return posts;
        }

        public string GetCategoryName(int categoryId)
        {
            string categoryName = this.forumData.Categories.FirstOrDefault(c => c.Id == categoryId).Name;

            if (categoryName == null)
            {
                throw new ArgumentException($"Category with ID {categoryId} not found!");
            }
            return categoryName;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            var post = this.forumData.Posts.FirstOrDefault(p => p.Id == postId);
            IPostViewModel postView = new PostViewModel(post.Title,this.userService.GetUserName(post.AuthorId), post.Content, this.GetPostReplies(postId));

            return postView;
        }

        private IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            IEnumerable<IReplyViewModel> replies = this.forumData.Replies
                .Where(r => r.PostId == postId)
                .Select(r => new ReplyViewModel(this.userService.GetUserName(r.AuthorId), r.Content));

            return replies;
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postCategory);
            bool emptyTitle = string.IsNullOrWhiteSpace(postTitle);
            bool emptyContent = string.IsNullOrWhiteSpace(postContent);

            if (emptyCategory || emptyContent || emptyTitle)
            {
                throw new ArgumentException("All fields must be filled!");
            }

            Category category = this.EnsureCategory(postCategory);

            int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;

            User author = this.userService.GetUserById(userId);

            Post post = new Post(postId, postTitle, postContent, category.Id, userId, new List<int>());

            this.forumData.Posts.Add(post);
            author.Posts.Add(post.Id);
            category.Posts.Add(post.Id);
            this.forumData.SaveChanges();

            return post.Id;
        }

        private Category EnsureCategory(string postCategory)
        {
            bool categoryExists = this.forumData.Categories.Any(c => c.Name == postCategory);

            Category category = null;

            if (!categoryExists)
            {
                

                category = new Category(currentId, postCategory, new List<int>());

                this.forumData.Categories.Add(category);
                currentId++;
            }
            else
            {
                category = this.forumData.Categories.First(c => c.Name == postCategory);
            }

            return category;
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            Post post = this.forumData.Posts.Find(p => p.Id == postId);
            User author = this.userService.GetUserById(userId);

            int replyId = this.forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;

            Reply reply = new Reply(replyId, replyContents, userId, postId);


            this.forumData.Replies.Add(reply);
            post.Replies.Add(replyId);
            this.forumData.SaveChanges();
        }
    }
}
