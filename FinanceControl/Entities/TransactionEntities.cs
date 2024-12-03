namespace FinanceControl.Entities
{
    public class TransactionEntities
    {
        public int Id { get; set; }    
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime OperationDate { get; set; }
        public string Type { get; set; } 
        public List<UserEntities> UserEntities { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntities CategoryEntities { get; set; } 
    }
}
