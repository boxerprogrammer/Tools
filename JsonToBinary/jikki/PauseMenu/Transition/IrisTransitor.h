#pragma once
#include"Transitor.h"
class IrisTransitor:
    public Transitor
{
private:
	int width_ = 100;
	int handleForMaskScreen_;
	int maskH_;
	float diagonalLength_;
	bool irisOut_=false;
	int gHandle_=-1;
public:
	IrisTransitor(bool irisOut=false,int interval = 60,int gHandle=-1);
	~IrisTransitor();
	virtual void Update() override;
	virtual void Draw() override;
};

