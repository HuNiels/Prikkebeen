#pragma checksum "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\User\Registration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6bed86b8ca98c0fa984ecfd785d5d9ea2d0a0d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Registration), @"mvc.1.0.view", @"/Views/User/Registration.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6bed86b8ca98c0fa984ecfd785d5d9ea2d0a0d2", @"/Views/User/Registration.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a2961d1a39752e2aab0f1c21237c9298b4f6cc3", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Registration : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Acupunctuur.Models.RegistrationViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Nederland", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "België", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Duitsland", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Registration.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2 class=\"display-4 text-center\">Registratieformulier</h2>\r\n\r\n<div class=\"w-75 mx-auto\">\r\n\r\n");
#nullable restore
#line 7 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\User\Registration.cshtml"
      
        string dateFormat = "yyyy-MM-dd";
        string selectedDay = @Model.SelectedDay.ToString(dateFormat);

        if (Model.Error == 1) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p class=\"text-danger text-center\">Klant staat al geregistreerd</p>\r\n");
#nullable restore
#line 13 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\User\Registration.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 16 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\User\Registration.cshtml"
     using (Html.BeginForm("Registration", "User", FormMethod.Post)) {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\User\Registration.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <input class=""w-100"" type=""text"" id=""firstName"" name=""firstName"" placeholder=""Voornaam"" autofocus />
        </div>
        <div class=""col-4 px-0"">
            <span class=""ml-2 text-nowrap text-danger"" id=""firstNameError""></span>
        </div>
    </div>
    <div class=""row mt-1"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <input class=""w-100"" type=""text"" id=""lastName"" name=""lastName"" placeholder=""Achternaam"" />
        </div>
        <div class=""col-4 px-0"">
            <span class=""ml-2 text-nowrap text-danger"" id=""lastNameError""></span>
        </div>
    </div>
    <div class=""row mt-3"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-5 px-0"">
                        <label for=""dob");
            WriteLiteral("Field\">Geboortedatum</label>\r\n                    </div>\r\n                    <div class=\"col-7 pl-1 pr-0\">\r\n                        <input class=\"w-100\" type=\"date\" id=\"dobField\" name=\"dateOfBirth\"");
            BeginWriteAttribute("value", " value=\"", 1730, "\"", 1750, 1);
#nullable restore
#line 46 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\User\Registration.cshtml"
WriteAttributeValue("", 1738, selectedDay, 1738, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("max", " max=\"", 1751, "\"", 1769, 1);
#nullable restore
#line 46 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\User\Registration.cshtml"
WriteAttributeValue("", 1757, selectedDay, 1757, 12, false);

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
    <div class=""row mt-3"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-8 px-0"">
                        <input class=""w-100"" type=""text"" id=""address"" name=""address"" placeholder=""Adres"" />
                    </div>
                    <div class=""col-4 pl-1 pr-0"">
                        <input class=""w-100"" type=""text"" id=""houseNumber"" name=""houseNumber"" placeholder=""Huisnr."" />
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-4 px-0"">
            <span class=""ml-2 text-nowrap text-danger"" id=""addressError""></span>
        </div>
    </div>
    <div class=""row mt-1"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <input");
            WriteLiteral(@" class=""w-100"" type=""text"" id=""postalCode"" name=""postalCode"" placeholder=""Postcode"" />
        </div>
        <div class=""col-4 px-0"">
            <span class=""ml-2 text-nowrap text-danger"" id=""postalCodeError""></span>
        </div>
    </div>
    <div class=""row mt-1"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <input class=""w-100"" type=""text"" id=""city"" name=""city"" placeholder=""Woonplaats"" />
        </div>
        <div class=""col-4 px-0"">
            <span class=""ml-2 text-nowrap text-danger"" id=""cityError""></span>
        </div>
    </div>
    <div class=""row mt-1"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <select class=""w-100 mx-auto"" id=""country"" name=""country"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6bed86b8ca98c0fa984ecfd785d5d9ea2d0a0d210105", async() => {
                WriteLiteral("Nederland");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6bed86b8ca98c0fa984ecfd785d5d9ea2d0a0d211284", async() => {
                WriteLiteral("België");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6bed86b8ca98c0fa984ecfd785d5d9ea2d0a0d212460", async() => {
                WriteLiteral("Duitsland");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </select>
        </div>
        <div class=""col-4 px-0""></div>
    </div>
    <div class=""row mt-3"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-2 pl-0 pr-1"">
                        <input class=""w-100"" type=""text"" id=""telephoneNumberPrefix"" value=""+31"" disabled/>
                    </div>
                    <div class=""col-10 px-0"">
                        <input class=""w-100"" type=""tel"" id=""telephoneNumberMain"" placeholder=""Telefoonnummer"" />
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-4 px-0"">
            <span class=""ml-2 text-nowrap text-danger"" id=""telephoneNumberError""></span>
        </div>
    </div>
    <div class=""row mt-1"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <input class=""w-100"" type=""email"" id=""email"" name=""emai");
            WriteLiteral(@"l"" placeholder=""Emailadres"" />
        </div>
        <div class=""col-4 px-0"">
            <span class=""ml-2 text-nowrap text-danger"" id=""emailError""></span>
        </div>
    </div>
    <div class=""row mt-3"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <span class=""text-secondary"">
                <small>Wachtwoord eisen:</small>
            </span>
            <ul class=""my-auto text-secondary"">
                <li><small>Maximaal 64 karakters</small></li>
                <li><small>Minimaal 1 letter</small></li>
                <li><small>Speciale tekens: alleen ");
            WriteLiteral(@"@#$%!&* toegestaan</small></li>
            </ul>
        </div>
        <div class=""col-4 px-0""></div>
    </div>
    <div class=""row mt-1"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <input class=""w-100"" type=""password"" id=""password1"" name=""password"" placeholder=""Wachtwoord"" />
        </div>
        <div class=""col-4 px-0"">
            <span class=""ml-2 text-nowrap text-danger"" id=""passwordError""></span>
        </div>
    </div>
    <div class=""row mt-1"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <input class=""w-100"" type=""password"" id=""password2"" placeholder=""Wachtwoord herhalen"" />
        </div>
        <div class=""col-4 px-0""></div>
    </div>
    <div class=""row mt-3"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <input type=""radio"" id=""radioNewUser"" name=""newUser"" value=""true"" checked />
            <label for=""radioNewUser"">Nieuwe klant</label>
        ");
            WriteLiteral(@"</div>
    </div>
    <div class=""row"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0"">
            <input type=""radio"" id=""radioExistingUser"" name=""newUser"" value=""false"" />
            <label for=""radioExistingUser"">Bestaande klant</label>
        </div>
    </div>
    <div class=""row mt-1"">
        <div class=""col-4 px-0""></div>
        <div class=""col-4 px-0 text-center"">
            <input type=""submit"" id=""submit"" value=""Registreren"" />
        </div>
    </div>

    <input type=""hidden"" id=""telephoneNumber"" name=""telephoneNumber""/>
</div>
");
#nullable restore
#line 180 "C:\Users\niels\source\repos\Acupunctuur\Acupunctuur\Views\User\Registration.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6bed86b8ca98c0fa984ecfd785d5d9ea2d0a0d217461", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Acupunctuur.Models.RegistrationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
