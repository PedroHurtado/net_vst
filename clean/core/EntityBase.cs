namespace clean.core{
    public abstract class EntityBase{


        /*
        constructor sin parametros por culpa de entity framework*/
        private EntityBase(){
            
        }
        protected EntityBase(Guid id)
        {
            Id=id;
        }
        public override bool Equals(object? obj)
        {  if(obj is EntityBase e){
                return e.Id==Id;
            }   
            return false;
        }        
       
        public override int GetHashCode()
        {        
            return Id.GetHashCode();
        }
        
        public Guid Id {get;init;}
        
    }
}