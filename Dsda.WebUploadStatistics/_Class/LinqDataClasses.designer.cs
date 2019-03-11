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

namespace Dsda.WebUploadStatistics._Class
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DsdaReports01")]
	public partial class LinqDataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertVW_ASassetMetadata(VW_ASassetMetadata instance);
    partial void UpdateVW_ASassetMetadata(VW_ASassetMetadata instance);
    partial void DeleteVW_ASassetMetadata(VW_ASassetMetadata instance);
    partial void InsertVW_ASmissingMetadata(VW_ASmissingMetadata instance);
    partial void UpdateVW_ASmissingMetadata(VW_ASmissingMetadata instance);
    partial void DeleteVW_ASmissingMetadata(VW_ASmissingMetadata instance);
    partial void InsertVW_ASconversionError(VW_ASconversionError instance);
    partial void UpdateVW_ASconversionError(VW_ASconversionError instance);
    partial void DeleteVW_ASconversionError(VW_ASconversionError instance);
    partial void InsertVW_ASingestionError(VW_ASingestionError instance);
    partial void UpdateVW_ASingestionError(VW_ASingestionError instance);
    partial void DeleteVW_ASingestionError(VW_ASingestionError instance);
    partial void InsertASconversionError(ASconversionError instance);
    partial void UpdateASconversionError(ASconversionError instance);
    partial void DeleteASconversionError(ASconversionError instance);
    partial void InsertASingestionError(ASingestionError instance);
    partial void UpdateASingestionError(ASingestionError instance);
    partial void DeleteASingestionError(ASingestionError instance);
    #endregion
		
		public LinqDataClassesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["MainApplicationServices"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LinqDataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqDataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqDataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqDataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<VW_ASassetMetadata> VW_ASassetMetadatas
		{
			get
			{
				return this.GetTable<VW_ASassetMetadata>();
			}
		}
		
		public System.Data.Linq.Table<VW_ASmissingMetadata> VW_ASmissingMetadatas
		{
			get
			{
				return this.GetTable<VW_ASmissingMetadata>();
			}
		}
		
		public System.Data.Linq.Table<VW_ASconversionError> VW_ASconversionErrors
		{
			get
			{
				return this.GetTable<VW_ASconversionError>();
			}
		}
		
		public System.Data.Linq.Table<VW_ASingestionError> VW_ASingestionErrors
		{
			get
			{
				return this.GetTable<VW_ASingestionError>();
			}
		}
		
		public System.Data.Linq.Table<ASconversionError> ASconversionErrors
		{
			get
			{
				return this.GetTable<ASconversionError>();
			}
		}
		
		public System.Data.Linq.Table<ASingestionError> ASingestionErrors
		{
			get
			{
				return this.GetTable<ASingestionError>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_ASassetMetadata")]
	public partial class VW_ASassetMetadata : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _tenantName;
		
		private string _storeName;
		
		private string _dealNumber;
		
		private string _documentType;
		
		private string _stockNumber;
		
		private string _lastName;
		
		private string _firstName;
		
		private string _year;
		
		private string _make;
		
		private string _model;
		
		private System.Nullable<System.DateTime> _slsDate;
		
		private string _vin;
		
		private System.DateTime _creationDate;
		
		private System.Nullable<System.DateTime> _processDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OntenantNameChanging(string value);
    partial void OntenantNameChanged();
    partial void OnstoreNameChanging(string value);
    partial void OnstoreNameChanged();
    partial void OndealNumberChanging(string value);
    partial void OndealNumberChanged();
    partial void OndocumentTypeChanging(string value);
    partial void OndocumentTypeChanged();
    partial void OnstockNumberChanging(string value);
    partial void OnstockNumberChanged();
    partial void OnlastNameChanging(string value);
    partial void OnlastNameChanged();
    partial void OnfirstNameChanging(string value);
    partial void OnfirstNameChanged();
    partial void OnyearChanging(string value);
    partial void OnyearChanged();
    partial void OnmakeChanging(string value);
    partial void OnmakeChanged();
    partial void OnmodelChanging(string value);
    partial void OnmodelChanged();
    partial void OnslsDateChanging(System.Nullable<System.DateTime> value);
    partial void OnslsDateChanged();
    partial void OnvinChanging(string value);
    partial void OnvinChanged();
    partial void OncreationDateChanging(System.DateTime value);
    partial void OncreationDateChanged();
    partial void OnprocessDateChanging(System.Nullable<System.DateTime> value);
    partial void OnprocessDateChanged();
    #endregion
		
		public VW_ASassetMetadata()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tenantName", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string tenantName
		{
			get
			{
				return this._tenantName;
			}
			set
			{
				if ((this._tenantName != value))
				{
					this.OntenantNameChanging(value);
					this.SendPropertyChanging();
					this._tenantName = value;
					this.SendPropertyChanged("tenantName");
					this.OntenantNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_storeName", DbType="NVarChar(100) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string storeName
		{
			get
			{
				return this._storeName;
			}
			set
			{
				if ((this._storeName != value))
				{
					this.OnstoreNameChanging(value);
					this.SendPropertyChanging();
					this._storeName = value;
					this.SendPropertyChanged("storeName");
					this.OnstoreNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dealNumber", DbType="NChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string dealNumber
		{
			get
			{
				return this._dealNumber;
			}
			set
			{
				if ((this._dealNumber != value))
				{
					this.OndealNumberChanging(value);
					this.SendPropertyChanging();
					this._dealNumber = value;
					this.SendPropertyChanged("dealNumber");
					this.OndealNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_documentType", DbType="NChar(30) NOT NULL", CanBeNull=false)]
		public string documentType
		{
			get
			{
				return this._documentType;
			}
			set
			{
				if ((this._documentType != value))
				{
					this.OndocumentTypeChanging(value);
					this.SendPropertyChanging();
					this._documentType = value;
					this.SendPropertyChanged("documentType");
					this.OndocumentTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stockNumber", DbType="NChar(20)")]
		public string stockNumber
		{
			get
			{
				return this._stockNumber;
			}
			set
			{
				if ((this._stockNumber != value))
				{
					this.OnstockNumberChanging(value);
					this.SendPropertyChanging();
					this._stockNumber = value;
					this.SendPropertyChanged("stockNumber");
					this.OnstockNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastName", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string lastName
		{
			get
			{
				return this._lastName;
			}
			set
			{
				if ((this._lastName != value))
				{
					this.OnlastNameChanging(value);
					this.SendPropertyChanging();
					this._lastName = value;
					this.SendPropertyChanged("lastName");
					this.OnlastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_firstName", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string firstName
		{
			get
			{
				return this._firstName;
			}
			set
			{
				if ((this._firstName != value))
				{
					this.OnfirstNameChanging(value);
					this.SendPropertyChanging();
					this._firstName = value;
					this.SendPropertyChanged("firstName");
					this.OnfirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_year", DbType="NChar(4)")]
		public string year
		{
			get
			{
				return this._year;
			}
			set
			{
				if ((this._year != value))
				{
					this.OnyearChanging(value);
					this.SendPropertyChanging();
					this._year = value;
					this.SendPropertyChanged("year");
					this.OnyearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_make", DbType="NChar(30)")]
		public string make
		{
			get
			{
				return this._make;
			}
			set
			{
				if ((this._make != value))
				{
					this.OnmakeChanging(value);
					this.SendPropertyChanging();
					this._make = value;
					this.SendPropertyChanged("make");
					this.OnmakeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_model", DbType="NChar(30)")]
		public string model
		{
			get
			{
				return this._model;
			}
			set
			{
				if ((this._model != value))
				{
					this.OnmodelChanging(value);
					this.SendPropertyChanging();
					this._model = value;
					this.SendPropertyChanged("model");
					this.OnmodelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_slsDate", DbType="Date")]
		public System.Nullable<System.DateTime> slsDate
		{
			get
			{
				return this._slsDate;
			}
			set
			{
				if ((this._slsDate != value))
				{
					this.OnslsDateChanging(value);
					this.SendPropertyChanging();
					this._slsDate = value;
					this.SendPropertyChanged("slsDate");
					this.OnslsDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vin", DbType="NChar(17)")]
		public string vin
		{
			get
			{
				return this._vin;
			}
			set
			{
				if ((this._vin != value))
				{
					this.OnvinChanging(value);
					this.SendPropertyChanging();
					this._vin = value;
					this.SendPropertyChanged("vin");
					this.OnvinChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_creationDate", DbType="SmallDateTime NOT NULL")]
		public System.DateTime creationDate
		{
			get
			{
				return this._creationDate;
			}
			set
			{
				if ((this._creationDate != value))
				{
					this.OncreationDateChanging(value);
					this.SendPropertyChanging();
					this._creationDate = value;
					this.SendPropertyChanged("creationDate");
					this.OncreationDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_processDate", DbType="SmallDateTime")]
		public System.Nullable<System.DateTime> processDate
		{
			get
			{
				return this._processDate;
			}
			set
			{
				if ((this._processDate != value))
				{
					this.OnprocessDateChanging(value);
					this.SendPropertyChanging();
					this._processDate = value;
					this.SendPropertyChanged("processDate");
					this.OnprocessDateChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_ASmissingMetadata")]
	public partial class VW_ASmissingMetadata : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _tenantName;
		
		private string _storeName;
		
		private string _documentType;
		
		private string _dealNumber;
		
		private string _resolved;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OntenantNameChanging(string value);
    partial void OntenantNameChanged();
    partial void OnstoreNameChanging(string value);
    partial void OnstoreNameChanged();
    partial void OndocumentTypeChanging(string value);
    partial void OndocumentTypeChanged();
    partial void OndealNumberChanging(string value);
    partial void OndealNumberChanged();
    partial void OnresolvedChanging(string value);
    partial void OnresolvedChanged();
    #endregion
		
		public VW_ASmissingMetadata()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tenantName", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string tenantName
		{
			get
			{
				return this._tenantName;
			}
			set
			{
				if ((this._tenantName != value))
				{
					this.OntenantNameChanging(value);
					this.SendPropertyChanging();
					this._tenantName = value;
					this.SendPropertyChanged("tenantName");
					this.OntenantNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_storeName", DbType="NVarChar(100) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string storeName
		{
			get
			{
				return this._storeName;
			}
			set
			{
				if ((this._storeName != value))
				{
					this.OnstoreNameChanging(value);
					this.SendPropertyChanging();
					this._storeName = value;
					this.SendPropertyChanged("storeName");
					this.OnstoreNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_documentType", DbType="NVarChar(30) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string documentType
		{
			get
			{
				return this._documentType;
			}
			set
			{
				if ((this._documentType != value))
				{
					this.OndocumentTypeChanging(value);
					this.SendPropertyChanging();
					this._documentType = value;
					this.SendPropertyChanged("documentType");
					this.OndocumentTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dealNumber", DbType="Char(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string dealNumber
		{
			get
			{
				return this._dealNumber;
			}
			set
			{
				if ((this._dealNumber != value))
				{
					this.OndealNumberChanging(value);
					this.SendPropertyChanging();
					this._dealNumber = value;
					this.SendPropertyChanged("dealNumber");
					this.OndealNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_resolved", DbType="Char(5)")]
		public string resolved
		{
			get
			{
				return this._resolved;
			}
			set
			{
				if ((this._resolved != value))
				{
					this.OnresolvedChanging(value);
					this.SendPropertyChanging();
					this._resolved = value;
					this.SendPropertyChanged("resolved");
					this.OnresolvedChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_ASconversionError")]
	public partial class VW_ASconversionError : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _fileName;
		
		private int _row;
		
		private string _errorMessage;
		
		private string _movedToErrorFolder;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnfileNameChanging(string value);
    partial void OnfileNameChanged();
    partial void OnrowChanging(int value);
    partial void OnrowChanged();
    partial void OnerrorMessageChanging(string value);
    partial void OnerrorMessageChanged();
    partial void OnmovedToErrorFolderChanging(string value);
    partial void OnmovedToErrorFolderChanged();
    #endregion
		
		public VW_ASconversionError()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fileName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string fileName
		{
			get
			{
				return this._fileName;
			}
			set
			{
				if ((this._fileName != value))
				{
					this.OnfileNameChanging(value);
					this.SendPropertyChanging();
					this._fileName = value;
					this.SendPropertyChanged("fileName");
					this.OnfileNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_row", DbType="Int NOT NULL")]
		public int row
		{
			get
			{
				return this._row;
			}
			set
			{
				if ((this._row != value))
				{
					this.OnrowChanging(value);
					this.SendPropertyChanging();
					this._row = value;
					this.SendPropertyChanged("row");
					this.OnrowChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_errorMessage", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string errorMessage
		{
			get
			{
				return this._errorMessage;
			}
			set
			{
				if ((this._errorMessage != value))
				{
					this.OnerrorMessageChanging(value);
					this.SendPropertyChanging();
					this._errorMessage = value;
					this.SendPropertyChanged("errorMessage");
					this.OnerrorMessageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_movedToErrorFolder", DbType="Char(5)")]
		public string movedToErrorFolder
		{
			get
			{
				return this._movedToErrorFolder;
			}
			set
			{
				if ((this._movedToErrorFolder != value))
				{
					this.OnmovedToErrorFolderChanging(value);
					this.SendPropertyChanging();
					this._movedToErrorFolder = value;
					this.SendPropertyChanged("movedToErrorFolder");
					this.OnmovedToErrorFolderChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_ASingestionError")]
	public partial class VW_ASingestionError : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Nullable<int> _maxId;
		
		private string _tenantName;
		
		private string _storeName;
		
		private string _dealNumber;
		
		private string _error_message;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmaxIdChanging(System.Nullable<int> value);
    partial void OnmaxIdChanged();
    partial void OntenantNameChanging(string value);
    partial void OntenantNameChanged();
    partial void OnstoreNameChanging(string value);
    partial void OnstoreNameChanged();
    partial void OndealNumberChanging(string value);
    partial void OndealNumberChanged();
    partial void Onerror_messageChanging(string value);
    partial void Onerror_messageChanged();
    #endregion
		
		public VW_ASingestionError()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maxId", DbType="Int")]
		public System.Nullable<int> maxId
		{
			get
			{
				return this._maxId;
			}
			set
			{
				if ((this._maxId != value))
				{
					this.OnmaxIdChanging(value);
					this.SendPropertyChanging();
					this._maxId = value;
					this.SendPropertyChanged("maxId");
					this.OnmaxIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tenantName", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string tenantName
		{
			get
			{
				return this._tenantName;
			}
			set
			{
				if ((this._tenantName != value))
				{
					this.OntenantNameChanging(value);
					this.SendPropertyChanging();
					this._tenantName = value;
					this.SendPropertyChanged("tenantName");
					this.OntenantNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_storeName", DbType="NVarChar(100) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string storeName
		{
			get
			{
				return this._storeName;
			}
			set
			{
				if ((this._storeName != value))
				{
					this.OnstoreNameChanging(value);
					this.SendPropertyChanging();
					this._storeName = value;
					this.SendPropertyChanged("storeName");
					this.OnstoreNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dealNumber", DbType="Char(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string dealNumber
		{
			get
			{
				return this._dealNumber;
			}
			set
			{
				if ((this._dealNumber != value))
				{
					this.OndealNumberChanging(value);
					this.SendPropertyChanging();
					this._dealNumber = value;
					this.SendPropertyChanged("dealNumber");
					this.OndealNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_error_message", DbType="NVarChar(4000)", IsPrimaryKey=true)]
		public string error_message
		{
			get
			{
				return this._error_message;
			}
			set
			{
				if ((this._error_message != value))
				{
					this.Onerror_messageChanging(value);
					this.SendPropertyChanging();
					this._error_message = value;
					this.SendPropertyChanged("error_message");
					this.Onerror_messageChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ASconversionError")]
	public partial class ASconversionError : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _fileName;
		
		private int _row;
		
		private string _errorMessage;
		
		private string _movedToErrorFolder;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnfileNameChanging(string value);
    partial void OnfileNameChanged();
    partial void OnrowChanging(int value);
    partial void OnrowChanged();
    partial void OnerrorMessageChanging(string value);
    partial void OnerrorMessageChanged();
    partial void OnmovedToErrorFolderChanging(string value);
    partial void OnmovedToErrorFolderChanged();
    #endregion
		
		public ASconversionError()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fileName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string fileName
		{
			get
			{
				return this._fileName;
			}
			set
			{
				if ((this._fileName != value))
				{
					this.OnfileNameChanging(value);
					this.SendPropertyChanging();
					this._fileName = value;
					this.SendPropertyChanged("fileName");
					this.OnfileNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_row", DbType="Int NOT NULL")]
		public int row
		{
			get
			{
				return this._row;
			}
			set
			{
				if ((this._row != value))
				{
					this.OnrowChanging(value);
					this.SendPropertyChanging();
					this._row = value;
					this.SendPropertyChanged("row");
					this.OnrowChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_errorMessage", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string errorMessage
		{
			get
			{
				return this._errorMessage;
			}
			set
			{
				if ((this._errorMessage != value))
				{
					this.OnerrorMessageChanging(value);
					this.SendPropertyChanging();
					this._errorMessage = value;
					this.SendPropertyChanged("errorMessage");
					this.OnerrorMessageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_movedToErrorFolder", DbType="Char(5)")]
		public string movedToErrorFolder
		{
			get
			{
				return this._movedToErrorFolder;
			}
			set
			{
				if ((this._movedToErrorFolder != value))
				{
					this.OnmovedToErrorFolderChanging(value);
					this.SendPropertyChanging();
					this._movedToErrorFolder = value;
					this.SendPropertyChanged("movedToErrorFolder");
					this.OnmovedToErrorFolderChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ASingestionError")]
	public partial class ASingestionError : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _tenantName;
		
		private string _storeName;
		
		private string _dealNumber;
		
		private string _error_message;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OntenantNameChanging(string value);
    partial void OntenantNameChanged();
    partial void OnstoreNameChanging(string value);
    partial void OnstoreNameChanged();
    partial void OndealNumberChanging(string value);
    partial void OndealNumberChanged();
    partial void Onerror_messageChanging(string value);
    partial void Onerror_messageChanged();
    #endregion
		
		public ASingestionError()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tenantName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string tenantName
		{
			get
			{
				return this._tenantName;
			}
			set
			{
				if ((this._tenantName != value))
				{
					this.OntenantNameChanging(value);
					this.SendPropertyChanging();
					this._tenantName = value;
					this.SendPropertyChanged("tenantName");
					this.OntenantNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_storeName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string storeName
		{
			get
			{
				return this._storeName;
			}
			set
			{
				if ((this._storeName != value))
				{
					this.OnstoreNameChanging(value);
					this.SendPropertyChanging();
					this._storeName = value;
					this.SendPropertyChanged("storeName");
					this.OnstoreNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dealNumber", DbType="Char(20) NOT NULL", CanBeNull=false)]
		public string dealNumber
		{
			get
			{
				return this._dealNumber;
			}
			set
			{
				if ((this._dealNumber != value))
				{
					this.OndealNumberChanging(value);
					this.SendPropertyChanging();
					this._dealNumber = value;
					this.SendPropertyChanged("dealNumber");
					this.OndealNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_error_message", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string error_message
		{
			get
			{
				return this._error_message;
			}
			set
			{
				if ((this._error_message != value))
				{
					this.Onerror_messageChanging(value);
					this.SendPropertyChanging();
					this._error_message = value;
					this.SendPropertyChanged("error_message");
					this.Onerror_messageChanged();
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
