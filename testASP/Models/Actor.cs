using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace testASP.Models
{
    public enum Sex
    {
        Male, Female
    }
    public class Actor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public Sex? Sex { get; set; }
        public int? Age { get; set; }

        // Service property for multiple select
        [NotMapped]
        public int[] SelectedFilmIds { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}