using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Code.TagHelpers
{
    public class NoFollowTagHelper : TagHelper
    {
        // Public properties becomes available on our custom tag as an attribute.
        public string Href { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; // Specify our tag output name
            output.TagMode = TagMode.StartTagAndEndTag; // The type of tag we wish to create

            output.Attributes.SetAttribute("href", Href);
            if (!output.Attributes["href"].Value.ToString().Contains("sii.pl"))
            {
                output.Attributes.SetAttribute("rel", "nofollow");
            }

            base.Process(context, output);
        }
    }
}
