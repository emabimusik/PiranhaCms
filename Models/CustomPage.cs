using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using PiranhaBasic.Models.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiranhaBasic.Models
{
    [PageType(Title = "Custom Page")]
    [PageTypeRoute(Title = "Default" , Route = "/custom")]
    public class CustomPage:Page<CustomPage>
    {

        /// <summary>
        /// Gets/sets the available teasers.
        /// </summary>
        [Region(ListTitle = "Title")]
        public IList<CustomTeaser> CustomTeasers { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CustomPage()
        {
            CustomTeasers = new List<CustomTeaser>();
        }

    }
}
