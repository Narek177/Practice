using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogicLayer.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        public int UserId { get; set; }

        public int BlogId { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
