#include"Application.h"
#include<DxLib.h>

int WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int) {
	auto& app = Application::GetInstance();
	if (app.Init()) {
		app.Run();
		app.Terminate();
		return 0;
	}
	else {
		return -1;
	}
	
}