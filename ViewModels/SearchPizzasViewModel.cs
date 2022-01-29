using PizzaPointProject.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaPointProject.ViewModels
{
    public class SearchPizzasViewModel
    {
        [Required]
        [DisplayName("Serach")]
        public string SearchText { get; set; }

        //public IEnumerable<string> SearchListExamples { get; set; }

        public IEnumerable<Pizzas> PizzaList { get; set; }

    }
}
