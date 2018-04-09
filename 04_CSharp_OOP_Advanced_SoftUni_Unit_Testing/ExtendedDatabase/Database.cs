using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database
{
    public class Database
    {
        private Dictionary<long,string> people = new Dictionary<long, string>();
        private int currentIndex;

        private Database()
        {
            this.people = new Dictionary<long, string>();
            currentIndex = 0;
        }

        public Database(Dictionary<long,string> members) : this()
        {
            people = members;
            currentIndex = members.Count;
        }

        public void Add(KeyValuePair<long,string> member)
        {
            if (people.ContainsKey(member.Key)) throw new InvalidOperationException("Database contains an user with such id!");
            if (people.ContainsValue(member.Value)) throw new InvalidOperationException("Database contains an user with such username!");
            people.Add(member.Key, member.Value);
            currentIndex++;


        }
        public void Remove()
        {
            if (currentIndex == 0) throw new InvalidOperationException("Database is empty!");
            currentIndex--;
            people.Remove(people.ElementAt(currentIndex - 1).Key);
        }

        public KeyValuePair<long, string> FindById(long id)
        {
            if(!people.ContainsKey(id)) throw new InvalidOperationException("Database does not contain an user with such id!");
            if(id < 0) throw new ArgumentOutOfRangeException("Id cannot be negative!");
            return people.Where(p => p.Key == id).First();
        }
        public KeyValuePair<long, string> FindByUsername(string username)
        {
            if (!people.ContainsValue(username)) throw new InvalidOperationException("Database does not contain an user with such username!");
            if (username  == null) throw new ArgumentNullException("Username cannot be null!");
            return people.Where(p => p.Value == username).First();
        }
    }
}
