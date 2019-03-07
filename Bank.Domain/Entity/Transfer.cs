using Bank.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Domain.Entity
{
    public class Transfer : ITransfer
    {
        public Transfer()
        {

        }
        public int Id { get; set; }
        public int OriginAccount { get; set; }
        public int DestinationAccount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }
    }
}
