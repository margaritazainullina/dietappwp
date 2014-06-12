
using System.Data.Linq;

namespace DietApp
{
    public class MyDataContext : DataContext
    {
        public MyDataContext(string connectionString)
            : base(connectionString)
        {
        }
        public Table<Person> Persons
        {
            get
            {
                return this.GetTable<Person>();
            }
        }
        public Table<IdealParameter> IdealParameters
        {
            get
            {
                return this.GetTable<IdealParameter>();
            }
        }
        public Table<Product> Products
        {
            get
            {
                return this.GetTable<Product>();
            }
        }
        public Table<Dish> Dishes
        {
            get
            {
                return this.GetTable<Dish>();
            }
        }
        public Table<DishProduct> DishProducts
        {
            get
            {
                return this.GetTable<DishProduct>();
            }
        }

        public Table<Ration> Rations
        {
            get
            {
                return this.GetTable<Ration>();
            }
        }
    }
}
