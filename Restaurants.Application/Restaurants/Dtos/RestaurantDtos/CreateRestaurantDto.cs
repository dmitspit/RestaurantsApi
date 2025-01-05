﻿using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.Dtos.RestaurantDtos
{
    public class CreateRestaurantDto
    {
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        [Required(ErrorMessage = "Insert a valid category")]
        public string Category { get; set; } = default!;

        public bool HasDelivery { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? ContactEmail { get; set; } = default!;

        [Phone(ErrorMessage = "Provide phone number")]
        public string? ContactNumber { get; set; } = default!;

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? PostalCode { get; set; }
    }
}
