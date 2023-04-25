namespace DatabaseExampleEFCore
{
    internal class FillDatabase
    {
        /// <summary>
        /// Если база данных отсутствует, то она создается и заполняется данными из этого класса.
        /// </summary>
        public static void Fill()
        {
            StoreDbContext db = new StoreDbContext();

            //db.Database.EnsureDeleted();
            bool isDatabaseExists = db.Database.EnsureCreated();

            if (isDatabaseExists == false) return;

            Client c1 = new Client()
            {
                LastName = "Иванов",
                FirstName = "Иван",
                MiddleName = "Иванович",
                Email = "ivanov@123.ru"
            };
            Client c2 = new Client()
            {
                LastName = "Смирнов",
                FirstName = "Семен",
                MiddleName = "Викторович",
                Email = "smirnov@123.ru",
                Phone = "8851"
            };
            Client c3 = new Client()
            {
                LastName = "Васильев",
                FirstName = "Семен",
                MiddleName = "Вячеславович",
                Email = "vas@123.ru",
                Phone = "6587"
            };

            db.Clients.Add(c1);
            db.Clients.Add(c2);
            db.Clients.Add(c3);

            Product p1 = new Product() { Email = "ivanov@123.ru", ProductCode = "15", ProductName = "холодильник" };
            Product p2 = new Product() { Email = "ivanov@123.ru", ProductCode = "16", ProductName = "телевизор" };
            Product p3 = new Product() { Email = "ivanov@123.ru", ProductCode = "17", ProductName = "шкаф" };
            Product p4 = new Product() { Email = "smirnov@123.ru", ProductCode = "19", ProductName = "стол" };

            db.Products.Add(p1);
            db.Products.Add(p2);
            db.Products.Add(p3);
            db.Products.Add(p4);

            db.SaveChanges();
        }
    }
}
