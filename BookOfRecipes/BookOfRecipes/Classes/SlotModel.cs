using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfRecipes.Classes
{
    public class SlotModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NameOfAuthor { get; set; }
        public string Photo { get; set; }
        public float Grade { get; set; }
        public int Time { get; set; }
        public List<IngridientModel> Ingridients { get; set; }
        public string CookingSteps { get; set; }
        public DateTime DateOfPublish { get; set; }
        public int Colories { get; set; }
    }
}
