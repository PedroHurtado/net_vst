namespace clean.domain.pizza
{
    public interface IAddPizza{
        void Add(Pizza ingredient);
    }
    public interface IRepositoyPizza :IAddPizza
    {
        
        void Remove(Pizza ingredient);
        void Update(Pizza ingredient);
        Pizza get(Guid id);
    }
}