﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CommunityWebsite.Infrastructure.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "navigationButton")]
    public class AnchorTagHelper : TagHelper
    {
        public string HoverStyle { get; set; }
        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", $"{HoverStyle}");
        }
    }
}
