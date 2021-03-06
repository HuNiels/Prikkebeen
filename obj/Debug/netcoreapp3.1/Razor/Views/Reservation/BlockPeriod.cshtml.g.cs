#pragma checksum "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\Reservation\BlockPeriod.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2f7ba00edf7c4db55592b380352a82ee0afbb8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservation_BlockPeriod), @"mvc.1.0.view", @"/Views/Reservation/BlockPeriod.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\_ViewImports.cshtml"
using Acupunctuur;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\_ViewImports.cshtml"
using Acupunctuur.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2f7ba00edf7c4db55592b380352a82ee0afbb8b", @"/Views/Reservation/BlockPeriod.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a2961d1a39752e2aab0f1c21237c9298b4f6cc3", @"/Views/_ViewImports.cshtml")]
    public class Views_Reservation_BlockPeriod : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Acupunctuur.Models.BlockViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/BlockPeriod.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2 class=\"display-4 text-center\">Periode Blokkeren</h2>\r\n\r\n<div class=\"w-75 mx-auto\">\r\n\r\n");
#nullable restore
#line 7 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\Reservation\BlockPeriod.cshtml"
      
        string dateFormat = "yyyy-MM-dd";
        string today = Model.Today.ToString(dateFormat);

        switch (Model.Error) {
            case 1:

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p class=\"text-danger text-center\">Er staan reserveringen in de periode die u wil blokkeren</p>\r\n");
#nullable restore
#line 14 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\Reservation\BlockPeriod.cshtml"
                break;
            case 2:

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p class=\"text-danger text-center\">De einddatum en eindtijd is voor de startdatum en starttijd</p>\r\n");
#nullable restore
#line 17 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\Reservation\BlockPeriod.cshtml"
                break;
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 21 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\Reservation\BlockPeriod.cshtml"
     using (Html.BeginForm("BlockPeriod", "Reservation", FormMethod.Post)) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""container"">
            <div class=""mt-3"">
                <div class=""row"">
                    <div class=""col-4 px-0""></div>
                    <div class=""col-4 px-0"">
                        <div class=""container"">
                            <div class=""row"">
                                <div class=""col-5 px-0"">
                                    <label for=""stDate"">Start Datum</label>
                                </div>
                                <div class=""col-7 pl-1 pr-0"">
                                    <input class=""w-100"" type=""date"" id=""stDate"" name=""startDate""");
            BeginWriteAttribute("value", " value=\"", 1323, "\"", 1337, 1);
#nullable restore
#line 33 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\Reservation\BlockPeriod.cshtml"
WriteAttributeValue("", 1331, today, 1331, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("min", " min=\"", 1338, "\"", 1350, 1);
#nullable restore
#line 33 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\Reservation\BlockPeriod.cshtml"
WriteAttributeValue("", 1344, today, 1344, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-4 px-0""></div>
                </div>
                <div class=""row"">
                    <div class=""col-4 px-0""></div>
                    <div class=""col-4 px-0"">
                        <div class=""container"">
                            <div class=""row"">
                                <div class=""col-5 px-0"">
                                    <label for=""stTime"">Start Tijdstip</label>
                                </div>
                                <div class=""col-7 pl-1 pr-0"">
                                    <input class=""w-100"" type=""time"" id=""stTime"" name=""startTime"" value=""08:00"" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-4 px-0""></div>
                </div>
         ");
            WriteLiteral(@"   </div>
            <div class=""mt-3"">
                <div class=""row"">
                    <div class=""col-4 px-0""></div>
                    <div class=""col-4 px-0"">
                        <div class=""container"">
                            <div class=""row"">
                                <div class=""col-5 px-0"">
                                    <label for=""endDate"">Eind Datum</label>
                                </div>
                                <div class=""col-7 pl-1 pr-0"">
                                    <input class=""w-100"" type=""date"" id=""endDate"" name=""endDate""");
            BeginWriteAttribute("value", " value=\"", 2981, "\"", 2995, 1);
#nullable restore
#line 67 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\Reservation\BlockPeriod.cshtml"
WriteAttributeValue("", 2989, today, 2989, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("min", " min=\"", 2996, "\"", 3008, 1);
#nullable restore
#line 67 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\Reservation\BlockPeriod.cshtml"
WriteAttributeValue("", 3002, today, 3002, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-4 px-0""></div>
                </div>
                <div class=""row"">
                    <div class=""col-4 px-0""></div>
                    <div class=""col-4 px-0"">
                        <div class=""container"">
                            <div class=""row"">
                                <div class=""col-5 px-0"">
                                    <label for=""endTime"">Eind Tijdstip</label>
                                </div>
                                <div class=""col-7 pl-1 pr-0"">
                                    <input class=""w-100"" type=""time"" id=""endTime"" name=""endTime"" value=""20:00"" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-4 px-0""></div>
                </div>
          ");
            WriteLiteral(@"  </div>
            <div class=""row mt-3"">
                <div class=""col-4 px-0""></div>
                <div class=""col-4 px-0"">
                    <input class=""w-100"" type=""text"" maxlength=""50"" id=""description"" name=""description"" placeholder=""Beschrijving intern"" />
                </div>
                <div class=""col-4 px-0"">
                    <span class=""ml-2 text-nowrap text-danger"" id=""descriptionError""></span>
                </div>
            </div>
            <div class=""row mt-1"">
                <div class=""col-4 px-0""></div>
                <div class=""col-4 px-0"">
                    <textarea class=""w-100"" type=""text"" rows=""4"" id=""customerMessage"" name=""customerMessage"" placeholder=""Melding voor Klanten (optioneel)""></textarea>
                </div>
                <div class=""col-4 px-0""></div>
            </div>
            <div class=""row mt-1"">
                <div class=""col-4 px-0""></div>
                <div class=""col-4 px-0 text-center"">
                 ");
            WriteLiteral("   <input type=\"submit\" id=\"submit\" value=\"Blokkeren\" />\r\n                </div>\r\n                <div class=\"col-4 px-0\"></div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 115 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\Reservation\BlockPeriod.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2f7ba00edf7c4db55592b380352a82ee0afbb8b11831", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Acupunctuur.Models.BlockViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
