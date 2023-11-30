#include "GameScene.h"
#include<DxLib.h>
#include"../Input.h"
#include"GameoverScene.h"
#include"SceneManager.h"
#include"PauseScene.h"
#include<sstream>
#include<iomanip>
#include<cassert>
#include"../MimicFile.h"
#include"../Application.h"
#include<random>
#include"../Enemy/EnemyManager.h"

void GameScene::InitializeUpdate(Input& input)
{
	auto& app = Application::GetInstance();
	auto mt = app.CreateRandomObject();
	SetUseASyncLoadFlag(true);
	std::vector<std::wstring> filenames = {
		L"adventurer-air-attack-3-end-00.png",
		L"adventurer-air-attack-3-end-01.png",
		L"adventurer-air-attack-3-end-02.png",
		L"adventurer-air-attack1-00.png",
		L"adventurer-air-attack1-01.png",
		L"adventurer-air-attack1-02.png",
		L"adventurer-air-attack1-03.png",
		L"adventurer-air-attack2-00.png",
		L"adventurer-air-attack2-01.png",
		L"adventurer-air-attack2-02.png",
		L"adventurer-air-attack3-loop-00.png",
		L"adventurer-air-attack3-loop-01.png",
		L"adventurer-air-attack3-rdy-00.png",
		L"adventurer-attack1-00.png",
		L"adventurer-attack1-01.png",
		L"adventurer-attack1-02.png",
		L"adventurer-attack1-03.png",
		L"adventurer-attack1-04.png",
		L"adventurer-attack2-00.png",
		L"adventurer-attack2-01.png",
		L"adventurer-attack2-02.png",
		L"adventurer-attack2-03.png",
		L"adventurer-attack2-04.png",
		L"adventurer-attack2-05.png",
		L"adventurer-attack3-00.png",
		L"adventurer-attack3-01.png",
		L"adventurer-attack3-02.png",
		L"adventurer-attack3-03.png",
		L"adventurer-attack3-04.png",
		L"adventurer-attack3-05.png",
		L"adventurer-cast-00.png",
		L"adventurer-cast-01.png",
		L"adventurer-cast-02.png",
		L"adventurer-cast-03.png",
		L"adventurer-cast-loop-00.png",
		L"adventurer-cast-loop-01.png",
		L"adventurer-cast-loop-02.png",
		L"adventurer-cast-loop-03.png",
		L"adventurer-crnr-clmb-00.png",
		L"adventurer-crnr-clmb-01.png",
		L"adventurer-crnr-clmb-02.png",
		L"adventurer-crnr-clmb-03.png",
		L"adventurer-crnr-clmb-04.png",
		L"adventurer-crnr-grb-00.png",
		L"adventurer-crnr-grb-01.png",
		L"adventurer-crnr-grb-02.png",
		L"adventurer-crnr-grb-03.png",
		L"adventurer-crnr-jmp-00.png",
		L"adventurer-crnr-jmp-01.png",
		L"adventurer-crouch-00.png",
		L"adventurer-crouch-01.png",
		L"adventurer-crouch-02.png",
		L"adventurer-crouch-03.png",
		L"adventurer-die-00.png",
		L"adventurer-die-01.png",
		L"adventurer-die-02.png",
		L"adventurer-die-03.png",
		L"adventurer-die-04.png",
		L"adventurer-die-05.png",
		L"adventurer-die-06.png",
		L"adventurer-fall-00.png",
		L"adventurer-fall-01.png",
		L"adventurer-hurt-00.png",
		L"adventurer-hurt-01.png",
		L"adventurer-hurt-02.png",
		L"adventurer-idle-00.png",
		L"adventurer-idle-01.png",
		L"adventurer-idle-02.png",
		L"adventurer-idle-03.png",
		L"adventurer-idle-2-00.png",
		L"adventurer-idle-2-01.png",
		L"adventurer-idle-2-02.png",
		L"adventurer-idle-2-03.png",
		L"adventurer-items-00.png",
		L"adventurer-items-01.png",
		L"adventurer-items-02.png",
		L"adventurer-jump-00.png",
		L"adventurer-jump-01.png",
		L"adventurer-jump-02.png",
		L"adventurer-jump-03.png",
		L"adventurer-ladder-climb-00.png",
		L"adventurer-ladder-climb-01.png",
		L"adventurer-ladder-climb-02.png",
		L"adventurer-ladder-climb-03.png",
		L"adventurer-run-00.png",
		L"adventurer-run-01.png",
		L"adventurer-run-02.png",
		L"adventurer-run-03.png",
		L"adventurer-run-04.png",
		L"adventurer-run-05.png",
		L"adventurer-slide-00.png",
		L"adventurer-slide-01.png",
		L"adventurer-smrslt-00.png",
		L"adventurer-smrslt-01.png",
		L"adventurer-smrslt-02.png",
		L"adventurer-smrslt-03.png",
		L"adventurer-stand-00.png",
		L"adventurer-stand-01.png",
		L"adventurer-stand-02.png",
		L"adventurer-swrd-drw-00.png",
		L"adventurer-swrd-drw-01.png",
		L"adventurer-swrd-drw-02.png",
		L"adventurer-swrd-drw-03.png",
		L"adventurer-swrd-shte-00.png",
		L"adventurer-swrd-shte-01.png",
		L"adventurer-swrd-shte-02.png",
		L"adventurer-swrd-shte-03.png",
		L"adventurer-wall-slide-00.png",
		L"adventurer-wall-slide-01.png"
	};
	for (const auto& fname : filenames) {
		std::wstringstream wss;
		wss << L"./img/sprites/";
		wss << fname;
		auto imgH = LoadGraph(wss.str().c_str());
		assert(imgH >= 0);
		imgHs_.push_back(imgH);
	}
	filenames_ = {
		"adventurer-air-attack-3-end-00.png",
		"adventurer-air-attack-3-end-01.png",
		"adventurer-air-attack-3-end-02.png",
		"adventurer-air-attack1-00.png",
		"adventurer-air-attack1-01.png",
		"adventurer-air-attack1-02.png",
		"adventurer-air-attack1-03.png",
		"adventurer-air-attack2-00.png",
		"adventurer-air-attack2-01.png",
		"adventurer-air-attack2-02.png",
		"adventurer-air-attack3-loop-00.png",
		"adventurer-air-attack3-loop-01.png",
		"adventurer-air-attack3-rdy-00.png",
		"adventurer-attack1-00.png",
		"adventurer-attack1-01.png",
		"adventurer-attack1-02.png",
		"adventurer-attack1-03.png",
		"adventurer-attack1-04.png",
		"adventurer-attack2-00.png",
		"adventurer-attack2-01.png",
		"adventurer-attack2-02.png",
		"adventurer-attack2-03.png",
		"adventurer-attack2-04.png",
		"adventurer-attack2-05.png",
		"adventurer-attack3-00.png",
		"adventurer-attack3-01.png",
		"adventurer-attack3-02.png",
		"adventurer-attack3-03.png",
		"adventurer-attack3-04.png",
		"adventurer-attack3-05.png",
		"adventurer-cast-00.png",
		"adventurer-cast-01.png",
		"adventurer-cast-02.png",
		"adventurer-cast-03.png",
		"adventurer-cast-loop-00.png",
		"adventurer-cast-loop-01.png",
		"adventurer-cast-loop-02.png",
		"adventurer-cast-loop-03.png",
		"adventurer-crnr-clmb-00.png",
		"adventurer-crnr-clmb-01.png",
		"adventurer-crnr-clmb-02.png",
		"adventurer-crnr-clmb-03.png",
		"adventurer-crnr-clmb-04.png",
		"adventurer-crnr-grb-00.png",
		"adventurer-crnr-grb-01.png",
		"adventurer-crnr-grb-02.png",
		"adventurer-crnr-grb-03.png",
		"adventurer-crnr-jmp-00.png",
		"adventurer-crnr-jmp-01.png",
		"adventurer-crouch-00.png",
		"adventurer-crouch-01.png",
		"adventurer-crouch-02.png",
		"adventurer-crouch-03.png",
		"adventurer-die-00.png",
		"adventurer-die-01.png",
		"adventurer-die-02.png",
		"adventurer-die-03.png",
		"adventurer-die-04.png",
		"adventurer-die-05.png",
		"adventurer-die-06.png",
		"adventurer-fall-00.png",
		"adventurer-fall-01.png",
		"adventurer-hurt-00.png",
		"adventurer-hurt-01.png",
		"adventurer-hurt-02.png",
		"adventurer-idle-00.png",
		"adventurer-idle-01.png",
		"adventurer-idle-02.png",
		"adventurer-idle-03.png",
		"adventurer-idle-2-00.png",
		"adventurer-idle-2-01.png",
		"adventurer-idle-2-02.png",
		"adventurer-idle-2-03.png",
		"adventurer-items-00.png",
		"adventurer-items-01.png",
		"adventurer-items-02.png",
		"adventurer-jump-00.png",
		"adventurer-jump-01.png",
		"adventurer-jump-02.png",
		"adventurer-jump-03.png",
		"adventurer-ladder-climb-00.png",
		"adventurer-ladder-climb-01.png",
		"adventurer-ladder-climb-02.png",
		"adventurer-ladder-climb-03.png",
		"adventurer-run-00.png",
		"adventurer-run-01.png",
		"adventurer-run-02.png",
		"adventurer-run-03.png",
		"adventurer-run-04.png",
		"adventurer-run-05.png",
		"adventurer-slide-00.png",
		"adventurer-slide-01.png",
		"adventurer-smrslt-00.png",
		"adventurer-smrslt-01.png",
		"adventurer-smrslt-02.png",
		"adventurer-smrslt-03.png",
		"adventurer-stand-00.png",
		"adventurer-stand-01.png",
		"adventurer-stand-02.png",
		"adventurer-swrd-drw-00.png",
		"adventurer-swrd-drw-01.png",
		"adventurer-swrd-drw-02.png",
		"adventurer-swrd-drw-03.png",
		"adventurer-swrd-shte-00.png",
		"adventurer-swrd-shte-01.png",
		"adventurer-swrd-shte-02.png",
		"adventurer-swrd-shte-03.png",
		"adventurer-wall-slide-00.png",
		"adventurer-wall-slide-01.png"
	};
	std::uniform_int_distribution<size_t> uid(0, filenames.size()-1);
	offsets_[0] = uid(mt);
	offsets_[1] = uid(mt);

	imgH_=LoadGraph(L"img/hero.png");
	cutDataFile_->Open(L"img/hero_rects2.dat");
	updateFunc_ = &GameScene::LoadingUpdate;
	drawFunc_ = &GameScene::LoadingDraw;

}

