﻿

#pragma checksum "C:\Users\Morris Lowitz\Documents\GitHub\WindowsPhone\tipper WP\tipper WP\tipping.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6063AAD9802F297FD2E82BD378B98876"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tipper_WP
{
    partial class tipping : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 14 "..\..\tipping.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.goback_Tapped;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 17 "..\..\tipping.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.confirmAmount_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


