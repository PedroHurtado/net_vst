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
    public interface IGet
    {
        void Get();
    }
    public interface IAdd
    {
        void Add();
    }

    public interface IUpdate : IGet
    {
        void Update();
    }
    public interface IRemove : IGet
    {
        void Remove();
    }

    public interface IRepository : IAdd, IUpdate, IRemove
    {

    }

    public class CustomerRepository : IRepository
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
    public class UserRepository : IGet
    {
        public void Get()
        {
            throw new NotImplementedException();
        }
    }

    public class ServiceCustomer{
        public void Get(IGet respository){
            
        }
        public void Update(IUpdate repository){
            repository.Get();
            repository.Update();
        }

    }
}
