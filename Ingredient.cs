// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

//Define a class to represent an ingredient
public class Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }

    public Ingredient(string name, double quantity, string unit)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }

    //Method to scale the quantity of the ingredient
    public void Scale(double factor)
    {
        Quantity *= factor;
    }
}