void GameScene::InitializeDraw()
{
}

void GameScene::LoadingUpdate(Input& input)
{
	if (!(!cutDataFile_) && cutDataFile_->IsReadable()) {
		//まず、要素数をゲットする
		int count = 0;
		cutDataFile_->Read(&count, sizeof(count));
		for (int i = 0; i < count; ++i) {
			//元のファイル名(の長さ)を取得
			byte nameLen = 0;
			cutDataFile_->Read(&nameLen, sizeof(nameLen));

			std::string strName;//元のファイル名
			strName.resize(nameLen);//nameLenでリサイズ
			cutDataFile_->Read(strName.data(), strName.size());
			Rect rc = {};
			cutDataFile_->Read(&rc, sizeof(rc));
			rectTable_[strName] = rc;
		}
		cutDataFile_->Close();
		cutDataFile_.reset();
	}
	if(DxLib::GetASyncLoadNum()==0){
		updateFunc_ = &GameScene::LoadCompletedUpdate;
		drawFunc_ = &GameScene::NormalDraw;
	}

}

void GameScene::LoadingDraw()
{
	std::wstring nowloadStr = L"Now Loading...";
	DrawString(100, 100, nowloadStr.substr(0, nowLoadCnt).c_str(), 0xffffff);
	nowLoadCnt = (nowLoadCnt + 1) % nowloadStr.length();
}

