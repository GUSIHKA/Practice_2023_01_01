﻿#pragma checksum "..\..\..\..\..\Views\Pages\EditOrderInformation.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61DA2B115250D2D6171512C2BBAA122397042FEC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using OptOK.Views.Pages;
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


namespace OptOK.Views.Pages {
    
    
    /// <summary>
    /// EditOrderInformation
    /// </summary>
    public partial class EditOrderInformation : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\..\Views\Pages\EditOrderInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PanelOrderInfo;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\Views\Pages\EditOrderInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbOrderStatus;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\Views\Pages\EditOrderInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbProductsQuantity;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\Views\Pages\EditOrderInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView orderProductList;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\..\Views\Pages\EditOrderInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSavew;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\..\Views\Pages\EditOrderInformation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OptOK;component/views/pages/editorderinformation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Pages\EditOrderInformation.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PanelOrderInfo = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.cbOrderStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.tbProductsQuantity = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.orderProductList = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.btnSavew = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\..\..\Views\Pages\EditOrderInformation.xaml"
            this.btnSavew.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\..\..\Views\Pages\EditOrderInformation.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

