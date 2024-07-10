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

namespace Library_Manage_System
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="StudentDB")]
	public partial class BookDataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBookTb(BookTb instance);
    partial void UpdateBookTb(BookTb instance);
    partial void DeleteBookTb(BookTb instance);
    #endregion
		
		public BookDataClasses1DataContext() : 
				base(global::Library_Manage_System.Properties.Settings.Default.StudentDBConnectionString2, mappingSource)
		{
			OnCreated();
		}
		
		public BookDataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BookDataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BookDataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BookDataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BookTb> BookTbs
		{
			get
			{
				return this.GetTable<BookTb>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BookTb")]
	public partial class BookTb : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Book_Id;
		
		private string _Book_Name;
		
		private int _Count;
		
		private string _Author;
		
		private int _Year;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBook_IdChanging(string value);
    partial void OnBook_IdChanged();
    partial void OnBook_NameChanging(string value);
    partial void OnBook_NameChanged();
    partial void OnCountChanging(int value);
    partial void OnCountChanged();
    partial void OnAuthorChanging(string value);
    partial void OnAuthorChanged();
    partial void OnYearChanging(int value);
    partial void OnYearChanged();
    #endregion
		
		public BookTb()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Book_Id", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Book_Id
		{
			get
			{
				return this._Book_Id;
			}
			set
			{
				if ((this._Book_Id != value))
				{
					this.OnBook_IdChanging(value);
					this.SendPropertyChanging();
					this._Book_Id = value;
					this.SendPropertyChanged("Book_Id");
					this.OnBook_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Book_Name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Book_Name
		{
			get
			{
				return this._Book_Name;
			}
			set
			{
				if ((this._Book_Name != value))
				{
					this.OnBook_NameChanging(value);
					this.SendPropertyChanging();
					this._Book_Name = value;
					this.SendPropertyChanged("Book_Name");
					this.OnBook_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Count", DbType="Int NOT NULL")]
		public int Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				if ((this._Count != value))
				{
					this.OnCountChanging(value);
					this.SendPropertyChanging();
					this._Count = value;
					this.SendPropertyChanged("Count");
					this.OnCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Author", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Author
		{
			get
			{
				return this._Author;
			}
			set
			{
				if ((this._Author != value))
				{
					this.OnAuthorChanging(value);
					this.SendPropertyChanging();
					this._Author = value;
					this.SendPropertyChanged("Author");
					this.OnAuthorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Year", DbType="Int NOT NULL")]
		public int Year
		{
			get
			{
				return this._Year;
			}
			set
			{
				if ((this._Year != value))
				{
					this.OnYearChanging(value);
					this.SendPropertyChanging();
					this._Year = value;
					this.SendPropertyChanged("Year");
					this.OnYearChanged();
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
