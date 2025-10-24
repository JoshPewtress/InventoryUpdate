using InventoryUpdateApp.Models;
using InventoryUpdateApp.Enums;

namespace InventoryUpdateApp;
public static class Helper
{
    private static readonly Dictionary<int, InventoryItemModel> _Inventory = new();

    private static void PopulateDictionary()
    {
        _Inventory.Add(1, new InventoryItemModel { Id = 1, Name = "Milk", Location = Location.Grocery, Price = 3.99m });
        _Inventory.Add(2, new InventoryItemModel { Id = 2, Name = "Car Oil", Location = Location.Auto, Price = 19.99m });
        _Inventory.Add(3, new InventoryItemModel { Id = 3, Name = "Faded Jeans", Location = Location.Clothing, Price = 25m });
        _Inventory.Add(4, new InventoryItemModel { Id = 4, Name = "Stainless Steel Pan", Location = Location.HomeGoods, Price = 9.95m });
        _Inventory.Add(5, new InventoryItemModel { Id = 5, Name = "Toaster", Location = Location.HomeGoods, Price = 15m });
        _Inventory.Add(6, new InventoryItemModel { Id = 6, Name = "Captain Crunch", Location = Location.Grocery, Price = 7m });
        _Inventory.Add(7, new InventoryItemModel { Id = 7, Name = "Tires", Location = Location.Auto, Price = 250m });
        _Inventory.Add(8, new InventoryItemModel { Id = 8, Name = "Dress Shoes", Location = Location.Clothing, Price = 50m });
    }
}
