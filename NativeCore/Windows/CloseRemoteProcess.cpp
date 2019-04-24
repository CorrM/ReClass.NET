#include <windows.h>

#include "Program.h"
#include "NativeCore.hpp"

void RC_CallConv CloseRemoteProcess(RC_Pointer handle, DWORD targetProcessID)
{
	if (handle != nullptr)
		CloseHandle(handle);

	/*if (ByPass != nullptr && ByPass->pID == targetProcessID)
	{
		delete ByPass;
		ByPass = nullptr;
	}*/
}
