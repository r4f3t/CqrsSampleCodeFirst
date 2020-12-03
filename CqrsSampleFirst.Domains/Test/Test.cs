using CqrsSampleFirst.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CqrsSampleFirst.Domain.Test
{
    public class Test : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
