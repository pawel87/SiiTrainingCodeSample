using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Code.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "href")]
    public class NoFollowTagHelper1 : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var href = output.Attributes["href"];
            if (!href.Value.ToString().Contains("sii.pl"))
            {
                output.Attributes.SetAttribute("rel", "nofollow");
            }

            base.Process(context, output);
        }
    }
}
