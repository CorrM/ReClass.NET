#include <windows.h>

#include "Program.h"
#include "NativeCore.hpp"

BypaPH *ByPass = nullptr;

RC_Pointer RC_CallConv OpenRemoteProcess(RC_Pointer id, ProcessAccess desiredAccess, bool useKernal, bool isTargetProcess)
{
	DWORD pID = static_cast<DWORD>(reinterpret_cast<size_t>(id));

	DWORD access = STANDARD_RIGHTS_REQUIRED | PROCESS_TERMINATE | PROCESS_QUERY_INFORMATION | SYNCHRONIZE;
	switch (desiredAccess)
	{
		case ProcessAccess::Read:
			access |= PROCESS_VM_READ;
			break;
		case ProcessAccess::Write:
			access |= PROCESS_VM_OPERATION | PROCESS_VM_WRITE;
			break;
		case ProcessAccess::Full:
			access |= PROCESS_VM_READ | PROCESS_VM_OPERATION | PROCESS_VM_WRITE;
			break;
	}

	if (isTargetProcess && useKernal)
		ByPass = new BypaPH(pID);

	const auto handle = OpenProcess(access, FALSE, pID);
	if (handle == nullptr || handle == INVALID_HANDLE_VALUE)
		return nullptr;

	return handle;
}
