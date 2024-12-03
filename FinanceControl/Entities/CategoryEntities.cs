namespace FinanceControl.Entities
{
    public class CategoryEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TransactionEntities> Transaction { get; set; }
    }
}
