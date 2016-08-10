using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace testASP.Models
{
    public enum Genre
    {
        Action, Comedy, Crime, Documentary, Drama, Family, Foreign, Horror, Romance, SciFi, Sports, Suspense,
            Teen, War
    }
    public class Film
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Budget { get; set; }
        public Genre Genre { get; set; }

        // Service property for multiple select
        [NotMapped]
        public int[] SelectedActorIds { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
    }
}