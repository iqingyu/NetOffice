#include "StdAfx.h"
#include "ShimProxy.h"

DWORD WINAPI ReloadCLRInternal(LPVOID lpParameter);

/***************************************************************************
* Ctor Dtor
***************************************************************************/

ShimProxy::ShimProxy()
{
	_refCounter = 0;
	_updateAggregator = nullptr;
	_loader = nullptr;
	_ribbonExtensibility = nullptr;
	_paneConsumer = nullptr;
	_currentReloadTread = nullptr;
	_components++;

	// load the CLR here because host application may call QueryInterface before OnConnection
	if (ENABLE_SHIM)
	{
		_updateAggregator = new OuterUpdateAggregator(this);
		IOuterUpdateAggregator* updateAggregator = static_cast<IOuterUpdateAggregator*>(_updateAggregator);
		_loader = new (std::nothrow) ClrHost(updateAggregator);
		_loader->Load();
	}
}

ShimProxy::~ShimProxy()
{
	Cleanup();
	_components--;
}


/***************************************************************************
* ShimProxy Methods
***************************************************************************/

STDMETHODIMP ShimProxy::Cleanup()
{
	HRESULT hr = S_OK;

	if (_paneConsumer)
	{
		delete _paneConsumer;
		_paneConsumer = nullptr;
	}
	if (_ribbonExtensibility)
	{
		delete _ribbonExtensibility;
		_ribbonExtensibility = nullptr;
	}
	if (_loader)
	{
		delete _loader;
		_loader = nullptr;
	}
	if (_updateAggregator)
	{
		delete _updateAggregator;
		_updateAggregator = nullptr;
	}

	return hr;
}


/***************************************************************************
* IDTExtensibility2 Implementation
***************************************************************************/

STDMETHODIMP ShimProxy::OnConnection(IDispatch* application, ext_ConnectMode connectMode, IDispatch* addInInst, LPSAFEARRAY* custom)
{
	HRESULT hr = EXTENSIBILITY_DEFAULT_RESULT;

	try
	{
		if (ENABLE_SHIM && IsCLRLoaded())
		{
			IfFailGo(_loader->OuterAggregator()->Addin()->OnConnection(application, connectMode, addInInst, custom));
		}
		else if (_loader)
		{
			delete _loader;
			_loader = nullptr;
		}
		if (ENABLE_SHIM && !IsCLRLoaded())
		{
			hr = E_FAIL;
			goto Error;
		}

		return hr;
	}
	catch (...)
	{
		ShimDebugMessageBox(L"Error", L"OnConnection");
		hr = E_FAIL;
	}

Error:

	ShimDebugMessageBox(L"Fail", L"OnConnection");
	ValidateExtensibilityFail(hr);
	return hr;
}

STDMETHODIMP ShimProxy::OnDisconnection(ext_DisconnectMode removeMode, LPSAFEARRAY* custom)
{
	HRESULT hr = EXTENSIBILITY_DEFAULT_RESULT;

	try
	{
		if (ENABLE_SHIM && IsCLRLoaded())
		{
			IfFailGo(_loader->OuterAggregator()->Addin()->OnDisconnection(removeMode, custom));
		}
		// no cleanup call here because host application may still holds IUnkown Pointer to ribbon/taskpane/etc.

		return hr;
	}
	catch (...)
	{
		ShimDebugMessageBox(L"Error", L"OnDisconnection");
		hr = E_FAIL;
	}

Error:

	ShimDebugMessageBox(L"Fail", L"OnDisconnection");
	ValidateExtensibilityFail(hr);
	return hr;
}

STDMETHODIMP ShimProxy::OnAddInsUpdate(LPSAFEARRAY* custom)
{
	HRESULT hr = EXTENSIBILITY_DEFAULT_RESULT;

	try
	{
		if (ENABLE_SHIM && IsCLRLoaded())
		{
			IfFailGo(_loader->OuterAggregator()->Addin()->OnAddInsUpdate(custom));
		}
	}
	catch (...)
	{
		ShimDebugMessageBox(L"Error", L"OnAddInsUpdate");
		hr = E_FAIL;
	}

	return hr;

Error:

	ShimDebugMessageBox(L"Fail", L"OnAddInsUpdate");
	ValidateExtensibilityFail(hr);
	return hr;
}

