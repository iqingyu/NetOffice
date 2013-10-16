using System;
using NetRuntimeSystem = System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using NetOffice;
namespace NetOffice.WordApi
{
	///<summary>
	/// DispatchInterface OMathBorderBox 
	/// SupportByVersion Word, 12,14,15
	///</summary>
	[SupportByVersionAttribute("Word", 12,14,15)]
	[EntityTypeAttribute(EntityType.IsDispatchInterface)]
	public class OMathBorderBox : COMObject
	{
		#pragma warning disable
		#region Type Information

        private static Type _type;

		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public static Type LateBindingApiWrapperType
        {
            get
            {
                if (null == _type)
                    _type = typeof(OMathBorderBox);
                    
                return _type;
            }
        }
        
        #endregion
        
		#region Construction

        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public OMathBorderBox(COMObject parentObject, object comProxy) : base(parentObject, comProxy)
		{
		}
		
		/// <param name="parentObject">object there has created the proxy</param>
        /// <param name="comProxy">inner wrapped COM proxy</param>
        /// <param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public OMathBorderBox(COMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
		{
		}
		
		/// <param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public OMathBorderBox(COMObject replacedObject) : base(replacedObject)
		{
		}
		
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public OMathBorderBox() : base()
		{
		}
		
		/// <param name="progId">registered ProgID</param>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public OMathBorderBox(string progId) : base(progId)
		{
		}
		
		#endregion
		
		#region Properties

		/// <summary>
		/// SupportByVersion Word 12, 14, 15
		/// Get
		/// </summary>
		[SupportByVersionAttribute("Word", 12,14,15)]
		public NetOffice.WordApi.Application Application
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "Application", paramsArray);
				NetOffice.WordApi.Application newObject = Factory.CreateKnownObjectFromComProxy(this,returnItem,NetOffice.WordApi.Application.LateBindingApiWrapperType) as NetOffice.WordApi.Application;
				return newObject;
			}
		}

		/// <summary>
		/// SupportByVersion Word 12, 14, 15
		/// Get
		/// </summary>
		[SupportByVersionAttribute("Word", 12,14,15)]
		public Int32 Creator
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "Creator", paramsArray);
				return NetRuntimeSystem.Convert.ToInt32(returnItem);
			}
		}

		/// <summary>
		/// SupportByVersion Word 12, 14, 15
		/// Get
		/// Unknown COM Proxy
		/// </summary>
		[SupportByVersionAttribute("Word", 12,14,15)]
		public object Parent
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "Parent", paramsArray);
				COMObject newObject = Factory.CreateObjectFromComProxy(this,returnItem);
				return newObject;
			}
		}

		/// <summary>
		/// SupportByVersion Word 12, 14, 15
		/// Get
		/// </summary>
		[SupportByVersionAttribute("Word", 12,14,15)]
		public NetOffice.WordApi.OMath E
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "E", paramsArray);
				NetOffice.WordApi.OMath newObject = Factory.CreateKnownObjectFromComProxy(this,returnItem,NetOffice.WordApi.OMath.LateBindingApiWrapperType) as NetOffice.WordApi.OMath;
				return newObject;
			}
		}

		/// <summary>
		/// SupportByVersion Word 12, 14, 15
		/// Get/Set
		/// </summary>
		[SupportByVersionAttribute("Word", 12,14,15)]
		public bool HideTop
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "HideTop", paramsArray);
				return NetRuntimeSystem.Convert.ToBoolean(returnItem);
			}
			set
			{
				object[] paramsArray = Invoker.ValidateParamsArray(value);
				Invoker.PropertySet(this, "HideTop", paramsArray);
			}
		}

		/// <summary>
		/// SupportByVersion Word 12, 14, 15
		/// Get/Set
		/// </summary>
		[SupportByVersionAttribute("Word", 12,14,15)]
		public bool HideBot
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "HideBot", paramsArray);
				return NetRuntimeSystem.Convert.ToBoolean(returnItem);
			}
			set
			{
				object[] paramsArray = Invoker.ValidateParamsArray(value);
				Invoker.PropertySet(this, "HideBot", paramsArray);
			}
		}

		/// <summary>
		/// SupportByVersion Word 12, 14, 15
		/// Get/Set
		/// </summary>
		[SupportByVersionAttribute("Word", 12,14,15)]
		public bool HideLeft
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "HideLeft", paramsArray);
				return NetRuntimeSystem.Convert.ToBoolean(returnItem);
			}
			set
			{
				object[] paramsArray = Invoker.ValidateParamsArray(value);
				Invoker.PropertySet(this, "HideLeft", paramsArray);
			}
		}

		/// <summary>
		/// SupportByVersion Word 12, 14, 15
		/// Get/Set
		/// </summary>
		[SupportByVersionAttribute("Word", 12,14,15)]
		public bool HideRight
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "HideRight", paramsArray);
				return NetRuntimeSystem.Convert.ToBoolean(returnItem);
			}
			set
			{
				object[] paramsArray = Invoker.ValidateParamsArray(value);
				Invoker.PropertySet(this, "HideRight", paramsArray);
			}
		}

		/// <summary>
		/// SupportByVersion Word 12, 14, 15
		/// Get/Set
		/// </summary>
		[SupportByVersionAttribute("Word", 12,14,15)]
		public bool StrikeH
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "StrikeH", paramsArray);
				return NetRuntimeSystem.Convert.ToBoolean(returnItem);
			}
			set
			{
				object[] paramsArray = Invoker.ValidateParamsArray(value);
				Invoker.PropertySet(this, "StrikeH", paramsArray);
			}
		}

		/// <summary>
		/// SupportByVersion Word 12, 14, 15
		/// Get/Set
		/// </summary>
		[SupportByVersionAttribute("Word", 12,14,15)]
		public bool StrikeV
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "StrikeV", paramsArray);
				return NetRuntimeSystem.Convert.ToBoolean(returnItem);
			}
			set
			{
				object[] paramsArray = Invoker.ValidateParamsArray(value);
				Invoker.PropertySet(this, "StrikeV", paramsArray);
			}
		}

		/// <summary>
		/// SupportByVersion Word 12, 14, 15
		/// Get/Set
		/// </summary>
		[SupportByVersionAttribute("Word", 12,14,15)]
		public bool StrikeBLTR
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "StrikeBLTR", paramsArray);
				return NetRuntimeSystem.Convert.ToBoolean(returnItem);
			}
			set
			{
				object[] paramsArray = Invoker.ValidateParamsArray(value);
				Invoker.PropertySet(this, "StrikeBLTR", paramsArray);
			}
		}

		/// <summary>
		/// SupportByVersion Word 12, 14, 15
		/// Get/Set
		/// </summary>
		[SupportByVersionAttribute("Word", 12,14,15)]
		public bool StrikeTLBR
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "StrikeTLBR", paramsArray);
				return NetRuntimeSystem.Convert.ToBoolean(returnItem);
			}
			set
			{
				object[] paramsArray = Invoker.ValidateParamsArray(value);
				Invoker.PropertySet(this, "StrikeTLBR", paramsArray);
			}
		}

		#endregion

		#region Methods

		#endregion
		#pragma warning restore
	}
}