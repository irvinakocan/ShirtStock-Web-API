﻿using System;
namespace ShirtStock_Web_API.Models.Repositories
{
	public static class ShirtRepository
	{
        public static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt { ShirtId = 1, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 30, Size = 10},
            new Shirt { ShirtId = 2, Brand = "My Brand", Color = "Black", Gender = "Men", Price = 35, Size = 12},
            new Shirt { ShirtId = 3, Brand = "My Brand", Color = "Pink", Gender = "Women", Price = 28, Size = 8},
            new Shirt { ShirtId = 4, Brand = "My Brand", Color = "Yellow", Gender = "Women", Price = 30, Size = 9}
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

        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
            return shirts.FirstOrDefault(x =>
            !string.IsNullOrEmpty(brand) &&
            !string.IsNullOrEmpty(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrEmpty(gender) &&
            !string.IsNullOrEmpty(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrEmpty(color) &&
            !string.IsNullOrEmpty(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            x.Size == size);
        }

        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(x => x.ShirtId);
            shirt.ShirtId = maxId + 1;

            shirts.Add(shirt);
        }

        public static void UpdateShirt(Shirt shirt)
        {
            var shirtToUpdate = shirts.First(x => shirt.ShirtId == x.ShirtId);

            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Size = shirt.Size;
        }

        public static void DeleteShirt(int shirtId)
        {
            var shirt = GetShirtById(shirtId);

            if (shirt != null)
            {
                shirts.Remove(shirt);
            }
        }
    }
}

