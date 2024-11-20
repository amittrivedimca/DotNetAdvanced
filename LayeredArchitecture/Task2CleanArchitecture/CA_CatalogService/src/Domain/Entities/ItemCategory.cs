using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_CatalogService.Domain.Entities;
public class ItemCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; }
    public ItemCategory? ParentCategory { get; private set; }
}
