﻿#pragma checksum "..\..\..\UserBooksWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C5ECCC44CBF3D64A92AA5DE2CDD953992A6D42C7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BookStoreTest;
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


namespace BookStoreTest {
    
    
    /// <summary>
    /// UserBooksWindow
    /// </summary>
    public partial class UserBooksWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\UserBooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView userBooksListView;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\UserBooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editBookButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\UserBooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button removeBookButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\UserBooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BookStoreTest;V1.0.0.0;component/userbookswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserBooksWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.userBooksListView = ((System.Windows.Controls.ListView)(target));
            
            #line 10 "..\..\..\UserBooksWindow.xaml"
            this.userBooksListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.userBooksListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.editBookButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\UserBooksWindow.xaml"
            this.editBookButton.Click += new System.Windows.RoutedEventHandler(this.EditBookButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.removeBookButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\UserBooksWindow.xaml"
            this.removeBookButton.Click += new System.Windows.RoutedEventHandler(this.RemoveBookButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\UserBooksWindow.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
