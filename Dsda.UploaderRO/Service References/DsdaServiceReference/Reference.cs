﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dsda.UploaderRO.DsdaServiceReference {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dmotorworks.com/pip-dsda")]
    public partial class PIPException : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dmotorworks.com/pip-dsda")]
    public partial class status : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string errorCodeField;
        
        private string messageField;
        
        private resultCode status1Field;
        
        private bool status1FieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string errorCode {
            get {
                return this.errorCodeField;
            }
            set {
                this.errorCodeField = value;
                this.RaisePropertyChanged("errorCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("status", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public resultCode status1 {
            get {
                return this.status1Field;
            }
            set {
                this.status1Field = value;
                this.RaisePropertyChanged("status1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool status1Specified {
            get {
                return this.status1FieldSpecified;
            }
            set {
                this.status1FieldSpecified = value;
                this.RaisePropertyChanged("status1Specified");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dmotorworks.com/pip-dsda")]
    public enum resultCode {
        
        /// <remarks/>
        success,
        
        /// <remarks/>
        failure,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dmotorworks.com/pip-dsda")]
    public partial class dsdaUploadReply : object, System.ComponentModel.INotifyPropertyChanged {
        
        private status statusField;
        
        private string uploadIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public status status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
                this.RaisePropertyChanged("status");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string uploadId {
            get {
                return this.uploadIdField;
            }
            set {
                this.uploadIdField = value;
                this.RaisePropertyChanged("uploadId");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dmotorworks.com/pip-dsda")]
    public partial class dsdaFileMetaData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string annotationField;
        
        private string cabidField;
        
        private string docdateField;
        
        private string docdescField;
        
        private string docflagsField;
        
        private string docidField;
        
        private string docsstypeField;
        
        private long fileSizeField;
        
        private bool fileSizeFieldSpecified;
        
        private string foldescField;
        
        private string folflagsField;
        
        private string folidField;
        
        private string tagNamesField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string annotation {
            get {
                return this.annotationField;
            }
            set {
                this.annotationField = value;
                this.RaisePropertyChanged("annotation");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string cabid {
            get {
                return this.cabidField;
            }
            set {
                this.cabidField = value;
                this.RaisePropertyChanged("cabid");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string docdate {
            get {
                return this.docdateField;
            }
            set {
                this.docdateField = value;
                this.RaisePropertyChanged("docdate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string docdesc {
            get {
                return this.docdescField;
            }
            set {
                this.docdescField = value;
                this.RaisePropertyChanged("docdesc");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string docflags {
            get {
                return this.docflagsField;
            }
            set {
                this.docflagsField = value;
                this.RaisePropertyChanged("docflags");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string docid {
            get {
                return this.docidField;
            }
            set {
                this.docidField = value;
                this.RaisePropertyChanged("docid");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string docsstype {
            get {
                return this.docsstypeField;
            }
            set {
                this.docsstypeField = value;
                this.RaisePropertyChanged("docsstype");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public long fileSize {
            get {
                return this.fileSizeField;
            }
            set {
                this.fileSizeField = value;
                this.RaisePropertyChanged("fileSize");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fileSizeSpecified {
            get {
                return this.fileSizeFieldSpecified;
            }
            set {
                this.fileSizeFieldSpecified = value;
                this.RaisePropertyChanged("fileSizeSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=8)]
        public string foldesc {
            get {
                return this.foldescField;
            }
            set {
                this.foldescField = value;
                this.RaisePropertyChanged("foldesc");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=9)]
        public string folflags {
            get {
                return this.folflagsField;
            }
            set {
                this.folflagsField = value;
                this.RaisePropertyChanged("folflags");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=10)]
        public string folid {
            get {
                return this.folidField;
            }
            set {
                this.folidField = value;
                this.RaisePropertyChanged("folid");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=11)]
        public string tagNames {
            get {
                return this.tagNamesField;
            }
            set {
                this.tagNamesField = value;
                this.RaisePropertyChanged("tagNames");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dmotorworks.com/pip-dsda")]
    public partial class dealerId : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string dealerId1Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("dealerId", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string dealerId1 {
            get {
                return this.dealerId1Field;
            }
            set {
                this.dealerId1Field = value;
                this.RaisePropertyChanged("dealerId1");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.dmotorworks.com/pip-dsda")]
    public partial class authenticationToken : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string passwordField;
        
        private string usernameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
                this.RaisePropertyChanged("username");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.dmotorworks.com/pip-dsda", ConfigurationName="DsdaServiceReference.DsdaUpload")]
    public interface DsdaUpload {
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.dmotorworks.com/pip-dsda/DsdaUpload/DsdaUploadRequest", ReplyAction="http://www.dmotorworks.com/pip-dsda/DsdaUpload/DsdaUploadResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Dsda.UploaderRO.DsdaServiceReference.PIPException), Action="http://www.dmotorworks.com/pip-dsda/DsdaUpload/DsdaUpload/Fault/PIPException", Name="PIPException")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        Dsda.UploaderRO.DsdaServiceReference.DsdaUploadResponse DsdaUpload(Dsda.UploaderRO.DsdaServiceReference.DsdaUploadRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DsdaUpload", WrapperNamespace="http://www.dmotorworks.com/pip-dsda", IsWrapped=true)]
    public partial class DsdaUploadRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.dmotorworks.com/pip-dsda", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Dsda.UploaderRO.DsdaServiceReference.authenticationToken authToken;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.dmotorworks.com/pip-dsda", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Dsda.UploaderRO.DsdaServiceReference.dealerId dealerId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.dmotorworks.com/pip-dsda", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Dsda.UploaderRO.DsdaServiceReference.dsdaFileMetaData dsdaFile;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.dmotorworks.com/pip-dsda", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] arg3;
        
        public DsdaUploadRequest() {
        }
        
        public DsdaUploadRequest(Dsda.UploaderRO.DsdaServiceReference.authenticationToken authToken, Dsda.UploaderRO.DsdaServiceReference.dealerId dealerId, Dsda.UploaderRO.DsdaServiceReference.dsdaFileMetaData dsdaFile, byte[] arg3) {
            this.authToken = authToken;
            this.dealerId = dealerId;
            this.dsdaFile = dsdaFile;
            this.arg3 = arg3;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DsdaUploadResponse", WrapperNamespace="http://www.dmotorworks.com/pip-dsda", IsWrapped=true)]
    public partial class DsdaUploadResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.dmotorworks.com/pip-dsda", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Dsda.UploaderRO.DsdaServiceReference.dsdaUploadReply @return;
        
        public DsdaUploadResponse() {
        }
        
        public DsdaUploadResponse(Dsda.UploaderRO.DsdaServiceReference.dsdaUploadReply @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DsdaUploadChannel : Dsda.UploaderRO.DsdaServiceReference.DsdaUpload, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DsdaUploadClient : System.ServiceModel.ClientBase<Dsda.UploaderRO.DsdaServiceReference.DsdaUpload>, Dsda.UploaderRO.DsdaServiceReference.DsdaUpload {
        
        public DsdaUploadClient() {
        }
        
        public DsdaUploadClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DsdaUploadClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DsdaUploadClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DsdaUploadClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Dsda.UploaderRO.DsdaServiceReference.DsdaUploadResponse Dsda.UploaderRO.DsdaServiceReference.DsdaUpload.DsdaUpload(Dsda.UploaderRO.DsdaServiceReference.DsdaUploadRequest request) {
            return base.Channel.DsdaUpload(request);
        }
        
        public Dsda.UploaderRO.DsdaServiceReference.dsdaUploadReply DsdaUpload(Dsda.UploaderRO.DsdaServiceReference.authenticationToken authToken, Dsda.UploaderRO.DsdaServiceReference.dealerId dealerId, Dsda.UploaderRO.DsdaServiceReference.dsdaFileMetaData dsdaFile, byte[] arg3) {
            Dsda.UploaderRO.DsdaServiceReference.DsdaUploadRequest inValue = new Dsda.UploaderRO.DsdaServiceReference.DsdaUploadRequest();
            inValue.authToken = authToken;
            inValue.dealerId = dealerId;
            inValue.dsdaFile = dsdaFile;
            inValue.arg3 = arg3;
            Dsda.UploaderRO.DsdaServiceReference.DsdaUploadResponse retVal = ((Dsda.UploaderRO.DsdaServiceReference.DsdaUpload)(this)).DsdaUpload(inValue);
            return retVal.@return;
        }
    }
}
