using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiiTraining.Code.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiiTraining.Tests.TagHelpers
{
    [TestClass]
    public class TagHelpersTests
    {
        [TestMethod]
        public void TestButtonTagHelper()
        {
            //arrange
            var context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "uniqueid");
            var output = new TagHelperOutput("button", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

            //act
            var helper = new ButtonTagHelper
            {
                BsButtonColor = "valueToBeTested"
            };

            helper.Process(context, output);

            //assert
            Assert.AreEqual($"btn btn-{helper.BsButtonColor}", output.Attributes["class"].Value);
        }
    }
}
