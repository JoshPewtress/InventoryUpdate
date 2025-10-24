using InventoryUpdateApp.Models;
using InventoryUpdateApp.Enums;
using InventoryUpdateApp.Exceptions;

namespace InventoryUpdateApp;
public static class Helper
{
    private static readonly Dictionary<int, InventoryItemModel> _Inventory = new();

    private static void PopulateDictionary()
    {
        if (_Inventory.Count == 0)
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

    public static List<InventoryItemModel> GetAllItems()
    {
        PopulateDictionary();

        var output = _Inventory.Values.ToList();
        if (!output.Any())
        {
            throw new ItemNotFoundException("No products found in inventory.");
        }

        return output;
    }

    public static InventoryItemModel GetItemById(int id)
    {
        PopulateDictionary();

        if (!_Inventory.TryGetValue(id, out var output))
        {
            Console.Write($"No product found with ID {id}, Create Item? Y\\N: ");
            string response = Console.ReadLine().Trim().ToUpper();
            if (response == "Y")
            {
                (string pName, Location locEnum, decimal pPrice) = PromptForItemInfo();
                AddInventoryItem(pName, locEnum, pPrice);
            }
            else
            {
                throw new ItemNotFoundException($"No product found with ID {id}");
            }     
        }

        return output;
    }

    public static (string pName, Location locEnum, decimal pPrice) PromptForItemInfo()
    {
        Console.Write("Enter the Product Name: ");
        string pName = Console.ReadLine();

        Console.Write("Enter the Product Location: ");
        string plocation = Console.ReadLine();
        if (!Enum.TryParse<Location>(plocation, true, out var locEnum))
        {
            throw new ItemNotFoundException($"'{plocation}' is not a valid location.");
        }

        Console.Write("Enter the Product Price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal pPrice))
        {
            throw new Exception("Not a valid price amount.");
        }

        return (pName, locEnum, pPrice);
    }

    public static void AddInventoryItem(string name, Location location, decimal price)
    {
        PopulateDictionary();

        // If dictionary is not empty find highest key and add 1, otherwise its 1
        int nextId = _Inventory.Keys.Max() + 1;

        var newItem = new InventoryItemModel()
        {
            Id = nextId,
            Name = name,
            Location = location,
            Price = price
        };

        _Inventory.Add(nextId, newItem);
    }

    public static List<InventoryItemModel> GetItemsByLocation(string location)
    {
        PopulateDictionary();

        if (!Enum.TryParse<Location>(location, true, out var locEnum))
        {
            throw new ItemNotFoundException($"'{location}' is not a valid location.");
        }

        List<InventoryItemModel> output = _Inventory.Values.Where(i => i.Location == locEnum).ToList();
        if (!output.Any())
        {
            throw new ItemNotFoundException($"No products found in location '{location}'");
        }

        return output;
    }

    public static void Print(this InventoryItemModel item)
    {
        Console.WriteLine(
                $"""
                Id: {item.Id}, Name: {item.Name}, Location: {item.Location}, Price: ${item.Price}.
                """);
    }

    public static void Print(this List<InventoryItemModel> list)
    {
        foreach (var item in list)
        {
            item.Print();
        }
    }
}
