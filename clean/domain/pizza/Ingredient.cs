using clean.core;

namespace clean.domain.pizza
{

    public class Ingredient : EntityBase
    {
        public string Name { get; private set; }
        public double Price { get; private set; }

        protected Ingredient(Guid id, string name, double price) : base(id)
        {
            Name = name;
            Price = price;
        }
        public void Update(string name, double price){
            Name = name;
            Price = price;
        }
        public static Ingredient Create(string name, double price)
        {
            return new Ingredient(Guid.NewGuid(), name, price);
        }
    }
}