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

    [PageType(Title = "Video Page")]
    [PageTypeRoute(Title = "Default", Route = "/video")]
    public class VideoPage:Page<VideoPage>
    {

        /// <summary>
        /// Gets/sets the available teasers.
        /// </summary>
        [Region(ListTitle = "Title")]
        public IList<MediaTeaser> MediaTeasers { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public VideoPage()
        {
            MediaTeasers = new List<MediaTeaser>();
        }
    }
}
