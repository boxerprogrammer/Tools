#include "StripTransitor.h"
#include"../Application.h"
#include<DxLib.h>

void StripTransitor::Start()
{
	const auto& size = Application::GetInstance().GetWindowSize();
	auto scr=GetDrawScreen();
	oldRT_ = MakeGraph(size.w, size.h);
	newRT_ = MakeScreen(size.w, size.h);
	//int result = BltDrawValidGraph(scr, 0, 0, size.w, size.h, 0, 0, oldRT_);//åªç›ÇÃâÊñ ÇÃèÛãµÇÉRÉsÅ[

	int result = GetDrawScreenGraph(0, 0, size.w, size.h, oldRT_,true);
	result = DrawGraph(0, 0, oldRT_, true);
	//DrawBox(100, 100, 200, 200, 0xffff00, true);
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
	if (IsEnd()) {
		return;
	}
	SetDrawScreen(DX_SCREEN_BACK);
	const auto& wsize=Application::GetInstance().GetWindowSize();
	int lp = (wsize.w / width_) + 1;
	for (int i = 0; i < lp; ++i) {
		if (i % 2 == 0) {
			DrawRectGraph(i * width_, 0, i * width_, 0, width_, wsize.h, newRT_, true);
		}
		else {
			DrawRectGraph(i * width_, 0, i * width_, 0, width_, wsize.h, oldRT_, true);
		}
	}
}

bool StripTransitor::IsEnd() const
{
	return frame_>=interval_;
}
