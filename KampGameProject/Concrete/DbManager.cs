using KampGameProject.Adapters.Database;

namespace KampGameProject.Concrete
{
    public static class DbManager
    {

        /****************************************************************************
         * 
         * Farklı bir veritabanı yönetimi için kullanılacak
         * 
         ***************************************************************************/

        private static object _gamers = new Gamers();
        private static object _games = new Games();
        private static object _orders = new Orders();
        private static object _campaigns = new Campaigns();
        public static object Gamers { get => _gamers; }
        public static object Games { get => _games; }
        public static object Orders { get => _orders; }
        public static object Campaigns { get => _campaigns; }
    }
}
