using clean.domain.pizza;

public class AddEventPizza : EventBase
{
    public AddEventPizza(Guid id,Pizza pizza):base(id, pizza)
    {
    }

}