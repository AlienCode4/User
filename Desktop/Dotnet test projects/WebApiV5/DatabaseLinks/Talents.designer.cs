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

namespace WebApiV5.DatabaseLinks
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Database1")]
	public partial class TalentsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTalent(Talent instance);
    partial void UpdateTalent(Talent instance);
    partial void DeleteTalent(Talent instance);
    #endregion
		
		public TalentsDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TalentsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TalentsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TalentsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TalentsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Talent> Talents
		{
			get
			{
				return this.GetTable<Talent>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Talent")]
	public partial class Talent : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TalentID;
		
		private string _TalentName;
		
		private System.DateTime _TalentDOB;
		
		private int _TalentHeight;
		
		private string _TalentGender;
		
		private string _TalentSurname;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTalentIDChanging(int value);
    partial void OnTalentIDChanged();
    partial void OnTalentNameChanging(string value);
    partial void OnTalentNameChanged();
    partial void OnTalentDOBChanging(System.DateTime value);
    partial void OnTalentDOBChanged();
    partial void OnTalentHeightChanging(int value);
    partial void OnTalentHeightChanged();
    partial void OnTalentGenderChanging(string value);
    partial void OnTalentGenderChanged();
    partial void OnTalentSurnameChanging(string value);
    partial void OnTalentSurnameChanged();
    #endregion
		
		public Talent()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TalentID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int TalentID
		{
			get
			{
				return this._TalentID;
			}
			set
			{
				if ((this._TalentID != value))
				{
					this.OnTalentIDChanging(value);
					this.SendPropertyChanging();
					this._TalentID = value;
					this.SendPropertyChanged("TalentID");
					this.OnTalentIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TalentName", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string TalentName
		{
			get
			{
				return this._TalentName;
			}
			set
			{
				if ((this._TalentName != value))
				{
					this.OnTalentNameChanging(value);
					this.SendPropertyChanging();
					this._TalentName = value;
					this.SendPropertyChanged("TalentName");
					this.OnTalentNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TalentDOB", DbType="Date NOT NULL")]
		public System.DateTime TalentDOB
		{
			get
			{
				return this._TalentDOB;
			}
			set
			{
				if ((this._TalentDOB != value))
				{
					this.OnTalentDOBChanging(value);
					this.SendPropertyChanging();
					this._TalentDOB = value;
					this.SendPropertyChanged("TalentDOB");
					this.OnTalentDOBChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TalentHeight", DbType="Int NOT NULL")]
		public int TalentHeight
		{
			get
			{
				return this._TalentHeight;
			}
			set
			{
				if ((this._TalentHeight != value))
				{
					this.OnTalentHeightChanging(value);
					this.SendPropertyChanging();
					this._TalentHeight = value;
					this.SendPropertyChanged("TalentHeight");
					this.OnTalentHeightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TalentGender", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string TalentGender
		{
			get
			{
				return this._TalentGender;
			}
			set
			{
				if ((this._TalentGender != value))
				{
					this.OnTalentGenderChanging(value);
					this.SendPropertyChanging();
					this._TalentGender = value;
					this.SendPropertyChanged("TalentGender");
					this.OnTalentGenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TalentSurname", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string TalentSurname
		{
			get
			{
				return this._TalentSurname;
			}
			set
			{
				if ((this._TalentSurname != value))
				{
					this.OnTalentSurnameChanging(value);
					this.SendPropertyChanging();
					this._TalentSurname = value;
					this.SendPropertyChanged("TalentSurname");
					this.OnTalentSurnameChanged();
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