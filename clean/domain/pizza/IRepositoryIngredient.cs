namespace clean.domain.pizza
{
    public interface IRepositoryIngredient
    {
        void Add(Ingredient ingredient);
        void Remove(Ingredient ingredient);
        void Update(Ingredient ingredient);
        Ingredient get(Guid id);
    }
}

