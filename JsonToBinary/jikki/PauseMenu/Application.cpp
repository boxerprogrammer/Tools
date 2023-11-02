#include "Application.h"
#include<DxLib.h>
#include<cassert>
#include"Scene/SceneManager.h"
#include"Scene/TitleScene.h"
#include"Input.h"
#include<memory>

bool Application::Init()
{
	std::random_device rd;
	//アプリケーション中に１回だけ
	//メンバ変数のメルセンヌ素数オブジェクトの
	//シード値としてrandom_deviceを生成して
	//ぶっこんでいる。これ一回だけ。
	mt_.seed(rd());

	ChangeWindowMode(true);
	if (DxLib_Init() == -1) {
		return false;
	}
	SetDrawScreen(DX_SCREEN_BACK);
	return true;
}

void Application::Run()
{
	SceneManager sceneManager;
	sceneManager.ChangeScene(std::make_shared<TitleScene>(sceneManager));

	Input input;

	while (ProcessMessage() != -1) {
		ClearDrawScreen();

		input.Update();

		sceneManager.Update(input);
		sceneManager.Draw();

		ScreenFlip();
	}
}

void Application::Terminate()
{
	DxLib_End();
}

std::mt19937 Application::CreateRandomObject()
{
	return std::mt19937(mt_());
}
