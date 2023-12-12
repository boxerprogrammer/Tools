#pragma once
class Transitor
{
protected:
	int interval_=60;
	int frame_=0;
	int oldRT_=0;//Ø‚è‘Ö‚¦‘O‚Ì‰æ–Ê
	int newRT_=0;//Ø‚è‘Ö‚¦Œã‚Ì‰æ–Ê
public:
	Transitor(int interval = 60) : interval_(interval) {}
	virtual ~Transitor();
	void Start();
	virtual void Update()=0;
	virtual void Draw() = 0;
	bool IsEnd()const;
};

