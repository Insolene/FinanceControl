using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceControl.Entities
{
    public class TransactionEntities
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime OperationDate { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserEntities User { get; set; }

        public string Type { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual CategoryEntities Category { get; set; }


    }
}