STDMETHODIMP ShimProxy::OnStartupComplete(LPSAFEARRAY* custom)
{
	HRESULT hr = EXTENSIBILITY_DEFAULT_RESULT;

	try
	{
		if (ENABLE_SHIM && IsCLRLoaded())
		{
			IfFailGo(_loader->OuterAggregator()->Addin()->OnStartupComplete(custom));
		}
	}
	catch (...)
	{
		MessageBox(GetDesktopWindow(), L"Error", L"OnStartupComplete", 0);
		hr = E_FAIL;
	}

	return hr;

Error:

	ShimDebugMessageBox(L"Fail", L"OnStartupComplete");
	ValidateExtensibilityFail(hr);
	return hr;
}

STDMETHODIMP ShimProxy::OnBeginShutdown(LPSAFEARRAY* custom)
{
	HRESULT hr = EXTENSIBILITY_DEFAULT_RESULT;

	try
	{
		if (ENABLE_SHIM && IsCLRLoaded())
		{
			IfFailGo(_loader->OuterAggregator()->Addin()->OnBeginShutdown(custom));
		}

	}
	catch (...)
	{
		ShimDebugMessageBox(L"Error", L"OnBeginShutdown");
		hr = E_FAIL;
	}

	return hr;

Error:

	ShimDebugMessageBox(L"Fail", L"OnBeginShutdown");
	ValidateExtensibilityFail(hr);
	return hr;
}


/***************************************************************************
* IShimProxy Implementation
***************************************************************************/

BOOL STDMETHODCALLTYPE ShimProxy::IsCLRLoaded()
{
	BOOL result = FALSE;
	result = _loader && _loader->IsLoaded();
	return result;
}

STDMETHODIMP ShimProxy::ReloadCLR()
{
	if (_currentReloadTread)
		return E_UNEXPECTED;

	DWORD dwThreadId;
	_currentReloadTread = CreateThread(
		(SECURITY_ATTRIBUTES *)0,
		0,
		&ReloadCLRInternal,
		static_cast<IShimProxy*>(this),
		0,
		&dwThreadId
	);

	HRESULT hr = S_OK;
	//// WaitForSingleObject
	//HRESULT hr = E_FAIL;
	//if (!IsCLRLoaded() && _loader)
	//{
	//	// todo: store args in OnConnection and recall OnConnection/StartupComplete here

	//	if (_paneConsumer)
	//	{
	//		IUnknown* unknown = _loader->OuterAggregator()->Addin()->InnerUnkown();
	//		ICustomTaskPaneConsumer* consumer = nullptr;
	//		if (SUCCEEDED(unknown->QueryInterface(IID_IRibbonExtensibility, (LPVOID*)&consumer)))
	//			hr = _paneConsumer->SetInnerPointer(consumer);
	//	}

	//	if (_ribbonExtensibility)
	//	{
	//		IUnknown* unknown = _loader->OuterAggregator()->Addin()->InnerUnkown();
	//		IRibbonExtensibility* ribbon = nullptr;
	//		if (SUCCEEDED(unknown->QueryInterface(IID_IRibbonExtensibility, (LPVOID*)&ribbon)))
	//			hr = _ribbonExtensibility->SetInnerPointer(ribbon);
	//	}
	//}

	return hr;
Error:
	return hr;
}

STDMETHODIMP ShimProxy::UnloadCLR()
{
	HRESULT hr = E_FAIL;
	if (IsCLRLoaded())
	{
		IfFailGo(_loader->Unload());
	}

	return hr;
Error:
	return hr;
}

STDMETHODIMP ShimProxy::CloseReloadThread()
{
	HRESULT hr = S_OK;
	if (NULL != _currentReloadTread)
	{
		if (!CloseHandle(_currentReloadTread))
			hr = E_FAIL;
	}
	return hr;
}

DWORD WINAPI ReloadCLRInternal(LPVOID lpParameter)
{
	HRESULT hr = S_OK;
	IShimProxy* proxy = (IShimProxy*)lpParameter;

	if (proxy->IsCLRLoaded())
	{
		hr = proxy->UnloadCLR();
	}

	//if (SUCCEEDED(hr))
	//{
	//	hr = proxy->ReloadCLR();
	//}

	proxy->CloseReloadThread();

	return hr;
}


/***************************************************************************
* IDispatch Implementation
***************************************************************************/

STDMETHODIMP ShimProxy::GetTypeInfoCount(UINT* pctinfo)
{
	return E_FAIL;
}

