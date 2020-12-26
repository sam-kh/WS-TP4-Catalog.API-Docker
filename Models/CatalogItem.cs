using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.API.Models
{
  public class CatalogItem
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    public int TypeId { get; set; }

  }
}
