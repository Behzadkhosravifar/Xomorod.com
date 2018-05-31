﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 4.0.30319.42000
//     Generated at 05/31/2018 17:16:55
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//     This file is a T4 Text Template for generate automatically your 
//     connection strings in from "App.config" or "Web.config" files.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.IO;
using AdoManager;

public static partial class Connections
{
	
		static Connections()
		{
			// Get runtime application name
			var appName = Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location);

			// Set Database Connection from App.config or Web.config
			var data = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Web.config"));
			
			// load connections from configure file to AdoManager connections location
			AdoManager.ConnectionManager.LoadFromXml(data);
		}

		 
		public static AdoManager.ConnectionManager Xomorod { get { return ConnectionManager.Find("Xomorod"); } }
		
}