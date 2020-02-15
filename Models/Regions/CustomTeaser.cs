using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiranhaBasic.Models.Regions
{
    public class CustomTeaser
    {

        /// <summary>
        /// Gets/sets the main title.
        /// </summary>
        [Field(Options = FieldOption.HalfWidth)]
        public StringField Title { get; set; }

        /// <summary>
        /// Gets/sets the optional subtitle.
        /// </summary>
        [Field(Options = FieldOption.HalfWidth)]
        public StringField SubTitle { get; set; }

        [Field(Options = FieldOption.HalfWidth)]
        public ImageField Image { get; set; }
        /// <summary>
        /// Gets/sets the optional page link.
        /// </summary>
        [Field(Title = "Optional Page link")]
        public PageField PageLink { get; set; }

        /// <summary>
        /// Gets/sets the optional post link.
        /// </summary>
        [Field(Title = "Optional Post link")]
        public PostField PostLink { get; set; }

        /// <summary>
        /// Gets/sets the main body.
        /// </summary>
        [Field]
        public HtmlField Body { get; set; }

        public CustomTeaser()
        {
            PageLink = new PageField();
            PostLink = new PostField();
        }
    }
}
