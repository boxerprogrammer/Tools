#pragma once
class Transitor
{
protected:
	int interval_=60;
	int frame_=0;
	int oldRT_;
	int newRT_;
public:
	Transitor(int interval = 60) : interval_(interval) {}
	virtual ~Transitor() {};
	virtual void Start()=0;
	virtual void Update()=0;
	virtual void Draw() = 0;
	virtual bool IsEnd()const = 0;
};

