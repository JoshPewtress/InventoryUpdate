using InventoryUpdateApp;

public class UIMethods
{
    public static void ListAllProducts()
    {
        Helper.GetAllItems().Print();
    }

    public static void ListProductById()
    {
        bool validId;
        int id;

        do
        {
            Console.Write("Enter the Product ID: ");
            validId = int.TryParse(Console.ReadLine(), out id);

        } while (validId == false);

        Helper.GetItemById(id).Print();
    }

    public static void ListProductByLocation()
    {
        Console.Write("Enter the Location to search: ");
        Helper.GetItemsByLocation(Console.ReadLine()).Print();
    }
}