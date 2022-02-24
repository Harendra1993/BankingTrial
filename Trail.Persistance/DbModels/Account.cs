using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trail.Api.DbModels
{
    public class Account:Base
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}
