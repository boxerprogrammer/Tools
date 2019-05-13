#include<DxLib.h>
#include<cmath>

struct Vector2 {
	float x;
	float y;
	Vector2(float x_, float y_) :x(x_), y(y_) {};
	float Magnitude()const {
		return sqrt(x*x + y * y);
	}
	Vector2 Normalized() {
		auto mag = Magnitude();
		return Vector2(x/mag,y/mag);
	}
	//’¼ŒðƒxƒNƒgƒ‹‚ð•Ô‚·
	Vector2 Orthogonal() {
		return Vector2(-y, x);
	}
	void Scale(float scale) {
		x *= scale;
		y *= scale;
	}
};

int main() {

	ChangeWindowMode(true);
	DxLib_Init();
	SetDrawScreen(DX_SCREEN_BACK);

	auto handle=LoadGraph("img/snake.png");


	int snakeW, snakeH;
	GetGraphSize(handle, &snakeW, &snakeH);
	const int divNum = 10;
	int origX=200, origY=200;
	int frame = 0;
	while (ProcessMessage() == 0) {
		ClearDrawScreen();

		DrawGraph(origX, origY+200, handle,true);

		//“™•ªŠ„
		auto divw = snakeW / divNum;
		int y0, y1;
		int x0, x1;
		y0 = y1 = origY;
		for (int i = 0; i < divNum; ++i) {

			const float amplitude = 20.0f;
			x0 = origX + i * divw;
			x1 = origX + (i + 1) * divw;
			y0=origY+amplitude*sin(2.0f*DX_PI*((float)i+(float)frame/20.0f) / (float)divNum);
			y1 = origY + amplitude * sin(2.0f*DX_PI*((float)i+1.0f + (float)frame / 20.0f) / (float)divNum);

			auto v = Vector2(x1 - x0, y1 - y0);
			auto vv = v.Normalized();
			vv=vv.Orthogonal();
			vv.Scale(snakeH/2);

			//DrawLine(x0 - vv.x, y0 - vv.y,
			//	x0 + vv.x, y0 + vv.y, 0xffaaaa, 3);

			DrawRectModiGraph(
				x0 - vv.x,
				y0 - vv.y,

				x1 - vv.x, 
				y1 -vv.y,

				x1 +vv.x,
				y1 +vv.y,

				x0 + vv.x,
				y0 + vv.y,

				i* divw, 0, divw, snakeH, handle, true);

			DrawRectModiGraph(
				origX + i * divw,
				100+y0 - snakeH / 2,

				origX + (i + 1) * divw,
				100 + y1 - snakeH / 2,

				origX + (i + 1) * divw,
				100 + y1 + snakeH / 2,

				origX + i * divw,
				100 + y0 + snakeH / 2,
				
				i* divw, 0, divw, snakeH, handle, true);

			//DrawLine(origX + i * divw, y0, origX + (i + 1) * divw, y1, 0xffffff, 2);

			//DrawLine(x0 , y0 - snakeH/2,
			//	x0 , y0 +snakeH/2, 0xffffff, 3);

			//DrawLine(x0-vv.x, y0-vv.y, 
			//	x0+vv.x, y0+vv.y, 0xffaaaa, 3);


			//DrawCircle(origX + i * divw, y0,5,0xffaaaa,false,2);
		}
		DrawCircle(origX + divNum * divw, y1, 5, 0xffaaaa, true, 2);

		++frame;

		ScreenFlip();
	}

	return 0;
}