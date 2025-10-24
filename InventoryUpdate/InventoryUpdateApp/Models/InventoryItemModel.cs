using InventoryUpdateApp.Enums;

namespace InventoryUpdateApp.Models;
public class InventoryItemModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Location Location { get; set; }
}
