using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCore_Sqlite_JoinIssue
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [InverseProperty(nameof(Ticket.AssignedTo))]
        public ICollection<Ticket> AssignedTickets { get; set; }

        [InverseProperty(nameof(Ticket.CreatedBy))]
        public ICollection<Ticket> CreatedTickets { get; set; }
    }
}
