#include "GameoverScene.h"
#include<DxLib.h>
#include"../Input.h"
#include"TitleScene.h"
#include"SceneManager.h"

GameoverScene::GameoverScene(SceneManager& manager):Scene(manager)
{
}
void GameoverScene::Update(Input& input)
{
	if (input.IsTriggered("next")) {
		sceneManager_.ChangeScene(std::make_shared<TitleScene>(sceneManager_));
	}
}

void GameoverScene::Draw()
{
	DrawString(50, 50, L"Gameover Scene", 0xffffff);
}
