﻿

#pragma checksum "C:\Users\Morris Lowitz\Documents\GitHub\WindowsPhoneNEW\tipper WP\tipper WP\wallet.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F375B6F5D7A3B61A9A35149BB155A33C"
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
    partial class wallet : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 22 "..\..\wallet.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.goback_Tapped;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 23 "..\..\wallet.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.settings_Tapped;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 30 "..\..\wallet.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.add_funds_button_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


