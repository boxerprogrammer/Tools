#pragma once
#include "Transitor.h"
class StripTransitor :
    public Transitor
{
public:
	virtual void Start() override;
	virtual void Update() override;
	virtual void Draw() override;
	virtual bool IsEnd()const override;
};

