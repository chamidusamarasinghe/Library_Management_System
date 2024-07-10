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
	public partial class StudentDataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertStudentTb(StudentTb instance);
    partial void UpdateStudentTb(StudentTb instance);
    partial void DeleteStudentTb(StudentTb instance);
    #endregion
		
		public StudentDataClasses1DataContext() : 
				base(global::Library_Manage_System.Properties.Settings.Default.StudentDBConnectionString2, mappingSource)
		{
			OnCreated();
		}
		
		public StudentDataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StudentDataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StudentDataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StudentDataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<StudentTb> StudentTbs
		{
			get
			{
				return this.GetTable<StudentTb>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.StudentTb")]
	public partial class StudentTb : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Student_Id;
		
		private string _Student_Name;
		
		private int _Age;
		
		private string _Faculty;
		
		private string _Phone_no;
		
		private string _Email;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnStudent_IdChanging(string value);
    partial void OnStudent_IdChanged();
    partial void OnStudent_NameChanging(string value);
    partial void OnStudent_NameChanged();
    partial void OnAgeChanging(int value);
    partial void OnAgeChanged();
    partial void OnFacultyChanging(string value);
    partial void OnFacultyChanged();
    partial void OnPhone_noChanging(string value);
    partial void OnPhone_noChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
		
		public StudentTb()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Student_Id", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Student_Id
		{
			get
			{
				return this._Student_Id;
			}
			set
			{
				if ((this._Student_Id != value))
				{
					this.OnStudent_IdChanging(value);
					this.SendPropertyChanging();
					this._Student_Id = value;
					this.SendPropertyChanged("Student_Id");
					this.OnStudent_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Student_Name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Student_Name
		{
			get
			{
				return this._Student_Name;
			}
			set
			{
				if ((this._Student_Name != value))
				{
					this.OnStudent_NameChanging(value);
					this.SendPropertyChanging();
					this._Student_Name = value;
					this.SendPropertyChanged("Student_Name");
					this.OnStudent_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int NOT NULL")]
		public int Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this.OnAgeChanging(value);
					this.SendPropertyChanging();
					this._Age = value;
					this.SendPropertyChanged("Age");
					this.OnAgeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Faculty", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Faculty
		{
			get
			{
				return this._Faculty;
			}
			set
			{
				if ((this._Faculty != value))
				{
					this.OnFacultyChanging(value);
					this.SendPropertyChanging();
					this._Faculty = value;
					this.SendPropertyChanged("Faculty");
					this.OnFacultyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone_no", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Phone_no
		{
			get
			{
				return this._Phone_no;
			}
			set
			{
				if ((this._Phone_no != value))
				{
					this.OnPhone_noChanging(value);
					this.SendPropertyChanging();
					this._Phone_no = value;
					this.SendPropertyChanged("Phone_no");
					this.OnPhone_noChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
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
