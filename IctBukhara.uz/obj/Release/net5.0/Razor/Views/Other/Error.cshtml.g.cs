#pragma checksum "C:\Users\Faxriddin\source\repos\IctBukhara.uz\IctBukhara.uz\Views\Other\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0caf5a060e429f6f3e0d36e08866f67a48737c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Other_Error), @"mvc.1.0.view", @"/Views/Other/Error.cshtml")]
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
#line 1 "C:\Users\Faxriddin\source\repos\IctBukhara.uz\IctBukhara.uz\Views\_ViewImports.cshtml"
using IctBukhara.uz;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Faxriddin\source\repos\IctBukhara.uz\IctBukhara.uz\Views\_ViewImports.cshtml"
using IctBukhara.uz.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Faxriddin\source\repos\IctBukhara.uz\IctBukhara.uz\Views\_ViewImports.cshtml"
using IctBukhara.uz.Models.PostModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Faxriddin\source\repos\IctBukhara.uz\IctBukhara.uz\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Faxriddin\source\repos\IctBukhara.uz\IctBukhara.uz\Views\_ViewImports.cshtml"
using IctBukhara.uz.Entitys.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Faxriddin\source\repos\IctBukhara.uz\IctBukhara.uz\Views\_ViewImports.cshtml"
using IctBukhara.uz.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0caf5a060e429f6f3e0d36e08866f67a48737c6", @"/Views/Other/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8052a96fdd6a9af8e7bebd7fd246b50237486fe9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Other_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script>
    const urlParams = new URLSearchParams(window.location.search);
    const msg = urlParams.get('msg');
    if (msg.length > 0) {
        alert(msg);
        document.getElementsByTagName('h1')[0].innerText=`Bag => ${msg}`
    }
</script>
<h1>Bag => </h1>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
