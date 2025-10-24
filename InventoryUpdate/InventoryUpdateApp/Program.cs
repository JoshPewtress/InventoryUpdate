using InventoryUpdateApp;

public class UIMethods
{
    public static void Greeting()
    {
        Console.WriteLine(
            $"""
            Welcome to the Inventory Update Application.

            """);
    }

    public static void DecisionTree()
    {
        while (true)
        {
            Console.WriteLine(
            $"""
            Select an option...
            1 - List all Products
            2 - Search by ID
            3 - Search by Location
            4 - Clear Console
            5 - Exit Application
            """);

            Console.Write("Selection: ");
            int selection = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (selection)
            {
                case 1:
                    ListAllProducts();
                    Console.WriteLine();
                    break;
                case 2:
                    ListProductById();
                    Console.WriteLine();
                    break;
                case 3:
                    ListProductByLocation();
                    Console.WriteLine();
                    break;
                case 4:
                    Console.Clear();
                    DecisionTree();
                    break;
                case 5:
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            } 
        }
    }

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