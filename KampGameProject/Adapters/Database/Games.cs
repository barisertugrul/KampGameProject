using KampGameProject.Abstract;
using KampGameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KampGameProject.Adapters.Database
{
    public class Games : IDbAdapterService<Game>
    {
        private List<Game> _games;

        public Games()
        {
            //Normalde Veritabanındaki veriler burada listeye ekleniyor
            //Aşağıdaki işlem veritabanının boş olması durumunu simgeliyor
            _games = new List<Game>();
        }

        public void Add(Game game)
        {
            game.GameId = LastIndex() + 1;
            _games.Add(game);
            Console.WriteLine("The game has been successfully added");
        }

        public void Delete(Game game)
        {
            Game currentGame = _games.SingleOrDefault(g => g.GameId == game.GameId);
            _games.Remove(currentGame);
        }

        public List<Game> GetList()
        {
            return _games;
        }

        public void Update(Game game)
        {
            Game currentGame = _games.SingleOrDefault(g => g.GameId == game.GameId);
            currentGame.GameName = game.GameName;
            currentGame.GameCategoryId = game.GameCategoryId;
            currentGame.GameUnitPrice = game.GameUnitPrice;
            currentGame.GameUnitsInStock = game.GameUnitsInStock;
        }

        public Game GetById(int gameId)
        {
            return _games.SingleOrDefault(g => g.GameId == gameId);
        }

        public int LastIndex()
        {
            if (_games.Count > 0)
            {
                Game game = _games[_games.Count - 1];
                return game.GameId;
            }
            else
            {
                return 0;
            }
        }
    }
}
