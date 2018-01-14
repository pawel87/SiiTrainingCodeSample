using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SiiTraining.Code.TagHelpers
{
    [HtmlTargetElement("img", Attributes = "gravatar-email")]
    public class GravatarTagHelper : TagHelper
    {
        [HtmlAttributeName("gravatar-email")]
        public string Email { get; set; }

        [HtmlAttributeName("gravatar-size")]
        public int Size { get; set; } = 50;


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(Email));
                var hash = BitConverter.ToString(result).Replace("-", "").ToLower();
                var url = $"http://gravatar.com/avatar/{hash}";
                var queryBuilder = new QueryBuilder();
                queryBuilder.Add("s", Size.ToString());
                url = url + queryBuilder.ToQueryString();
                output.Attributes.SetAttribute("src", url);
            }
        }

    }
}
