using System;

class Program
{
    static Recipe myRecipe = new Recipe();
    private static bool running;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the new Recipe App.");
        while (running) { 

        Console.WriteLine("\nSelect an option.");
        Console.WriteLine("1- Enter new recipe: ");
        Console.WriteLine("2- Display the recipe: ");
        Console.WriteLine("3- Scale the recipe: ");
        Console.WriteLine("4- Reset the recipe: ");
        Console.WriteLine("5- Edit the recipe: ");
        Console.WriteLine("6- exit: ");
        Console.WriteLine("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    EnterRecipe();
                    break;
                case 2:
                    myRecipe.DisplayRecipe();
                    break;
                case 3:
                    ScaleRecipe();
                    break;
                case 4:
                    ResetRecipe();
                    break;
                case 5:
                    EditRecipe();
                    break;
                case 6:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }


    static void EnterRecipe()
    {
        myRecipe.ClearRecipe();//Clear the recipe 

        //Get the number of ingredients
        Console.Write("Enter the number of ingredients: ");
        int ingredientCount = int.Parse(Console.ReadLine());

        //Input ingredients
        for (int i = 0; i < ingredientCount; i++)
        {
            Console.Write("Enter ingredient name: ");
            string name = Console.ReadLine();

            Console.Write("Enter quantity: ");
            double quantity = int.Parse(Console.ReadLine());

            Console.Write("Enter unit of measurment: ");
            string unit = Console.ReadLine();

            myRecipe.AddIngredient(new Ingredient(name, quantity, unit));
        }

        //Get the number of steps
        Console.WriteLine("Enter the number of steps: ");
        int stepCount = int.Parse(Console.ReadLine());

        //Input steps
        for (int i = 0; i < stepCount; i++)
        {
            Console.Write($"Enter step {i + 1} description: ");
            string stepDescription = Console.ReadLine();

            myRecipe.AddStep(stepDescription);
        }
    }

    static void ScaleRecipe()
    {
        Console.Write("Enter scale factor (0.5 for half, 2 for double, 3 for triple): ");
        double scaleFactor = double.Parse(Console.ReadLine());

        myRecipe.ScaleRecipe(scaleFactor);
        Console.WriteLine("Recipe has been scaled.");
        myRecipe.DisplayRecipe();
    }
    static void ResetRecipe()
    {
        myRecipe.ResetQuantities();
        Console.WriteLine("Recipe quantities have been reset to original values.");
        myRecipe.DisplayRecipe();
    }
    static void EditRecipe()
    {
        Console.WriteLine("Select an option to edit: ");
        Console.WriteLine("1- Edit ingredients");
        Console.WriteLine("2- Edit steps");
        Console.WriteLine("enter your chouce: ");
        int editChoice = int.Parse(Console.ReadLine());

        switch (editChoice)
        {
            case 1:
                EditIngredients();
                break;
            case 2:
                EditSteps();
                break;
            default:
                Console.WriteLine("Invalid option, please try again.");
                break;
        }
    }
    static void EditIngredients()
    {
        Console.WriteLine("\nCurrentIngredients: ");
        for (int i = 0; i < myRecipe.Ingredients.Count; i++)
        {
            var ingredient = myRecipe.Ingredients[i];
            Console.WriteLine($"{i + 1}: {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }

        Console.WriteLine("Enter the number of the ingredients you want to edit: ");
        int ingredientNumber = int.Parse(Console.ReadLine()) - 1;

        if (ingredientNumber >= 0 && ingredientNumber < myRecipe.Ingredients.Count)
        {
            var ingredientToEdit = myRecipe.Ingredients[ingredientNumber];

            Console.Write("Enter new name (or press enter key to kep current name): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                ingredientToEdit.Name = newName;
            }
            Console.Write("Enter new quantity (or press enter to keep current value): ");
            string newQuantity = Console.ReadLine();
            if (double.TryParse(newQuantity, out double quantity))
            {
                ingredientToEdit.Quantity = quantity;
            }
            Console.Write("Enter new unit (or press enter to keep crrent unit): ");
            string newUnit = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newUnit))
            {
                ingredientToEdit.Unit = newUnit;
            }

            Console.WriteLine("Ingredient updated.");
        }
        else
        {
            Console.WriteLine("Invalid ingredient number.");
        }
    }

    static void EditSteps()
    {
        Console.WriteLine("\nCurrent Steps:");
        for (int i = 0; i<myRecipe.Steps.Count; i++)
        {
            Console.WriteLine($"Step {i + 1}:{myRecipe.Steps[i]}");
        }
        Console.WriteLine("Enter the number of the steps you want to edit: ");
        int stepNumber = int.Parse(Console.ReadLine()) -1;

        if(stepNumber >= 0 && stepNumber < myRecipe.Steps.Count)
        {
            Console.Write("Enter new steps description: ");
            string newStepDescription = Console.ReadLine();

            myRecipe.Steps[stepNumber] = newStepDescription;
            Console.WriteLine("Steps updated.");
        }
        else
        {
            Console.WriteLine("Invalid step number.");
        }
    }
}