#include<DxLib.h>
#include "TitleScene.h"
#include "GameScene.h"
#include"KeyconfigScene.h"
#include"../Input.h"
#include"SceneManager.h"
#include"../StringUtility.h"



TitleScene::TitleScene(SceneManager& manager):Scene(manager)
{
	auto str=StringUtility::WstringToString(L"StringTest In TitleScene\n");
	::OutputDebugStringA(str.c_str());
}

void TitleScene::Update(Input& input)
{
	if (input.IsTriggered("next")) {
		sceneManager_.ChangeScene(std::make_shared<GameScene>(sceneManager_));
	}
	else if (input.IsTriggered("keyconfig")) {
		sceneManager_.PushScene(std::make_shared<KeyconfigScene>(sceneManager_));
	}
}

void TitleScene::Draw()
{
	std::string str = "Title Scene MultiByte";
	std::wstring wstr = StringUtility::StringToWstring(str);
	DrawString(50, 50, wstr.c_str(), 0xffffff);
	//DrawString(50, 50, L"Title Scene", 0xffffff);
}
