#include<DxLib.h>
#include "TitleScene.h"
#include "GameScene.h"
#include"KeyconfigScene.h"
#include"../Input.h"
#include"SceneManager.h"
#include"../StringUtility.h"
#include"../File/FileManager.h"
#include"../File/File.h"
#include<algorithm>
#include"../Background/Background.h"




TitleScene::TitleScene(SceneManager& manager):Scene(manager)
{
	auto& fileMgr = manager.GetFileManager();
	bombImg_= fileMgr.LoadImageFile(L"./img/explosion.png");
	bigExpImg_ = fileMgr.LoadImageFile(L"./img/big_explosion.png");
	seBomb_ = fileMgr.LoadSoundFile(L"./se/bomb.wav");
	bg_ = std::make_shared<Background>(2.0f);
	bg_->AddPart(fileMgr.LoadImageFile(L"img/bg/sky.png"), { 0.0f,0.0f }, 0);
	bg_->AddPart(fileMgr.LoadImageFile(L"img/bg/far-clouds.png"), { 0.2f,0.0f }, 1);
	bg_->AddPart(fileMgr.LoadImageFile(L"img/bg/near-clouds.png"), { 0.4f,0.0f }, 2);
	bg_->AddPart(fileMgr.LoadImageFile(L"img/bg/mountains.png"), { 0.6f,0.0f }, 3);
	bg_->AddPart(fileMgr.LoadImageFile(L"img/bg/trees.png"), { 1.0f,0.0f }, 4);
	bg_->Ready();
	
}

void TitleScene::Update(Input& input)
{
	auto minput=GetMouseInput();
	if (minput & MOUSE_INPUT_RIGHT) {
		int x, y;
		GetMousePoint(&x, &y);
		upperPos_ = { 0,y };
		upperVec_ = {0,-4};
		lowerPos_ = { 0,y };
		lowerVec_ = { 0,4 };
		isExploding_ = true;
	}

	if (isExploding_) {
		if (upperVec_.y < 0 && upperPos_.y <= 0) {
			upperVec_ = { 4,0 };
		}
		if (upperVec_.x >0 && upperPos_.x >= 640) {
			upperVec_ = { 0,4 };
		}
		if (upperVec_.y > 0 && upperPos_.y >= 480) {
			upperVec_ = { -4,0 };
		}
		upperPos_ += upperVec_;
		if (lowerVec_.y > 0 && lowerPos_.y >= 480) {
			lowerVec_ = { 4,0 };
		}
		if (lowerVec_.x > 0 && lowerPos_.x >= 640) {
			lowerVec_ = { 0,-4 };
		}
		if (lowerVec_.y <  0 && lowerPos_.y <= 0) {
			lowerVec_ = { -4,0 };
		}
		lowerPos_ += lowerVec_;


		if ((frame_ % 10)==0) {
			boms_.emplace_back(upperPos_);
			boms_.emplace_back(lowerPos_);
		}
		if ((frame_ % 5) == 0) {
			PlaySoundMem(seBomb_->GetHandle(), DX_PLAYTYPE_BACK);
		}
		if (upperPos_ == lowerPos_) {
			isExploding_ = false;
			isBigExploding_ = true;
			bigExplodingFrame_ = 0;
			bigExpPos_ = upperPos_;
			boms_.clear();
			frame_ = 0;
		}
	}

	if (isExploding_) {
		for (auto& b : boms_) {
			b.frame++;
			if (b.frame > 60) {
				b.isDead = true;
			}
		}
		boms_.remove_if([](const Bomb& b) {
			return b.isDead;
			});
	}
	if (isBigExploding_) {
		++bigExplodingFrame_;
		if (bigExplodingFrame_ > 60) {
			isBigExploding_ = false;
			bigExplodingFrame_ = 0;
		}
	}
	frame_ = (frame_ + 1) % 360;
	bg_->Move({ -1.0f,0.0f });


	if (input.IsTriggered("next")) {
		sceneManager_.ChangeScene(std::make_shared<GameScene>(sceneManager_));
		return;
	}
	else if (input.IsTriggered("keyconfig")) {
		sceneManager_.PushScene(std::make_shared<KeyconfigScene>(sceneManager_));
	}

}

void TitleScene::Draw()
{

	bg_->Draw();

	std::string str = "Title Scene MultiByte";
	std::wstring wstr = StringUtility::StringToWstring(str);
	DrawString(50, 50, wstr.c_str(), 0xffffff);

	{
		//DrawCircleAA(upperPos_.x, upperPos_.y, 10, 32, 0xffaaaa);
		//DrawCircleAA(lowerPos_.x, lowerPos_.y, 10, 32, 0xffaaaa);


		for (auto& b : boms_) {
			DrawRectRotaGraph(b.pos.x, b.pos.y,
				((b.frame / 6) % 3) * 32,
				((b.frame / 6) / 3) * 32,
				32, 32,
				2.0f,
				0.0f,
				bombImg_->GetHandle(), true
			);
		}
	}
	if (isBigExploding_) {
		auto idx = bigExplodingFrame_ / 6;
		DrawRectRotaGraph(bigExpPos_.x, bigExpPos_.y,
			idx * 48,
			0,
			48, 48,
			3.0f,
			0.0f,
			bigExpImg_->GetHandle(), true
		);
	}


	//DrawString(50, 50, L"Title Scene", 0xffffff);
}
