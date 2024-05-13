using System;

//Define a class to represent a Recipe
public class Recipe
{
    public List<Ingredient> Ingredients { get; set; }
    public List<string> Steps { get; private set; }

    private List<Ingredient> originalIngredients;
    public Recipe()
    {
        Ingredients = new List<Ingredient>();
        Steps = new List<string>();
        originalIngredients = new List<Ingredient>();
    }

    //Method to add an ingredient to the recipe
    public void AddIngredient(Ingredient ingredient)
    {
        Ingredients.Add(ingredient);
        //Keep a copy of the original ingredient to allow restarting later
        originalIngredients.Add(new Ingredient(ingredient.Name, ingredient.Quantity, ingredient.Unit));
    }

    //Method to add a step to the recipe
    public void AddStep(string step)
    {
        Steps.Add(step);
    }
    //Method to scale the recipe
    public void ScaleRecipe(double factor)
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Scale(factor);
        }
    }

    //Method to reset the quantities of the ingredients to their original values
    public void ResetQuantities()
    {
        Ingredients.Clear();
        Ingredients.AddRange(originalIngredients);
    }

    //Method to display the recipe
    public void DisplayRecipe()
    {
        Console.WriteLine("\nIngredients: ");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }

        Console.WriteLine("\nStep: ");
        for (int i = 0; i < Steps.Count; i++)
        {
            Console.WriteLine($"Step {i + 1}: {Steps[i]}");
        }
    }

    //Method to clear the recipe
    public void ClearRecipe()
    {
        Ingredients.Clear(); Steps.Clear();
        originalIngredients.Clear();
    }
}