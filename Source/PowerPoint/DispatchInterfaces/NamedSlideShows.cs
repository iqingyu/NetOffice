using System;
using NetRuntimeSystem = System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using NetOffice;
namespace NetOffice.PowerPointApi
{
	///<summary>
	/// DispatchInterface NamedSlideShows 
	/// SupportByVersion PowerPoint, 9,10,11,12,14,15
	///</summary>
	[SupportByVersionAttribute("PowerPoint", 9,10,11,12,14,15)]
	[EntityTypeAttribute(EntityType.IsDispatchInterface)]
	public class NamedSlideShows : Collection
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
                    _type = typeof(NamedSlideShows);
                    
                return _type;
            }
        }
        
        #endregion
        
		#region Construction

        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public NamedSlideShows(COMObject parentObject, object comProxy) : base(parentObject, comProxy)
		{
		}
		
		/// <param name="parentObject">object there has created the proxy</param>
        /// <param name="comProxy">inner wrapped COM proxy</param>
        /// <param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public NamedSlideShows(COMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
		{
		}
		
		/// <param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public NamedSlideShows(COMObject replacedObject) : base(replacedObject)
		{
		}
		
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public NamedSlideShows() : base()
		{
		}
		
		/// <param name="progId">registered ProgID</param>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public NamedSlideShows(string progId) : base(progId)
		{
		}
		
		#endregion
		
		#region Properties

		/// <summary>
		/// SupportByVersion PowerPoint 9, 10, 11, 12, 14, 15
		/// Get
		/// </summary>
		[SupportByVersionAttribute("PowerPoint", 9,10,11,12,14,15)]
		public NetOffice.PowerPointApi.Application Application
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "Application", paramsArray);
				NetOffice.PowerPointApi.Application newObject = Factory.CreateKnownObjectFromComProxy(this,returnItem,NetOffice.PowerPointApi.Application.LateBindingApiWrapperType) as NetOffice.PowerPointApi.Application;
				return newObject;
			}
		}

		/// <summary>
		/// SupportByVersion PowerPoint 9, 10, 11, 12, 14, 15
		/// Get
		/// Unknown COM Proxy
		/// </summary>
		[SupportByVersionAttribute("PowerPoint", 9,10,11,12,14,15)]
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

		#endregion

		#region Methods

		/// <summary>
		/// SupportByVersion PowerPoint 9, 10, 11, 12, 14, 15
		/// </summary>
		/// <param name="index">object index</param>
		[SupportByVersionAttribute("PowerPoint", 9,10,11,12,14,15)]
		[NetRuntimeSystem.Runtime.CompilerServices.IndexerName("Item")]
		public NetOffice.PowerPointApi.NamedSlideShow this[object index]
		{
			get
			{
				object[] paramsArray = Invoker.ValidateParamsArray(index);
				object returnItem = Invoker.MethodReturn(this, "Item", paramsArray);
				NetOffice.PowerPointApi.NamedSlideShow newObject = Factory.CreateKnownObjectFromComProxy(this, returnItem,NetOffice.PowerPointApi.NamedSlideShow.LateBindingApiWrapperType) as NetOffice.PowerPointApi.NamedSlideShow;
				return newObject;
			}
		}

		/// <summary>
		/// SupportByVersion PowerPoint 9, 10, 11, 12, 14, 15
		/// </summary>
		/// <param name="name">string Name</param>
		/// <param name="safeArrayOfSlideIDs">object safeArrayOfSlideIDs</param>
		[SupportByVersionAttribute("PowerPoint", 9,10,11,12,14,15)]
		public NetOffice.PowerPointApi.NamedSlideShow Add(string name, object safeArrayOfSlideIDs)
		{
			object[] paramsArray = Invoker.ValidateParamsArray(name, safeArrayOfSlideIDs);
			object returnItem = Invoker.MethodReturn(this, "Add", paramsArray);
			NetOffice.PowerPointApi.NamedSlideShow newObject = Factory.CreateKnownObjectFromComProxy(this, returnItem,NetOffice.PowerPointApi.NamedSlideShow.LateBindingApiWrapperType) as NetOffice.PowerPointApi.NamedSlideShow;
			return newObject;
		}

		#endregion
		#pragma warning restore
	}
}