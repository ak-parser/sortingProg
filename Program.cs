using System;
using Sort;
using System.Collections.Generic;

Product[] products = new Product[]
{
    new Product(1, "Bread"),
    new Product(4, "Milk"),
    new Product(8, "Apple"),
    new Product(2, "Meat"),
    new Product(6, "Nectarine")
};

Console.WriteLine("QuickSort");
Sorter.QuickSort<Product>(products, (elem1, elem2) => elem1.CompareTo(elem2), products.Length, elem => elem.Name.Contains("M"), true);

foreach(Product product in products)
    Console.WriteLine(product);

Console.WriteLine("\nHeapSort");
Sorter.HeapSort<Product>(products, (elem1, elem2) => elem1.CompareTo(elem2), products.Length, elem => elem.Name.Contains("N"));

foreach (Product product in products)
    Console.WriteLine(product);