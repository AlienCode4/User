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
	public partial class SoccerEventsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSoccerEvent(SoccerEvent instance);
    partial void UpdateSoccerEvent(SoccerEvent instance);
    partial void DeleteSoccerEvent(SoccerEvent instance);
    #endregion
		
		public SoccerEventsDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SoccerEventsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SoccerEventsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SoccerEventsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SoccerEventsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<SoccerEvent> SoccerEvents
		{
			get
			{
				return this.GetTable<SoccerEvent>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SoccerEvent")]
	public partial class SoccerEvent : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _EventID;
		
		private string _TeamA;
		
		private string _TeamB;
		
		private string _isAvailable;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEventIDChanging(int value);
    partial void OnEventIDChanged();
    partial void OnTeamAChanging(string value);
    partial void OnTeamAChanged();
    partial void OnTeamBChanging(string value);
    partial void OnTeamBChanged();
    partial void OnisAvailableChanging(string value);
    partial void OnisAvailableChanged();
    #endregion
		
		public SoccerEvent()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int EventID
		{
			get
			{
				return this._EventID;
			}
			set
			{
				if ((this._EventID != value))
				{
					this.OnEventIDChanging(value);
					this.SendPropertyChanging();
					this._EventID = value;
					this.SendPropertyChanged("EventID");
					this.OnEventIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TeamA", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string TeamA
		{
			get
			{
				return this._TeamA;
			}
			set
			{
				if ((this._TeamA != value))
				{
					this.OnTeamAChanging(value);
					this.SendPropertyChanging();
					this._TeamA = value;
					this.SendPropertyChanged("TeamA");
					this.OnTeamAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TeamB", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string TeamB
		{
			get
			{
				return this._TeamB;
			}
			set
			{
				if ((this._TeamB != value))
				{
					this.OnTeamBChanging(value);
					this.SendPropertyChanging();
					this._TeamB = value;
					this.SendPropertyChanged("TeamB");
					this.OnTeamBChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isAvailable", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string isAvailable
		{
			get
			{
				return this._isAvailable;
			}
			set
			{
				if ((this._isAvailable != value))
				{
					this.OnisAvailableChanging(value);
					this.SendPropertyChanging();
					this._isAvailable = value;
					this.SendPropertyChanged("isAvailable");
					this.OnisAvailableChanged();
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