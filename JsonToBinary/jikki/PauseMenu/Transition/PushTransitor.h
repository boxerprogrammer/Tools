#pragma once
#include "Transitor.h"
class PushTransitor :
    public Transitor
{
public:
	enum class PushDirection {
		up,
		down,
		right,
		left
	};
private:
	PushDirection direction_;//プッシュ方向
public:
	PushTransitor(PushDirection dir=PushDirection::up, int interval = 60);
	virtual void Update() override;
	virtual void Draw() override;
};


