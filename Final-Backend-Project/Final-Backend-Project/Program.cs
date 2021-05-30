using Final_Backend_Project.Models;
using Final_Backend_Project.Store;
using System;
using System.Text.RegularExpressions;

namespace Final_Backend_Project
{
    class Program
    {
        static string path = "storage.dat";
        static string path2 = "storage.dat2";
        static void Main(string[] args)
        {
            GenericStore<Product> productStore = new GenericStore<Product>();
            GenericStore<Category> categoryStore = new GenericStore<Category>();
        A:
            categoryStore.Load(path);
            productStore.Load(path2);

            Console.WriteLine("1---Elave etmek; 2---Silmek; 3---Gostermek; 4---Indexi secin; 5---Mehsul elave etmek; 6---Mehsullari gostermek; 7---Mehsulu silmek") ;
            string num = Console.ReadLine();

            switch (num)
            {
                case "1":
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Beep();
                        Console.Write("Enter a count: ");
                        int count;
                    L1:
                        if (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
                        {
                            Console.WriteLine("Zehmet olmasa duzgun melumat oturun");
                            goto L1;
                        }
                        for (int i = 0; i < count; i++)
                        {
                            Category category = new Category();

                        L2:
                            Console.Write("Kateqoriyanin id-ni yazin: ");
                            if (!int.TryParse(Console.ReadLine(), out int id) || id < 0)
                            {
                                Console.WriteLine("Xahis olunur Id-ni duzgun yazin");
                                goto L2;
                            }
                            category.Id = id;

                        L3:
                            Console.Write("Kateqoriyanin Meqsedini yazin: ");
                            const string valuePattern = @"^[A-Z]{1}[a-z]{2,}$";
                            string purpose = Console.ReadLine();
                            if (!Regex.IsMatch(purpose, valuePattern))
                            {
                                Console.WriteLine("Duzgun yazilis qaydasina emel edin");
                                goto L3;
                            }
                            category.Purpose = purpose;
                            categoryStore.Add(category);
                        }
                        break;
                    }
                case "2":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Beep();
                    L4:
                        Console.WriteLine("Legv etmek istediyiniz kateqoriyani yazin: ");
                        if (!int.TryParse(Console.ReadLine(), out int index) || index <= 0)
                        {
                            Console.WriteLine("Duzgun yaz: ");
                            goto L4;
                        }
                        var founded = categoryStore[index - 1];
                        categoryStore.Remove(founded);
                        break;
                    }
                case "3":
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Beep();
                        Console.WriteLine("List============================");
                        foreach (var item in categoryStore)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    }
                case "4":
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Beep();
                    L5:
                        Console.WriteLine("Kateqoriya indexi daxil edin: ");
                        int ind = Convert.ToInt32(Console.ReadLine());
                        if (ind < 0)
                        {
                            Console.WriteLine("0-dan kicik ola bilmez");
                            goto L5;
                        }
                        Console.WriteLine(categoryStore[ind]);
                        break;
                    }
                case "5":
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Beep();
                    C1:
                        Console.Write("Elave edeceyiniz mehsul sayini yazin: ");
                        int productCount;
                        if (!int.TryParse(Console.ReadLine(), out productCount) || productCount <= 0)
                        {
                            Console.WriteLine("Duzgun yazin");
                            goto C1;
                        }
                        for (int i = 0; i < productCount; i++)
                        {
                            Product product = new Product();

                            const string valuePattern = @"^[A-Z]{1}[a-z]{2,}$";
                        C2:
                            Console.Write("Enter a product name: ");
                            string productName = Console.ReadLine();
                            if (!Regex.IsMatch(productName, valuePattern))
                            {
                                Console.WriteLine("Duzgun daxil edin");
                                goto C2;
                            }
                            product.Name = productName;

                        C3:
                            Console.Write("Enter a price of Product: ");
                            if (!int.TryParse(Console.ReadLine(), out int productPrice) || productPrice <= 99)
                            {
                                Console.WriteLine("Qiymet 99 manatdan cox olmalidir");
                                goto C3;
                            }
                            product.Price = productPrice;

                            productStore.Add(product);
                         
                        }
                        break;
                    }
                case "6":
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Beep();
                        Console.WriteLine("List===========================================");
                        foreach (var item in productStore)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    }
                case "7":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Beep();
                    C4:
                        Console.WriteLine("Legv etmek istediyiniz productu yazin: ");
                        if (!int.TryParse(Console.ReadLine(), out int index) || index <= 0)
                        {
                            Console.WriteLine("Duzgun yaz: ");
                            goto C4;
                        }
                        var founded = productStore[index - 1];
                        productStore.Remove(founded);
                        break;
                    }
            }
            categoryStore.Save(path);
            productStore.Save(path2);
            goto A;
        }

    }
}
