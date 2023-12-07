#include "StripTransitor.h"
#include"../Application.h"
#include<DxLib.h>

void StripTransitor::Start()
{
	const auto& size = Application::GetInstance().GetWindowSize();
	auto scr=GetDrawScreen();
	int oldRT = MakeScreen(size.w, size.h);
	int newRT = MakeScreen(size.w, size.h);
	BltDrawValidGraph(scr, 0, 0, size.w, size.h, 0, 0, oldRT);//Œ»İ‚Ì‰æ–Ê‚Ìó‹µ‚ğƒRƒs[
	frame_ = 0;
}

void StripTransitor::Update()
{
	
	if (frame_ < interval_) {
		++frame_;
		SetDrawScreen(newRT_);
	}
	else if (frame_ == interval_) {
		SetDrawScreen(DX_SCREEN_BACK);
	}
}

void StripTransitor::Draw()
{

}

bool StripTransitor::IsEnd() const
{
	return frame_>=interval_;
}
