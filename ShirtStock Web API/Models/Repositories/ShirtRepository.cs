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

        public static List<Shirt> GetShirts()
        {
            return shirts;
        }

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtByProperties(string brand, string color, int? size, string gender)
        {
            return shirts.FirstOrDefault(x =>
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            x.Size.HasValue && size.HasValue && x.Size == size.Value &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)
            );
        }

        public static void CreateShirt(Shirt shirt)
        {
            int maxId = shirts.Max(x => x.ShirtId);
            shirt.ShirtId = maxId + 1;
            shirts.Add(shirt);
        }

        public static void UpdateShirt(Shirt shirt)
        {
            var shirtToUpdate = shirts.First(x => x.ShirtId == shirt.ShirtId);
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Size = shirt.Size;
        }

        public static void DeleteShirt(int id)
        {
            var shirtToDelete = GetShirtById(id);
            if (shirtToDelete != null)
            {
                shirts.Remove(shirtToDelete);
            }
        }
    }
}

