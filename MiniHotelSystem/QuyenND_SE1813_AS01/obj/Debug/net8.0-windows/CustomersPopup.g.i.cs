﻿#pragma checksum "..\..\..\CustomersPopup.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CB175CFB3831224088964F994F1A57784F42800D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QuyenND_SE1813_AS01;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace QuyenND_SE1813_AS01 {
    
    
    /// <summary>
    /// CustomersPopup
    /// </summary>
    public partial class CustomersPopup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\CustomersPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomerId;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\CustomersPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFullName;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\CustomersPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTelePhone;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\CustomersPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\CustomersPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpDate;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\CustomersPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\CustomersPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddRoom;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\CustomersPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBackRoom;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/QuyenND_SE1813_AS01;component/customerspopup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CustomersPopup.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtCustomerId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtFullName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtTelePhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.dtpDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.txtPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnAddRoom = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\CustomersPopup.xaml"
            this.btnAddRoom.Click += new System.Windows.RoutedEventHandler(this.btnAddRoom_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnBackRoom = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\..\CustomersPopup.xaml"
            this.btnBackRoom.Click += new System.Windows.RoutedEventHandler(this.btnBackRoom_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

