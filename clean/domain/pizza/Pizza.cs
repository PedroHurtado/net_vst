using System.Collections.ObjectModel;
using clean.core;

namespace clean.domain.pizza{
    public class Pizza : EntityBase
    {
        public string Name {get;private set;}
        public string Desciption {get;private set;}
        public string Url {get;private set;}
        private HashSet<Ingredient> ingredients = new HashSet<Ingredient>();
        protected Pizza(Guid id ,string name,string description,string price) : base(id)        
        {
            Name = name;
            Desciption = description;
            Url = price;

        }
        public void AddIngredient(Ingredient ingredient){
            ingredients.Add(ingredient);
        }
        public void RemoveIngredient(Ingredient ingredient){
            ingredients.Remove(ingredient);
        }
        public IReadOnlyCollection<Ingredient> Ingredients()=>ingredients;
        
        public double Price()=>ingredients.Sum(i=>i.Price) * 1.2;
        public void Update(string name,string description, string url){
            Name=name;
            Desciption=description;
            Url=url;            
        }
        public static Pizza Create(string name,string description, string url, IEnumerable<Ingredient> ingredientes){
            var pizza= new Pizza(Guid.NewGuid(),name,description,url);
            foreach(var ingredient in ingredientes){
                pizza.ingredients.Add(ingredient);
            }
            return pizza;
        }
    }
}