﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 3.0.40624.0
// 
namespace SeppukuMap.SeppukuService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://seppuku.pl/")]
    public partial class User : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int UserIdField;
        
        private string UserNameField;
        
        private string EmailField;
        
        private System.DateTime CreateDateField;
        
        private string PasswordHashField;
        
        private System.Guid AuthorizatonKeyField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public System.DateTime CreateDate {
            get {
                return this.CreateDateField;
            }
            set {
                if ((this.CreateDateField.Equals(value) != true)) {
                    this.CreateDateField = value;
                    this.RaisePropertyChanged("CreateDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string PasswordHash {
            get {
                return this.PasswordHashField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordHashField, value) != true)) {
                    this.PasswordHashField = value;
                    this.RaisePropertyChanged("PasswordHash");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public System.Guid AuthorizatonKey {
            get {
                return this.AuthorizatonKeyField;
            }
            set {
                if ((this.AuthorizatonKeyField.Equals(value) != true)) {
                    this.AuthorizatonKeyField = value;
                    this.RaisePropertyChanged("AuthorizatonKey");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TileInfo", Namespace="http://seppuku.pl/")]
    public partial class TileInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int xField;
        
        private int yField;
        
        private string nameField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int x {
            get {
                return this.xField;
            }
            set {
                if ((this.xField.Equals(value) != true)) {
                    this.xField = value;
                    this.RaisePropertyChanged("x");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int y {
            get {
                return this.yField;
            }
            set {
                if ((this.yField.Equals(value) != true)) {
                    this.yField = value;
                    this.RaisePropertyChanged("y");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://seppuku.pl/", ConfigurationName="SeppukuService.SeppukuServiceSoap")]
    public interface SeppukuServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://seppuku.pl/GetUsers", ReplyAction="*")]
        System.IAsyncResult BeginGetUsers(SeppukuMap.SeppukuService.GetUsersRequest request, System.AsyncCallback callback, object asyncState);
        
        SeppukuMap.SeppukuService.GetUsersResponse EndGetUsers(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://seppuku.pl/UpdateGameState", ReplyAction="*")]
        System.IAsyncResult BeginUpdateGameState(SeppukuMap.SeppukuService.UpdateGameStateRequest request, System.AsyncCallback callback, object asyncState);
        
        SeppukuMap.SeppukuService.UpdateGameStateResponse EndUpdateGameState(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://seppuku.pl/GetTiles", ReplyAction="*")]
        System.IAsyncResult BeginGetTiles(SeppukuMap.SeppukuService.GetTilesRequest request, System.AsyncCallback callback, object asyncState);
        
        SeppukuMap.SeppukuService.GetTilesResponse EndGetTiles(System.IAsyncResult result);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetUsersRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetUsers", Namespace="http://seppuku.pl/", Order=0)]
        public SeppukuMap.SeppukuService.GetUsersRequestBody Body;
        
        public GetUsersRequest() {
        }
        
        public GetUsersRequest(SeppukuMap.SeppukuService.GetUsersRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetUsersRequestBody {
        
        public GetUsersRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetUsersResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetUsersResponse", Namespace="http://seppuku.pl/", Order=0)]
        public SeppukuMap.SeppukuService.GetUsersResponseBody Body;
        
        public GetUsersResponse() {
        }
        
        public GetUsersResponse(SeppukuMap.SeppukuService.GetUsersResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://seppuku.pl/")]
    public partial class GetUsersResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.ObjectModel.ObservableCollection<SeppukuMap.SeppukuService.User> GetUsersResult;
        
        public GetUsersResponseBody() {
        }
        
        public GetUsersResponseBody(System.Collections.ObjectModel.ObservableCollection<SeppukuMap.SeppukuService.User> GetUsersResult) {
            this.GetUsersResult = GetUsersResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateGameStateRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdateGameState", Namespace="http://seppuku.pl/", Order=0)]
        public SeppukuMap.SeppukuService.UpdateGameStateRequestBody Body;
        
        public UpdateGameStateRequest() {
        }
        
        public UpdateGameStateRequest(SeppukuMap.SeppukuService.UpdateGameStateRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class UpdateGameStateRequestBody {
        
        public UpdateGameStateRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateGameStateResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdateGameStateResponse", Namespace="http://seppuku.pl/", Order=0)]
        public SeppukuMap.SeppukuService.UpdateGameStateResponseBody Body;
        
        public UpdateGameStateResponse() {
        }
        
        public UpdateGameStateResponse(SeppukuMap.SeppukuService.UpdateGameStateResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://seppuku.pl/")]
    public partial class UpdateGameStateResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string UpdateGameStateResult;
        
        public UpdateGameStateResponseBody() {
        }
        
        public UpdateGameStateResponseBody(string UpdateGameStateResult) {
            this.UpdateGameStateResult = UpdateGameStateResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetTilesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetTiles", Namespace="http://seppuku.pl/", Order=0)]
        public SeppukuMap.SeppukuService.GetTilesRequestBody Body;
        
        public GetTilesRequest() {
        }
        
        public GetTilesRequest(SeppukuMap.SeppukuService.GetTilesRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetTilesRequestBody {
        
        public GetTilesRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetTilesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetTilesResponse", Namespace="http://seppuku.pl/", Order=0)]
        public SeppukuMap.SeppukuService.GetTilesResponseBody Body;
        
        public GetTilesResponse() {
        }
        
        public GetTilesResponse(SeppukuMap.SeppukuService.GetTilesResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://seppuku.pl/")]
    public partial class GetTilesResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.ObjectModel.ObservableCollection<SeppukuMap.SeppukuService.TileInfo> GetTilesResult;
        
        public GetTilesResponseBody() {
        }
        
        public GetTilesResponseBody(System.Collections.ObjectModel.ObservableCollection<SeppukuMap.SeppukuService.TileInfo> GetTilesResult) {
            this.GetTilesResult = GetTilesResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface SeppukuServiceSoapChannel : SeppukuMap.SeppukuService.SeppukuServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class GetUsersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetUsersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<SeppukuMap.SeppukuService.User> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<SeppukuMap.SeppukuService.User>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class UpdateGameStateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public UpdateGameStateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class GetTilesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetTilesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<SeppukuMap.SeppukuService.TileInfo> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<SeppukuMap.SeppukuService.TileInfo>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class SeppukuServiceSoapClient : System.ServiceModel.ClientBase<SeppukuMap.SeppukuService.SeppukuServiceSoap>, SeppukuMap.SeppukuService.SeppukuServiceSoap {
        
        private BeginOperationDelegate onBeginGetUsersDelegate;
        
        private EndOperationDelegate onEndGetUsersDelegate;
        
        private System.Threading.SendOrPostCallback onGetUsersCompletedDelegate;
        
        private BeginOperationDelegate onBeginUpdateGameStateDelegate;
        
        private EndOperationDelegate onEndUpdateGameStateDelegate;
        
        private System.Threading.SendOrPostCallback onUpdateGameStateCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetTilesDelegate;
        
        private EndOperationDelegate onEndGetTilesDelegate;
        
        private System.Threading.SendOrPostCallback onGetTilesCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public SeppukuServiceSoapClient() {
        }
        
        public SeppukuServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SeppukuServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SeppukuServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SeppukuServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<GetUsersCompletedEventArgs> GetUsersCompleted;
        
        public event System.EventHandler<UpdateGameStateCompletedEventArgs> UpdateGameStateCompleted;
        
        public event System.EventHandler<GetTilesCompletedEventArgs> GetTilesCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SeppukuMap.SeppukuService.SeppukuServiceSoap.BeginGetUsers(SeppukuMap.SeppukuService.GetUsersRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetUsers(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.IAsyncResult BeginGetUsers(System.AsyncCallback callback, object asyncState) {
            SeppukuMap.SeppukuService.GetUsersRequest inValue = new SeppukuMap.SeppukuService.GetUsersRequest();
            inValue.Body = new SeppukuMap.SeppukuService.GetUsersRequestBody();
            return ((SeppukuMap.SeppukuService.SeppukuServiceSoap)(this)).BeginGetUsers(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SeppukuMap.SeppukuService.GetUsersResponse SeppukuMap.SeppukuService.SeppukuServiceSoap.EndGetUsers(System.IAsyncResult result) {
            return base.Channel.EndGetUsers(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.Collections.ObjectModel.ObservableCollection<SeppukuMap.SeppukuService.User> EndGetUsers(System.IAsyncResult result) {
            SeppukuMap.SeppukuService.GetUsersResponse retVal = ((SeppukuMap.SeppukuService.SeppukuServiceSoap)(this)).EndGetUsers(result);
            return retVal.Body.GetUsersResult;
        }
        
        private System.IAsyncResult OnBeginGetUsers(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetUsers(callback, asyncState);
        }
        
        private object[] OnEndGetUsers(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<SeppukuMap.SeppukuService.User> retVal = this.EndGetUsers(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetUsersCompleted(object state) {
            if ((this.GetUsersCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetUsersCompleted(this, new GetUsersCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetUsersAsync() {
            this.GetUsersAsync(null);
        }
        
        public void GetUsersAsync(object userState) {
            if ((this.onBeginGetUsersDelegate == null)) {
                this.onBeginGetUsersDelegate = new BeginOperationDelegate(this.OnBeginGetUsers);
            }
            if ((this.onEndGetUsersDelegate == null)) {
                this.onEndGetUsersDelegate = new EndOperationDelegate(this.OnEndGetUsers);
            }
            if ((this.onGetUsersCompletedDelegate == null)) {
                this.onGetUsersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetUsersCompleted);
            }
            base.InvokeAsync(this.onBeginGetUsersDelegate, null, this.onEndGetUsersDelegate, this.onGetUsersCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SeppukuMap.SeppukuService.SeppukuServiceSoap.BeginUpdateGameState(SeppukuMap.SeppukuService.UpdateGameStateRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUpdateGameState(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.IAsyncResult BeginUpdateGameState(System.AsyncCallback callback, object asyncState) {
            SeppukuMap.SeppukuService.UpdateGameStateRequest inValue = new SeppukuMap.SeppukuService.UpdateGameStateRequest();
            inValue.Body = new SeppukuMap.SeppukuService.UpdateGameStateRequestBody();
            return ((SeppukuMap.SeppukuService.SeppukuServiceSoap)(this)).BeginUpdateGameState(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SeppukuMap.SeppukuService.UpdateGameStateResponse SeppukuMap.SeppukuService.SeppukuServiceSoap.EndUpdateGameState(System.IAsyncResult result) {
            return base.Channel.EndUpdateGameState(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private string EndUpdateGameState(System.IAsyncResult result) {
            SeppukuMap.SeppukuService.UpdateGameStateResponse retVal = ((SeppukuMap.SeppukuService.SeppukuServiceSoap)(this)).EndUpdateGameState(result);
            return retVal.Body.UpdateGameStateResult;
        }
        
        private System.IAsyncResult OnBeginUpdateGameState(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginUpdateGameState(callback, asyncState);
        }
        
        private object[] OnEndUpdateGameState(System.IAsyncResult result) {
            string retVal = this.EndUpdateGameState(result);
            return new object[] {
                    retVal};
        }
        
        private void OnUpdateGameStateCompleted(object state) {
            if ((this.UpdateGameStateCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateGameStateCompleted(this, new UpdateGameStateCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UpdateGameStateAsync() {
            this.UpdateGameStateAsync(null);
        }
        
        public void UpdateGameStateAsync(object userState) {
            if ((this.onBeginUpdateGameStateDelegate == null)) {
                this.onBeginUpdateGameStateDelegate = new BeginOperationDelegate(this.OnBeginUpdateGameState);
            }
            if ((this.onEndUpdateGameStateDelegate == null)) {
                this.onEndUpdateGameStateDelegate = new EndOperationDelegate(this.OnEndUpdateGameState);
            }
            if ((this.onUpdateGameStateCompletedDelegate == null)) {
                this.onUpdateGameStateCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateGameStateCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateGameStateDelegate, null, this.onEndUpdateGameStateDelegate, this.onUpdateGameStateCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SeppukuMap.SeppukuService.SeppukuServiceSoap.BeginGetTiles(SeppukuMap.SeppukuService.GetTilesRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetTiles(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.IAsyncResult BeginGetTiles(System.AsyncCallback callback, object asyncState) {
            SeppukuMap.SeppukuService.GetTilesRequest inValue = new SeppukuMap.SeppukuService.GetTilesRequest();
            inValue.Body = new SeppukuMap.SeppukuService.GetTilesRequestBody();
            return ((SeppukuMap.SeppukuService.SeppukuServiceSoap)(this)).BeginGetTiles(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SeppukuMap.SeppukuService.GetTilesResponse SeppukuMap.SeppukuService.SeppukuServiceSoap.EndGetTiles(System.IAsyncResult result) {
            return base.Channel.EndGetTiles(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.Collections.ObjectModel.ObservableCollection<SeppukuMap.SeppukuService.TileInfo> EndGetTiles(System.IAsyncResult result) {
            SeppukuMap.SeppukuService.GetTilesResponse retVal = ((SeppukuMap.SeppukuService.SeppukuServiceSoap)(this)).EndGetTiles(result);
            return retVal.Body.GetTilesResult;
        }
        
        private System.IAsyncResult OnBeginGetTiles(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetTiles(callback, asyncState);
        }
        
        private object[] OnEndGetTiles(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<SeppukuMap.SeppukuService.TileInfo> retVal = this.EndGetTiles(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetTilesCompleted(object state) {
            if ((this.GetTilesCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetTilesCompleted(this, new GetTilesCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetTilesAsync() {
            this.GetTilesAsync(null);
        }
        
        public void GetTilesAsync(object userState) {
            if ((this.onBeginGetTilesDelegate == null)) {
                this.onBeginGetTilesDelegate = new BeginOperationDelegate(this.OnBeginGetTiles);
            }
            if ((this.onEndGetTilesDelegate == null)) {
                this.onEndGetTilesDelegate = new EndOperationDelegate(this.OnEndGetTiles);
            }
            if ((this.onGetTilesCompletedDelegate == null)) {
                this.onGetTilesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTilesCompleted);
            }
            base.InvokeAsync(this.onBeginGetTilesDelegate, null, this.onEndGetTilesDelegate, this.onGetTilesCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override SeppukuMap.SeppukuService.SeppukuServiceSoap CreateChannel() {
            return new SeppukuServiceSoapClientChannel(this);
        }
        
        private class SeppukuServiceSoapClientChannel : ChannelBase<SeppukuMap.SeppukuService.SeppukuServiceSoap>, SeppukuMap.SeppukuService.SeppukuServiceSoap {
            
            public SeppukuServiceSoapClientChannel(System.ServiceModel.ClientBase<SeppukuMap.SeppukuService.SeppukuServiceSoap> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetUsers(SeppukuMap.SeppukuService.GetUsersRequest request, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = request;
                System.IAsyncResult _result = base.BeginInvoke("GetUsers", _args, callback, asyncState);
                return _result;
            }
            
            public SeppukuMap.SeppukuService.GetUsersResponse EndGetUsers(System.IAsyncResult result) {
                object[] _args = new object[0];
                SeppukuMap.SeppukuService.GetUsersResponse _result = ((SeppukuMap.SeppukuService.GetUsersResponse)(base.EndInvoke("GetUsers", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginUpdateGameState(SeppukuMap.SeppukuService.UpdateGameStateRequest request, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = request;
                System.IAsyncResult _result = base.BeginInvoke("UpdateGameState", _args, callback, asyncState);
                return _result;
            }
            
            public SeppukuMap.SeppukuService.UpdateGameStateResponse EndUpdateGameState(System.IAsyncResult result) {
                object[] _args = new object[0];
                SeppukuMap.SeppukuService.UpdateGameStateResponse _result = ((SeppukuMap.SeppukuService.UpdateGameStateResponse)(base.EndInvoke("UpdateGameState", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetTiles(SeppukuMap.SeppukuService.GetTilesRequest request, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = request;
                System.IAsyncResult _result = base.BeginInvoke("GetTiles", _args, callback, asyncState);
                return _result;
            }
            
            public SeppukuMap.SeppukuService.GetTilesResponse EndGetTiles(System.IAsyncResult result) {
                object[] _args = new object[0];
                SeppukuMap.SeppukuService.GetTilesResponse _result = ((SeppukuMap.SeppukuService.GetTilesResponse)(base.EndInvoke("GetTiles", _args, result)));
                return _result;
            }
        }
    }
}
