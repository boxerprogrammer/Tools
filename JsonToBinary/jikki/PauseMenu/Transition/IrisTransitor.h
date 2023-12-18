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
	bool isTiled_ = false;
public:
	IrisTransitor(bool irisOut=false,int interval = 60,bool isTiled=false , int gHandle=-1);
	~IrisTransitor();
	virtual void Update() override;
	virtual void Draw() override;
};

