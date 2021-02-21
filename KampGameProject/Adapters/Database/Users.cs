using KampGameProject.Abstract;
using KampGameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KampGameProject.Adapters.Database
{
    public class Users : IDbAdapterService<User>
    {
        private List<User> _users;

        public Users()
        {
            //Normalde Veritabanındaki veriler burada listeye ekleniyor
            //Aşağıdaki işlem veritabanının boş olması durumunu simgeliyor
            _users = new List<User>();
        }

        public void Add(User user)
        {
            user.Id = LastIndex() + 1;
            _users.Add(user);
            Console.WriteLine("The user has been successfully added");
        }

        public void Delete(User user)
        {
            User currentUser = _users.SingleOrDefault(u => u.Id == user.Id);
            _users.Remove(currentUser);
        }

        public User GetById(int userId)
        {
            return _users.SingleOrDefault(u => u.Id == userId);
        }

        public List<User> GetList()
        {
            return _users;
        }

        public void Update(User user)
        {
            User currentUser = _users.SingleOrDefault(u => u.Id == user.Id);
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.DateOfBirth = user.DateOfBirth;
            currentUser.NationalityId = user.NationalityId;
        }

        public int LastIndex()
        {
            if (_users.Count > 0)
            {
                User user = _users[_users.Count - 1];
                return user.Id;
            }
            else
            {
                return 0;
            }
        }

    }
}
