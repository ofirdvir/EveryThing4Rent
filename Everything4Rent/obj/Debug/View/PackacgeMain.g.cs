﻿#pragma checksum "..\..\..\View\PackacgeMain.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9970E0923088B9A1610E592C012E7614"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Everything4Rent.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Everything4Rent.View {
    
    
    /// <summary>
    /// PackacgeMain
    /// </summary>
    public partial class PackacgeMain : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\View\PackacgeMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\View\PackacgeMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock boxRandTreshold;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\View\PackacgeMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddPackage;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\View\PackacgeMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox deadline;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\View\PackacgeMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Policy;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\View\PackacgeMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox tresh;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\View\PackacgeMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox typOfAdd;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\View\PackacgeMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox topicNameText;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\View\PackacgeMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nameOfTopic;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Everything4Rent;component/view/packacgemain.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\PackacgeMain.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\View\PackacgeMain.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.boxRandTreshold = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.AddPackage = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\View\PackacgeMain.xaml"
            this.AddPackage.Click += new System.Windows.RoutedEventHandler(this.AddPackage_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.deadline = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Policy = ((System.Windows.Controls.ComboBox)(target));
            
            #line 84 "..\..\..\View\PackacgeMain.xaml"
            this.Policy.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Policy_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tresh = ((System.Windows.Controls.ComboBox)(target));
            
            #line 100 "..\..\..\View\PackacgeMain.xaml"
            this.tresh.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Policy_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.typOfAdd = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.topicNameText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.nameOfTopic = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

