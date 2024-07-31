using System.Collections.Generic;

namespace TechHrms.WebApp.Models
{
    public class ListViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
    }
}
