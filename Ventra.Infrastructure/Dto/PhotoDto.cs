using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventra.Infrastructure.Dto
{
    public class PhotoDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? ProductId { get; set; }
    }
}
