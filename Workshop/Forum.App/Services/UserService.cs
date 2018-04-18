using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forum.App.Contracts;
using Forum.Data;
using Forum.DataModels;

namespace Forum.App.Services
{
    public class UserService : IUserService
    {
        private ForumData forumData;
        private ISession session;

        public UserService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public bool TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;
            if (!validPassword || !validUsername)
            {
                throw new ArgumentException("Username and Password must be longer than 3 symbols!");
            }

            bool userAlreadyExists = forumData.Users.Any(u => u.Username == username);

            if (userAlreadyExists)
            {
                throw new InvalidOperationException("Username taken!");
            }
            int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
            User user = new User(userId, username, password);

            forumData.Users.Add(user);
            forumData.SaveChanges();

            this.TryLogInUser(username, password);

            return true;
        }

        public bool TryLogInUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username);
            bool validPassword = !string.IsNullOrWhiteSpace(password);
            if (!validPassword || !validUsername)
            {
                return false;
            }

            User user = this.forumData.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                return false;
            }
            session.Reset();
            session.LogIn(user);

            return true;

        }

        public string GetUserName(int userId)
        {
            return this.forumData.Users.FirstOrDefault(u => u.Id == userId).Username;
        }

        public User GetUserById(int userId)
        {
            User user = this.forumData.Users.FirstOrDefault(u => u.Id == userId);

            return user;
        }
    }
}
