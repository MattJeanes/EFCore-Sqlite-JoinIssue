using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCore_Sqlite_JoinIssue
{
    public class Ticket
    {
        public int Id { get; set; }

        public string Summary { get; set; }

        public int? AssignedToId { get; set; }

        public User AssignedTo { get; set; }

        public int? CreatedById { get; set; }

        public User CreatedBy { get; set; }
    }
}
