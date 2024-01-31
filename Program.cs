// author: Rod M
// task: Unit 3 - Lab2 - Shopping List

Console.WriteLine("---- Welcome to Smart Shoppers Market! ----");

var menuValues = new Dictionary<string, decimal>()
{
    {"bottled water", 1.8m },
    {"frozen meal", 5.0m },
    {"apple", 0.99m },
    {"banana", 0.59m },
    {"cauliflower", 1.59m },
    {"mixed greens", 3.19m },
    {"blueberry", 3.20m },
    {"cookie", 6.89m },
    {"grapefruit", 1.99m },
    {"potatoes", 0.59m }

};

var shoppingList = new List<string>();
bool continueShopping = true;

Console.WriteLine("Item             Price");
Console.WriteLine("======================");
foreach (KeyValuePair<string, decimal> menuItem in menuValues)
{
    Console.WriteLine(menuItem.Key + " $" + menuItem.Value);

}

while (continueShopping)
{
    Console.WriteLine("What item would you like?");
    string nextItem = Console.ReadLine();
    nextItem = nextItem.ToLower().Trim(); // normalize/clean up the input
    bool itemNotAvaialble = true;
    while (itemNotAvaialble)
    {

        foreach (KeyValuePair<string, decimal> menuItem in menuValues)
        {
            if (menuItem.Key == nextItem)
            {
                Console.WriteLine($"Adding {nextItem} for ${menuItem.Value}");
                shoppingList.Add(nextItem);
                itemNotAvaialble = false;
                break;
            }
        }

        if (itemNotAvaialble)
        {
            Console.WriteLine();
            Console.WriteLine("Sorry! This item is not in stock at this store");
            break;
        }

    }

    Console.WriteLine("Would you like to keep shopping? yes/no");
    string getMoreItems = Console.ReadLine();
    if (getMoreItems != null && getMoreItems.ToLower().Trim().Contains("n"))
    {
        continueShopping = false;
    }

    if (!continueShopping && shoppingList.Count > 0) // only show totals if cart is not empty
    {
        Console.WriteLine("======================");
        Console.WriteLine("====== Your Cart =====");
        decimal total = 0.0m;
        foreach (string item in shoppingList)
        {
            decimal itemPrice = menuValues[item];
            Console.WriteLine($"{item} - {itemPrice}");
            total += itemPrice;
        }
        Console.WriteLine("====== Your Total =====");
        Console.WriteLine("$" + total);
        Console.WriteLine();
        Console.WriteLine("Thanks for shopping with us!");
    }
}