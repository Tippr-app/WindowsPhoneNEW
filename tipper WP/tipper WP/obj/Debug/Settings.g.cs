﻿

#pragma checksum "C:\Users\Morris Lowitz\Documents\GitHub\WindowsPhone\tipper WP\tipper WP\Settings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C0E2E51A8884C0E56023593A27A8FA11"
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
    partial class Settings : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 19 "..\..\Settings.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBlock)(target)).SelectionChanged += this.AccountInfoTitle_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 30 "..\..\Settings.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.confirmButtonUser_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


