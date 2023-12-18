#include "PushTransitor.h"
#include<DxLib.h>
#include"../Application.h"

PushTransitor::PushTransitor(PushDirection dir, int interval):direction_(dir),Transitor(interval)
{
}

void PushTransitor::Update()
{
	if (frame_ < interval_) {
		++frame_;
		SetDrawScreen(newRT_);
	}
	else if (frame_ == interval_) {
		SetDrawScreen(DX_SCREEN_BACK);
	}
}

void PushTransitor::Draw()
{
	if (IsEnd()) {
		return;
	}
	const auto& wsize = Application::GetInstance().GetWindowSize();
	SetDrawScreen(DX_SCREEN_BACK);
	auto rate = (float)frame_ / (float)interval_;

	//最終的に新画面が0に来るようにminusoneを用意する
	auto minusone = rate-1.0f;
	int endX=0;
	int endY=0;
	switch (direction_) {
	case PushDirection::left:
		endX = -wsize.w;
		break;
	case PushDirection::right:
		endX = wsize.w;
		break;
	case PushDirection::up:
		endY = -wsize.h;
		break;
	case PushDirection::down:
		endY = wsize.h;
		break;

	}

	DrawGraph(endX*rate, endY*rate, oldRT_, true);
	DrawGraph(endX* minusone, endY* minusone, newRT_, true);
	
}