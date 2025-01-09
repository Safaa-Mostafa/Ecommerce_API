using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.common
{
    public class BaseEntity
    {
        public virtual string Id { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }
        protected void ValidateId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Id cannot be empty.");
        }
    }
}