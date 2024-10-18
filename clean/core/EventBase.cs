using clean.core;

public abstract class EventBase{
    public Guid Id{ get; private set; }
    public DateTimeOffset TimestTamp {get;private set;}
    public Guid EntityId {get; private set;}
    public Object Data {get; private set;}
    protected EventBase(Guid entityId, Object data){
        Id=Guid.NewGuid();  
        TimestTamp = DateTime.UtcNow;
        EntityId=entityId;
        Data = data;
    }    
}