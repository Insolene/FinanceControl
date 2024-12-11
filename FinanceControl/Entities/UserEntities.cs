namespace FinanceControl.Entities
{
    public class UserEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password {  get; set; }
        public UserEntities()
        {
        }

        public UserEntities(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }
    }
    
}