void GameScene::LoadCompletedUpdate(Input& input)
{
	SetUseASyncLoadFlag(false);
	updateFunc_ = &GameScene::NormalUpdate;
}

void GameScene::NormalUpdate(Input& input)
{
	fps_ = GetFPS();
	enemyManager_->Update();
	if (input.IsTriggered("next")) {
		sceneManager_.ChangeScene(std::make_shared<GameoverScene>(sceneManager_));
	}
	else if (input.IsTriggered("pause")) {
		sceneManager_.PushScene(std::make_shared<PauseScene>(sceneManager_));
	}
	else if (input.IsTriggered("jump")) {
		DrawString(250, 250, L"Jump", 0xffffff);
	}
	else if (input.IsTriggered("attack")) {
		DrawString(250, 250, L"attack", 0xffffff);
	}
}

void GameScene::NormalDraw()
{
	DrawFormatString(50, 30, 0xffffff, L"FPS=%2.2f", fps_);
	DrawString(50, 50, L"Game Scene", 0xffffff);

	enemyManager_->Draw();

	int idx = ((frame_ / 5)+offsets_[0]) % filenames_.size();
	DrawRotaGraph(420, 240, 5.0f, 0.0f, imgHs_[idx], true);

	idx=(idx+offsets_[1])%filenames_.size();
	auto it = rectTable_.find(filenames_[idx]);
	if (it != rectTable_.end()) {
		auto& rc = it->second;
		DrawRectRotaGraph(220+rc.offX*5, 240+rc.offY*5,
			rc.pos.x, rc.pos.y,
			rc.size.w, rc.size.h,
			5.0f, 0.0f, imgH_, true);
	}
	else {
		assert(0);
	}
	
	++frame_;
}

GameScene::GameScene(SceneManager& manager) :Scene(manager),
updateFunc_ (&GameScene::InitializeUpdate),
drawFunc_ (&GameScene::InitializeDraw)
{
	cutDataFile_ = std::make_shared<MimicFile>();
	enemyManager_ = std::make_shared<EnemyManager>();
}

void GameScene::Update(Input& input)
{
	(this->*updateFunc_)(input);
}

void GameScene::Draw()
{
	(this->*drawFunc_)();

}
