#pragma checksum "..\..\AddAlarmWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F25563D61F971685F860DBC12C695FBCB67712AA1D94A3972DC7BA870BA0BC06"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using ScadaGUI;
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


namespace ScadaGUI {
    
    
    /// <summary>
    /// AddAlarmWindow
    /// </summary>
    public partial class AddAlarmWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\AddAlarmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainAlarmGrid;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\AddAlarmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label alarmTypeLab;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\AddAlarmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label alarmNameLab;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\AddAlarmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label analogInputLab;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\AddAlarmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label alarmAddresLab;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\AddAlarmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label alarmMessageLab;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\AddAlarmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox alarmName;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\AddAlarmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox alarmType;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\AddAlarmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox analogInput;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\AddAlarmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox alarmLimitValue;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\AddAlarmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox aiDesc;
        
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
            System.Uri resourceLocater = new System.Uri("/ScadaGUI;component/addalarmwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddAlarmWindow.xaml"
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
            this.MainAlarmGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.alarmTypeLab = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.alarmNameLab = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.analogInputLab = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.alarmAddresLab = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.alarmMessageLab = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.alarmName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.alarmType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.analogInput = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.alarmLimitValue = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.aiDesc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            
            #line 87 "..\..\AddAlarmWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ConfirmButtonClick);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 88 "..\..\AddAlarmWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

