using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventra.Domain.Dto
{
    public class ProductFilterDto
    {
        public bool? OnlyFeatured { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Search { get; set; }
    }
}
