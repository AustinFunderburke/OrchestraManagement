#pragma checksum "C:\GitHub\OrchestraManagement\OrchestraManagement\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce46f2afab7bff892b0a2856605d45722e7bd587"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/About.cshtml", typeof(AspNetCore.Views_Home_About))]
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
#line 1 "C:\GitHub\OrchestraManagement\OrchestraManagement\Views\_ViewImports.cshtml"
using OrchestraManagement;

#line default
#line hidden
#line 2 "C:\GitHub\OrchestraManagement\OrchestraManagement\Views\_ViewImports.cshtml"
using OrchestraManagement.Models;

#line default
#line hidden
#line 3 "C:\GitHub\OrchestraManagement\OrchestraManagement\Views\_ViewImports.cshtml"
using OrchestraManagement.DbFirstData;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce46f2afab7bff892b0a2856605d45722e7bd587", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62745c3a4f8a08922cf2bb4e4b6b4b9e0dca5f3d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\GitHub\OrchestraManagement\OrchestraManagement\Views\Home\About.cshtml"
  
    ViewData["Title"] = "About Orchestra Management ";

#line default
#line hidden
            BeginContext(63, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(65, 495, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "019f3388f07f4a19bb87364249fd3f4c", async() => {
                BeginContext(71, 482, true);
                WriteLiteral(@"
    <style type=""text/css"">
        .featureList {
            border: dashed 2px black;
            background-color: rgba(215, 31, 31, 0.75);
            border-radius: 25px;
            color: white;
        }

        .featureList li {
            list-style: square;
            padding: 15px;
            font-size: 16px;
        }

        .featureList span {
            font-weight: bold;
            text-decoration: underline;
        }
    </style>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(560, 8, true);
            WriteLiteral("\r\n\r\n<h2>");
            EndContext();
            BeginContext(569, 17, false);
#line 27 "C:\GitHub\OrchestraManagement\OrchestraManagement\Views\Home\About.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(586, 4694, true);
            WriteLiteral(@"</h2>

<hr />

<h3>Orchestra Management Features</h3>

<br />

<ul class=""featureList"">
    <li>This application is designed to <span>manage</span> and <span>track</span> orchestras. The application’s features are designed to do this management easily and effectively. </li>
    <li><span>The Title Bar</span> - This feature is visible on all pages and can be accessed by clicking the words to each section. The Home link takes the user to the Home page and has the list of orchestras on it. The Manage Orchestra link takes you to the Manager Orchester page which helps you in any way to manager the orchestras on the page. The About link takes the user to the About page which gives a brief description about each feature. The Developer link takes the user to the Developer page which gives a brief description about the developer of this application and how to contact the developer via email.</li>
    <li><span>Home Page</span> - This application allows the user to manage orchestras. The page displays a list");
            WriteLiteral(@" of orchestras that shows each orchestra’s name, website URL, number of musicians in the orchestra, and displays the number of orchestras. There is also a link to the orchestra’s Details page. displays the number of orchestras.</li>
    <li><span>Manage Orchestras</span> - This page, allow the user to manage orchestras. It displays a list of orchestras that shows each orchestra’s information. Also, on this page it gives the number of musicians and gives links to Edit, Details, and Delete them. This page also allows the user to go back to the home page.</li>
    <li><span>Create Orchestra</span> - This page allows the user to enter an orchestra’s information. This information includes, the Orchestra’s name, address, city, state, zip code, and website URL. This site also allows the user to go back to list of orchestras</li>
    <li><span>Edit Orchestra</span> - This page allows the user to edit an orchestra’s data, except for the Id. The page also allows the user to go back to the orchestra’s manager page. <");
            WriteLiteral(@"/li>
    <li><span>Orchestra Details</span> - This page shows the user the orchestra’s information and the number of musicians. It also has a list of musicians in this orchestra and all their information. There is also links to edit, details, and delete pages for the musician here. The user will be able to create a musician, edit the orchestra, and go back to the list of orchestras.</li>
    <li><span>Delete Orchestra</span> - page confirms that the user wants to delete the orchestra they select and all its musicians. If user confirms the delete the orchestra’s data is deleted from the database along with its musicians. The user can also go back to the list of orchestras from this page.</li>
    <li><span>Create Musician</span> - This page allows the user to enter a musician’s data which is their name, section, and whether they are a section leader or not. This page also allows the user to go back to the orchestra’s details page.</li>
    <li><span>Edit Musician</span> - This page presents a form that all");
            WriteLiteral(@"ows the user to update a musician’s data excluding any ids. Also, it allows the user to go back to the orchestra’s details page. </li>
    <li><span>Musician Details </span> - This page output a musician’s information including its Id. It also output the list of instruments for this musician and all the instruments information. This page has a edit and delete links for the instrument as well. The page allows the user to create an instrument, edit this musician, and go back to the orchestra’s details page.</li>
    <li><span>Delete Musician </span> - ThisMusician page confirms if the user wants to delete this musician. If the user confirms the deletion the musician is deleted from the database. The user is also allowed to go back to the orchestra’s details page. </li>
    <li><span>Edit Musician</span> - This page presents a form that allows the user to update a musician’s data excluding any ids. Also, it allows the user to go back to the orchestra’s details page. </li>
    <li><span>Create Instrument</spa");
            WriteLiteral(@"n> - This page allows the user to enter an instrument’s data, serial number, description, maintenance date, and condition. Also allows the user to go back to the musician’s details page.</li>
    <li><span>Edit Instrument </span> - This page present a form that allows the user to update an instrument’s data. </li>
    <li><span>Delete Instrument </span> - This page confirms that the user wants to delete the instrument they are on. If the user confirms this then the instrument is deleted from the database. This page also allows the user to go back to the musician’s details page.</li>
</ul>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
