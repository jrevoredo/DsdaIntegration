﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dsda.DataAccessRO
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DsdaIntegrationRO")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblUploadSession(tblUploadSession instance);
    partial void UpdatetblUploadSession(tblUploadSession instance);
    partial void DeletetblUploadSession(tblUploadSession instance);
    partial void InserttblUploadSessionDetail(tblUploadSessionDetail instance);
    partial void UpdatetblUploadSessionDetail(tblUploadSessionDetail instance);
    partial void DeletetblUploadSessionDetail(tblUploadSessionDetail instance);
    partial void InserttblDocumentProcessing(tblDocumentProcessing instance);
    partial void UpdatetblDocumentProcessing(tblDocumentProcessing instance);
    partial void DeletetblDocumentProcessing(tblDocumentProcessing instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::Dsda.DataAccessRO.Properties.Settings.Default.DsdaIntegrationConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblUploadSession> tblUploadSessions
		{
			get
			{
				return this.GetTable<tblUploadSession>();
			}
		}
		
		public System.Data.Linq.Table<tblUploadSessionDetail> tblUploadSessionDetails
		{
			get
			{
				return this.GetTable<tblUploadSessionDetail>();
			}
		}
		
		public System.Data.Linq.Table<tblDocumentProcessing> tblDocumentProcessings
		{
			get
			{
				return this.GetTable<tblDocumentProcessing>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblUploadSessions")]
	public partial class tblUploadSession : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UploadSessionId;
		
		private System.DateTime _DateCreated;
		
		private int _TotalFilesCount;
		
		private int _UploadedFilesCount;
		
		private int _MovedFilesCount;
		
		private int _FailedFilesCount;
		
		private string _DealerId;
		
		private string _Notes;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUploadSessionIdChanging(int value);
    partial void OnUploadSessionIdChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    partial void OnTotalFilesCountChanging(int value);
    partial void OnTotalFilesCountChanged();
    partial void OnUploadedFilesCountChanging(int value);
    partial void OnUploadedFilesCountChanged();
    partial void OnMovedFilesCountChanging(int value);
    partial void OnMovedFilesCountChanged();
    partial void OnFailedFilesCountChanging(int value);
    partial void OnFailedFilesCountChanged();
    partial void OnDealerIdChanging(string value);
    partial void OnDealerIdChanged();
    partial void OnNotesChanging(string value);
    partial void OnNotesChanged();
    #endregion
		
		public tblUploadSession()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UploadSessionId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UploadSessionId
		{
			get
			{
				return this._UploadSessionId;
			}
			set
			{
				if ((this._UploadSessionId != value))
				{
					this.OnUploadSessionIdChanging(value);
					this.SendPropertyChanging();
					this._UploadSessionId = value;
					this.SendPropertyChanged("UploadSessionId");
					this.OnUploadSessionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalFilesCount", DbType="Int NOT NULL")]
		public int TotalFilesCount
		{
			get
			{
				return this._TotalFilesCount;
			}
			set
			{
				if ((this._TotalFilesCount != value))
				{
					this.OnTotalFilesCountChanging(value);
					this.SendPropertyChanging();
					this._TotalFilesCount = value;
					this.SendPropertyChanged("TotalFilesCount");
					this.OnTotalFilesCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UploadedFilesCount", DbType="Int NOT NULL")]
		public int UploadedFilesCount
		{
			get
			{
				return this._UploadedFilesCount;
			}
			set
			{
				if ((this._UploadedFilesCount != value))
				{
					this.OnUploadedFilesCountChanging(value);
					this.SendPropertyChanging();
					this._UploadedFilesCount = value;
					this.SendPropertyChanged("UploadedFilesCount");
					this.OnUploadedFilesCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MovedFilesCount", DbType="Int NOT NULL")]
		public int MovedFilesCount
		{
			get
			{
				return this._MovedFilesCount;
			}
			set
			{
				if ((this._MovedFilesCount != value))
				{
					this.OnMovedFilesCountChanging(value);
					this.SendPropertyChanging();
					this._MovedFilesCount = value;
					this.SendPropertyChanged("MovedFilesCount");
					this.OnMovedFilesCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FailedFilesCount", DbType="Int NOT NULL")]
		public int FailedFilesCount
		{
			get
			{
				return this._FailedFilesCount;
			}
			set
			{
				if ((this._FailedFilesCount != value))
				{
					this.OnFailedFilesCountChanging(value);
					this.SendPropertyChanging();
					this._FailedFilesCount = value;
					this.SendPropertyChanged("FailedFilesCount");
					this.OnFailedFilesCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DealerId", DbType="NVarChar(10)")]
		public string DealerId
		{
			get
			{
				return this._DealerId;
			}
			set
			{
				if ((this._DealerId != value))
				{
					this.OnDealerIdChanging(value);
					this.SendPropertyChanging();
					this._DealerId = value;
					this.SendPropertyChanged("DealerId");
					this.OnDealerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Notes", DbType="NVarChar(MAX)")]
		public string Notes
		{
			get
			{
				return this._Notes;
			}
			set
			{
				if ((this._Notes != value))
				{
					this.OnNotesChanging(value);
					this.SendPropertyChanging();
					this._Notes = value;
					this.SendPropertyChanged("Notes");
					this.OnNotesChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblUploadSessionDetails")]
	public partial class tblUploadSessionDetail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UploadSessionDetailId;
		
		private int _UploadSessionId;
		
		private string _Message;
		
		private int _MessageType;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUploadSessionDetailIdChanging(int value);
    partial void OnUploadSessionDetailIdChanged();
    partial void OnUploadSessionIdChanging(int value);
    partial void OnUploadSessionIdChanged();
    partial void OnMessageChanging(string value);
    partial void OnMessageChanged();
    partial void OnMessageTypeChanging(int value);
    partial void OnMessageTypeChanged();
    #endregion
		
		public tblUploadSessionDetail()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UploadSessionDetailId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UploadSessionDetailId
		{
			get
			{
				return this._UploadSessionDetailId;
			}
			set
			{
				if ((this._UploadSessionDetailId != value))
				{
					this.OnUploadSessionDetailIdChanging(value);
					this.SendPropertyChanging();
					this._UploadSessionDetailId = value;
					this.SendPropertyChanged("UploadSessionDetailId");
					this.OnUploadSessionDetailIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UploadSessionId", DbType="Int NOT NULL")]
		public int UploadSessionId
		{
			get
			{
				return this._UploadSessionId;
			}
			set
			{
				if ((this._UploadSessionId != value))
				{
					this.OnUploadSessionIdChanging(value);
					this.SendPropertyChanging();
					this._UploadSessionId = value;
					this.SendPropertyChanged("UploadSessionId");
					this.OnUploadSessionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="NVarChar(MAX)")]
		public string Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this.OnMessageChanging(value);
					this.SendPropertyChanging();
					this._Message = value;
					this.SendPropertyChanged("Message");
					this.OnMessageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MessageType", DbType="Int NOT NULL")]
		public int MessageType
		{
			get
			{
				return this._MessageType;
			}
			set
			{
				if ((this._MessageType != value))
				{
					this.OnMessageTypeChanging(value);
					this.SendPropertyChanging();
					this._MessageType = value;
					this.SendPropertyChanged("MessageType");
					this.OnMessageTypeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblDocumentProcessing")]
	public partial class tblDocumentProcessing : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DocumentProcessingId;
		
		private int _UploadSessionId;
		
		private System.DateTime _ProcessingDate;
		
		private string _SourceDir;
		
		private string _DealerId;
		
		private string _Name;
		
		private string _ContractDate;
		
		private string _CustNo;
		
		private string _Stock;
		
		private string _Vin;
		
		private string _DealId;
		
		private string _CabId;
		
		private string _DocDate;
		
		private string _DocType;
		
		private string _DocFolder;
		
		private System.Nullable<bool> _IsProcessed;
		
		private string _ProcessedErrors;
		
		private string _TagNames;
		
		private string _OpenDate;
		
		private string _CloseDate;
		
		private string _Name1;
		
		private string _VehID;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDocumentProcessingIdChanging(int value);
    partial void OnDocumentProcessingIdChanged();
    partial void OnUploadSessionIdChanging(int value);
    partial void OnUploadSessionIdChanged();
    partial void OnProcessingDateChanging(System.DateTime value);
    partial void OnProcessingDateChanged();
    partial void OnSourceDirChanging(string value);
    partial void OnSourceDirChanged();
    partial void OnDealerIdChanging(string value);
    partial void OnDealerIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnContractDateChanging(string value);
    partial void OnContractDateChanged();
    partial void OnCustNoChanging(string value);
    partial void OnCustNoChanged();
    partial void OnStockChanging(string value);
    partial void OnStockChanged();
    partial void OnVinChanging(string value);
    partial void OnVinChanged();
    partial void OnDealIdChanging(string value);
    partial void OnDealIdChanged();
    partial void OnCabIdChanging(string value);
    partial void OnCabIdChanged();
    partial void OnDocDateChanging(string value);
    partial void OnDocDateChanged();
    partial void OnDocTypeChanging(string value);
    partial void OnDocTypeChanged();
    partial void OnDocFolderChanging(string value);
    partial void OnDocFolderChanged();
    partial void OnIsProcessedChanging(System.Nullable<bool> value);
    partial void OnIsProcessedChanged();
    partial void OnProcessedErrorsChanging(string value);
    partial void OnProcessedErrorsChanged();
    partial void OnTagNamesChanging(string value);
    partial void OnTagNamesChanged();
    partial void OnOpenDateChanging(string value);
    partial void OnOpenDateChanged();
    partial void OnCloseDateChanging(string value);
    partial void OnCloseDateChanged();
    partial void OnName1Changing(string value);
    partial void OnName1Changed();
    partial void OnVehIDChanging(string value);
    partial void OnVehIDChanged();
    #endregion
		
		public tblDocumentProcessing()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocumentProcessingId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DocumentProcessingId
		{
			get
			{
				return this._DocumentProcessingId;
			}
			set
			{
				if ((this._DocumentProcessingId != value))
				{
					this.OnDocumentProcessingIdChanging(value);
					this.SendPropertyChanging();
					this._DocumentProcessingId = value;
					this.SendPropertyChanged("DocumentProcessingId");
					this.OnDocumentProcessingIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UploadSessionId", DbType="Int NOT NULL")]
		public int UploadSessionId
		{
			get
			{
				return this._UploadSessionId;
			}
			set
			{
				if ((this._UploadSessionId != value))
				{
					this.OnUploadSessionIdChanging(value);
					this.SendPropertyChanging();
					this._UploadSessionId = value;
					this.SendPropertyChanged("UploadSessionId");
					this.OnUploadSessionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessingDate", DbType="DateTime NOT NULL")]
		public System.DateTime ProcessingDate
		{
			get
			{
				return this._ProcessingDate;
			}
			set
			{
				if ((this._ProcessingDate != value))
				{
					this.OnProcessingDateChanging(value);
					this.SendPropertyChanging();
					this._ProcessingDate = value;
					this.SendPropertyChanged("ProcessingDate");
					this.OnProcessingDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SourceDir", DbType="NVarChar(1000) NOT NULL", CanBeNull=false)]
		public string SourceDir
		{
			get
			{
				return this._SourceDir;
			}
			set
			{
				if ((this._SourceDir != value))
				{
					this.OnSourceDirChanging(value);
					this.SendPropertyChanging();
					this._SourceDir = value;
					this.SendPropertyChanged("SourceDir");
					this.OnSourceDirChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DealerId", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string DealerId
		{
			get
			{
				return this._DealerId;
			}
			set
			{
				if ((this._DealerId != value))
				{
					this.OnDealerIdChanging(value);
					this.SendPropertyChanging();
					this._DealerId = value;
					this.SendPropertyChanged("DealerId");
					this.OnDealerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(1000)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContractDate", DbType="NVarChar(100)")]
		public string ContractDate
		{
			get
			{
				return this._ContractDate;
			}
			set
			{
				if ((this._ContractDate != value))
				{
					this.OnContractDateChanging(value);
					this.SendPropertyChanging();
					this._ContractDate = value;
					this.SendPropertyChanged("ContractDate");
					this.OnContractDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustNo", DbType="NVarChar(100)")]
		public string CustNo
		{
			get
			{
				return this._CustNo;
			}
			set
			{
				if ((this._CustNo != value))
				{
					this.OnCustNoChanging(value);
					this.SendPropertyChanging();
					this._CustNo = value;
					this.SendPropertyChanged("CustNo");
					this.OnCustNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Stock", DbType="NVarChar(100)")]
		public string Stock
		{
			get
			{
				return this._Stock;
			}
			set
			{
				if ((this._Stock != value))
				{
					this.OnStockChanging(value);
					this.SendPropertyChanging();
					this._Stock = value;
					this.SendPropertyChanged("Stock");
					this.OnStockChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Vin", DbType="NVarChar(100)")]
		public string Vin
		{
			get
			{
				return this._Vin;
			}
			set
			{
				if ((this._Vin != value))
				{
					this.OnVinChanging(value);
					this.SendPropertyChanging();
					this._Vin = value;
					this.SendPropertyChanged("Vin");
					this.OnVinChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DealId", DbType="NVarChar(100)")]
		public string DealId
		{
			get
			{
				return this._DealId;
			}
			set
			{
				if ((this._DealId != value))
				{
					this.OnDealIdChanging(value);
					this.SendPropertyChanging();
					this._DealId = value;
					this.SendPropertyChanged("DealId");
					this.OnDealIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CabId", DbType="NVarChar(100)")]
		public string CabId
		{
			get
			{
				return this._CabId;
			}
			set
			{
				if ((this._CabId != value))
				{
					this.OnCabIdChanging(value);
					this.SendPropertyChanging();
					this._CabId = value;
					this.SendPropertyChanged("CabId");
					this.OnCabIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocDate", DbType="NVarChar(100)")]
		public string DocDate
		{
			get
			{
				return this._DocDate;
			}
			set
			{
				if ((this._DocDate != value))
				{
					this.OnDocDateChanging(value);
					this.SendPropertyChanging();
					this._DocDate = value;
					this.SendPropertyChanged("DocDate");
					this.OnDocDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocType", DbType="NVarChar(100)")]
		public string DocType
		{
			get
			{
				return this._DocType;
			}
			set
			{
				if ((this._DocType != value))
				{
					this.OnDocTypeChanging(value);
					this.SendPropertyChanging();
					this._DocType = value;
					this.SendPropertyChanged("DocType");
					this.OnDocTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocFolder", DbType="NVarChar(1000)")]
		public string DocFolder
		{
			get
			{
				return this._DocFolder;
			}
			set
			{
				if ((this._DocFolder != value))
				{
					this.OnDocFolderChanging(value);
					this.SendPropertyChanging();
					this._DocFolder = value;
					this.SendPropertyChanged("DocFolder");
					this.OnDocFolderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsProcessed", DbType="Bit")]
		public System.Nullable<bool> IsProcessed
		{
			get
			{
				return this._IsProcessed;
			}
			set
			{
				if ((this._IsProcessed != value))
				{
					this.OnIsProcessedChanging(value);
					this.SendPropertyChanging();
					this._IsProcessed = value;
					this.SendPropertyChanged("IsProcessed");
					this.OnIsProcessedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessedErrors", DbType="NVarChar(MAX)")]
		public string ProcessedErrors
		{
			get
			{
				return this._ProcessedErrors;
			}
			set
			{
				if ((this._ProcessedErrors != value))
				{
					this.OnProcessedErrorsChanging(value);
					this.SendPropertyChanging();
					this._ProcessedErrors = value;
					this.SendPropertyChanged("ProcessedErrors");
					this.OnProcessedErrorsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TagNames", DbType="NVarChar(1000)")]
		public string TagNames
		{
			get
			{
				return this._TagNames;
			}
			set
			{
				if ((this._TagNames != value))
				{
					this.OnTagNamesChanging(value);
					this.SendPropertyChanging();
					this._TagNames = value;
					this.SendPropertyChanged("TagNames");
					this.OnTagNamesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OpenDate", DbType="NVarChar(100)")]
		public string OpenDate
		{
			get
			{
				return this._OpenDate;
			}
			set
			{
				if ((this._OpenDate != value))
				{
					this.OnOpenDateChanging(value);
					this.SendPropertyChanging();
					this._OpenDate = value;
					this.SendPropertyChanged("OpenDate");
					this.OnOpenDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CloseDate", DbType="NVarChar(100)")]
		public string CloseDate
		{
			get
			{
				return this._CloseDate;
			}
			set
			{
				if ((this._CloseDate != value))
				{
					this.OnCloseDateChanging(value);
					this.SendPropertyChanging();
					this._CloseDate = value;
					this.SendPropertyChanged("CloseDate");
					this.OnCloseDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name1", DbType="NVarChar(1000)")]
		public string Name1
		{
			get
			{
				return this._Name1;
			}
			set
			{
				if ((this._Name1 != value))
				{
					this.OnName1Changing(value);
					this.SendPropertyChanging();
					this._Name1 = value;
					this.SendPropertyChanged("Name1");
					this.OnName1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VehID", DbType="NVarChar(100)")]
		public string VehID
		{
			get
			{
				return this._VehID;
			}
			set
			{
				if ((this._VehID != value))
				{
					this.OnVehIDChanging(value);
					this.SendPropertyChanging();
					this._VehID = value;
					this.SendPropertyChanged("VehID");
					this.OnVehIDChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
