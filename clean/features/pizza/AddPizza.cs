using System.Runtime.InteropServices;
using clean.domain.pizza;
using core.infraestructure;
namespace clean.features.pizza
{
    public class Controller:Controller.IController
    {    
        private readonly IHandler _handler;
        public interface IController{
            Response handle(Request resonse);
        }
        private Controller(IHandler handler){
            _handler = handler;
        }
        public readonly record struct Request(
            string Name,
            string Desciption,
            string Url,
            IEnumerable<Ingredient> Ingredients

        );
        public readonly record struct Response(
            Guid Id,
            string Name,
            string Desciption,
            string Url,
            double Price,
            IEnumerable<Ingredient> Ingredients

        );
        private interface IHandler{
            Response handle(Request request);
        }
        private class Handler:IHandler
        {
            private readonly IAddPizza _repository;
            public Handler(IAddPizza repository)
            {
                _repository = repository;

            }
            public Response handle(Request request)
            {
                var pizza = Pizza.Create(
                        request.Name,
                        request.Desciption,
                        request.Url,
                        request.Ingredients);
                
                _repository.Add(pizza);

                return new Response(
                        pizza.Id,
                        pizza.Name,
                        pizza.Desciption,
                        pizza.Url,
                        pizza.Price(),
                        pizza.Ingredients());
            }
        }

        public Response handle(Request request)
        {
           return _handler.handle(request);
        }

        public static IController Create(){
            var respositoyry = new PizzaRepository();
            var handler = new Handler(respositoyry);
            return new Controller(handler);
        }
    }

}