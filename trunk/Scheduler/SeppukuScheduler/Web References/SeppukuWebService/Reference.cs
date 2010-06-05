﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1.
// 
#pragma warning disable 1591

namespace SeppukuScheduler.SeppukuWebService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SeppukuServiceSoap", Namespace="http://seppuku.pl/")]
    public partial class SeppukuService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetUsersOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateGameStateOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SeppukuService() {
            this.Url = global::SeppukuScheduler.Properties.Settings.Default.SeppukuScheduler_SeppukuService_SeppukuService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetUsersCompletedEventHandler GetUsersCompleted;
        
        /// <remarks/>
        public event UpdateGameStateCompletedEventHandler UpdateGameStateCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://seppuku.pl/GetUsers", RequestNamespace="http://seppuku.pl/", ResponseNamespace="http://seppuku.pl/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public User[] GetUsers() {
            object[] results = this.Invoke("GetUsers", new object[0]);
            return ((User[])(results[0]));
        }
        
        /// <remarks/>
        public void GetUsersAsync() {
            this.GetUsersAsync(null);
        }
        
        /// <remarks/>
        public void GetUsersAsync(object userState) {
            if ((this.GetUsersOperationCompleted == null)) {
                this.GetUsersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUsersOperationCompleted);
            }
            this.InvokeAsync("GetUsers", new object[0], this.GetUsersOperationCompleted, userState);
        }
        
        private void OnGetUsersOperationCompleted(object arg) {
            if ((this.GetUsersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUsersCompleted(this, new GetUsersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://seppuku.pl/UpdateGameState", RequestNamespace="http://seppuku.pl/", ResponseNamespace="http://seppuku.pl/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string UpdateGameState() {
            object[] results = this.Invoke("UpdateGameState", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateGameStateAsync() {
            this.UpdateGameStateAsync(null);
        }
        
        /// <remarks/>
        public void UpdateGameStateAsync(object userState) {
            if ((this.UpdateGameStateOperationCompleted == null)) {
                this.UpdateGameStateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateGameStateOperationCompleted);
            }
            this.InvokeAsync("UpdateGameState", new object[0], this.UpdateGameStateOperationCompleted, userState);
        }
        
        private void OnUpdateGameStateOperationCompleted(object arg) {
            if ((this.UpdateGameStateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateGameStateCompleted(this, new UpdateGameStateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://seppuku.pl/")]
    public partial class User {
        
        private int userIdField;
        
        private string userNameField;
        
        private string emailField;
        
        private System.DateTime createDateField;
        
        private string passwordHashField;
        
        private System.Guid authorizatonKeyField;
        
        /// <remarks/>
        public int UserId {
            get {
                return this.userIdField;
            }
            set {
                this.userIdField = value;
            }
        }
        
        /// <remarks/>
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
        
        /// <remarks/>
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime CreateDate {
            get {
                return this.createDateField;
            }
            set {
                this.createDateField = value;
            }
        }
        
        /// <remarks/>
        public string PasswordHash {
            get {
                return this.passwordHashField;
            }
            set {
                this.passwordHashField = value;
            }
        }
        
        /// <remarks/>
        public System.Guid AuthorizatonKey {
            get {
                return this.authorizatonKeyField;
            }
            set {
                this.authorizatonKeyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetUsersCompletedEventHandler(object sender, GetUsersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUsersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUsersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public User[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((User[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void UpdateGameStateCompletedEventHandler(object sender, UpdateGameStateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateGameStateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateGameStateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591