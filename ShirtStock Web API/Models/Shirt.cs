﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ShirtStock_Web_API.Models
{
	public class Shirt
	{
		public int ShirtId { get; set; }

		[Required]
		public string Brand { get; set; }

		[Required]
		public string Color { get; set; }

		public int? Size { get; set; }

		[Required]
		public string Gender { get; set; }

		public double? Price { get; set; }
	}
}
