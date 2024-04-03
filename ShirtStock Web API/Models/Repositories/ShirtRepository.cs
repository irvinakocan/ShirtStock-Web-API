using System;
namespace ShirtStock_Web_API.Models.Repositories
{
	public static class ShirtRepository
	{
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt {ShirtId = 1, Brand = "Lacoste", Color = "blue", Gender = "man", Price = 20.29, Size = 12},
            new Shirt {ShirtId = 2, Brand = "Polo", Color = "blue", Gender = "man", Price = 49.99, Size = 15},
            new Shirt {ShirtId = 3, Brand = "Arrow", Color = "pink", Gender = "woman", Price = 39.50, Size = 8},
            new Shirt {ShirtId = 4, Brand = "Redtape", Color = "green", Gender = "woman", Price = 99, Size = 10}
        };

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }
    }
}

