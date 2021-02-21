using KampGameProject.Abstract;
using KampGameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KampGameProject.Adapters.Database
{
    public class Gamers : IDbAdapterService<Gamer>
    {
        private List<Gamer> _gamers;
        public Gamers()
        {
            //Normalde Veritabanındaki veriler burada listeye ekleniyor
            //Aşağıdaki işlem veritabanının boş olması durumunu simgeliyor
            _gamers = new List<Gamer>();
        }

        public void Add(Gamer gamer)
        {
            gamer.Id = LastIndex() + 1;
            _gamers.Add(gamer);
            Console.WriteLine("The gamer has been successfully added");
        }

        public void Delete(Gamer gamer)
        {
            Gamer currentGamer = _gamers.SingleOrDefault(g => g.Id == gamer.Id);
            _gamers.Remove(currentGamer);
        }

        public Gamer GetById(int gamerId)
        {
            return _gamers.SingleOrDefault(g => g.Id == gamerId);
        }

        public List<Gamer> GetList()
        {
            return _gamers;
        }

        public void Update(Gamer gamer)
        {
            Gamer currentGamer = _gamers.SingleOrDefault(g => g.Id == gamer.Id);
            currentGamer.FirstName = gamer.FirstName;
            currentGamer.LastName = gamer.LastName;
            currentGamer.DateOfBirth = gamer.DateOfBirth;
            currentGamer.NationalityId = gamer.NationalityId;
            currentGamer.NickName = gamer.NickName;
        }

        public int LastIndex()
        {
            if (_gamers.Count > 0)
            {
                Gamer gamer = _gamers[_gamers.Count - 1];
                return gamer.Id;
            }
            else
            {
                return 0;
            }
        }
    }
}
