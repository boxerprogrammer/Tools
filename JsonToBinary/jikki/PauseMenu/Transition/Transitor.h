#pragma once
class Transitor
{
protected:
	int interval_=60;
	int frame_=0;
	int oldRT_=0;//切り替え前の画面
	int newRT_=0;//切り替え後の画面
public:
	Transitor(int interval = 60) : interval_(interval) {}
	virtual ~Transitor();
	void Start();
	virtual void Update()=0;
	virtual void Draw() = 0;
	bool IsEnd()const;
};