STDMETHODIMP ShimProxy::GetTypeInfo(UINT iTInfo, LCID lcid, ITypeInfo** ppTInfo)
{
	return E_FAIL;
}

STDMETHODIMP ShimProxy::GetIDsOfNames(REFIID riid, LPOLESTR* rgszNames, UINT cNames, LCID lcid, DISPID* rgDispId)
{
	return E_FAIL;
}

STDMETHODIMP ShimProxy::Invoke(DISPID dispIdMember, REFIID riid, LCID lcid, WORD wFlags, DISPPARAMS* pDispParams, VARIANT* pVarResult, EXCEPINFO* pExcepInfo, UINT* puArgErr)
{
	return E_FAIL;
}


/***************************************************************************
* IUnknown Implementation
***************************************************************************/

STDMETHODIMP ShimProxy::QueryInterface(REFIID riid, void** ppv)
{
	if (NULL == ppv)
		return E_POINTER;
	*ppv = NULL;

	HRESULT hr = E_FAIL;
	bool isBlind = false;

	if (((IID_IDTExtensibility2 == riid) || (IID_IUnknown == riid) || (IID_IDispatch == riid)))
	{
		*ppv = static_cast<IDTExtensibility2*>(this);
		hr = S_OK;
	}
	else if (ENABLE_SHIM && (IID_IRibbonExtensibility == riid) && IsCLRLoaded())
	{
		// wrap and cache to encapsulate from host application
		// this is to prevent conflicts when reload the CLR on the fly
		if (!_ribbonExtensibility)
		{
			IUnknown* inner = _loader->OuterAggregator()->Addin()->InnerUnkown();
			IRibbonExtensibility* ribbon = nullptr;
			hr = inner->QueryInterface(riid, (LPVOID*)&ribbon);
			if (SUCCEEDED(hr))
				_ribbonExtensibility = new (std::nothrow) ManagedRibbonExtensibility(ribbon);
			if (!_ribbonExtensibility && NULL != ribbon)
			{
				ribbon->Release();
				hr = E_OUTOFMEMORY;
			}
		}
		if (_ribbonExtensibility)
		{
			*ppv = static_cast<IRibbonExtensibility*>(_ribbonExtensibility);
			hr = S_OK;
		}
	}
	else if (ENABLE_SHIM && (IID_ICustomTaskPaneConsumer == riid) && IsCLRLoaded())
	{
		// wrap and cache to encapsulate from host application
		// this is to prevent conflicts when reload the CLR on the fly
		if (!_paneConsumer)
		{
			IUnknown* inner = _loader->OuterAggregator()->Addin()->InnerUnkown();
			ICustomTaskPaneConsumer* consumer = nullptr;
			hr = inner->QueryInterface(riid, (LPVOID*)&consumer);
			if(SUCCEEDED(hr))
				_paneConsumer = new (std::nothrow) ManagedCustomTaskPaneConsumer(consumer);
			if (!_paneConsumer && NULL != consumer)
			{
				consumer->Release();
				hr = E_OUTOFMEMORY;
			}
		}
		if (_paneConsumer)
		{
			*ppv = static_cast<ICustomTaskPaneConsumer*>(_paneConsumer);
			hr = S_OK;
		}
	}
	else if (ENABLE_SHIM && (!ENABLE_OUTER_UPDATE_AGGREGATOR && ENABLE_BLIND_AGGREGATION && IsCLRLoaded()))
	{
		// blind aggregation means the inner pointer is not bridged by the shim
		// so we can not reload the CLR on the fly because host application is not aware of the
		// fact that the pointers are no longer valid
		IUnknown* inner = _loader->OuterAggregator()->Addin()->InnerUnkown();
		hr = inner->QueryInterface(riid, ppv);
		isBlind = true;
	}

	if (NULL != *ppv && !isBlind)
	{
		reinterpret_cast<IUnknown*>(*ppv)->AddRef();
	}
	else if (NULL == *ppv)
	{
		hr = E_NOINTERFACE;
	}

	return hr;
}

STDMETHODIMP_(ULONG) ShimProxy::AddRef(void)
{
	_refCounter++;
	return _refCounter;
}

STDMETHODIMP_(ULONG) ShimProxy::Release(void)
{
	_refCounter--;
	if(0 == _refCounter)
		delete this;
	return 0;
}