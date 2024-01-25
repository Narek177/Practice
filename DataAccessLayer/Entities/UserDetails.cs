using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class UserDetails
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public virtual int UserId { get; set; }
        public virtual User User{ get; set; }

    }
}
