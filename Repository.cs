/*
   En nuestro sistema tenemos clientes que pueden
        Leer
        Add
        Update
        Remove
    Los usuarios solo se pueden Leer
*/
namespace Repository
{
    public interface IGet<T>
    {
        void Get();
    }
    public interface IAdd<T>
    {
        void Add();
    }

    public interface IUpdate<T> : IGet<T>
    {
        void Update();
    }
    public interface IRemove<T> : IGet<T>
    {
        void Remove();
    }

    public interface IRepository<T> : IAdd<T>, IUpdate<T>, IRemove<T>
    {

    }

    public class Customer{}
    public class CustomerRepository : IRepository<Customer>
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
    public class User{

    }
    public class UserRepository : IGet<User>
    {
        public void Get()
        {
            throw new NotImplementedException();
        }
    }

    public class ServiceCustomer{
        public void Get(IGet<Customer> respository){
            
        }
        public void Update(IUpdate<Customer> repository){
            repository.Get();
            repository.Update();
        }

    }
}
