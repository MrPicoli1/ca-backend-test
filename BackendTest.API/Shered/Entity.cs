namespace BackendTest.API.Shered
{
    public abstract class Entity
    {

        public Entity()
        {
            Id = Guid.NewGuid();
            
        }
        
        public Guid Id { get; private set; }
        public void SetId(Guid id) 
        {
            Id = id;
        }

    }
}
