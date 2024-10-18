namespace clean.core{
    public abstract class EntityBase{

        private readonly List<EventBase> events = [];

        public void AddEvent(EventBase eventBase) { events.Add(eventBase);}
        public void RemoveEvent(EventBase eventBase) { events.Remove(eventBase);}
        public void Clear(){ events.Clear(); }

        public List<EventBase> Events { get { return [.. events]; }}

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