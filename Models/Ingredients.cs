﻿using System.ComponentModel.DataAnnotations;

namespace PizzaPointProject.Models
{
    public class Ingredients
    {
        public Ingredients()
        {
            PizzaIngredients = new List<PizzaIngredients>();
        }

        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "The field Name should only include letters and number.")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<PizzaIngredients> PizzaIngredients { get; set; }

    }
}