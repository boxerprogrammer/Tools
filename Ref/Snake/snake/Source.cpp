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
	Vector2 Scaled(float scale) {
		return Vector2(x*scale, y*scale);
	}
};

Vector2 operator+(const Vector2& lval, const Vector2& rval) {
	return Vector2(lval.x + rval.x, lval.y + rval.y);
}

int main() {

	ChangeWindowMode(true);
	DxLib_Init();
	SetDrawScreen(DX_SCREEN_BACK);

	auto handle=LoadGraph("img/snake.png");


	int snakeW, snakeH;
	GetGraphSize(handle, &snakeW, &snakeH);
	const int divNum = 25;
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
		Vector2 lastVV1(0,0);
		for (int i = 0; i < divNum; ++i) {

			const float amplitude = 50.0f;
			x0 = origX + i * divw;
			x1 = origX + (i + 1) * divw;
			y0=origY+amplitude*sin(2.0f*DX_PI*((float)i) / (float)divNum + (float)frame / 20.0f);
			y1 = origY + amplitude * sin(2.0f*DX_PI*((float)i+1.0f ) / (float)divNum + (float)frame /20.0f);

			

			auto v = Vector2(x1 - x0, y1 - y0);

			auto vv0 = v.Normalized();
			vv0=vv0.Orthogonal();
			vv0.Scale((float)snakeH/2.0f);

			auto vv1 = vv0;
			if (i < divNum - 1) {
				int j = i + 1;
				float nx0 = origX + j * divw;
				float nx1 = origX + (j + 1) * divw;
				float ny0 = origY + amplitude * sin(2.0f*DX_PI*((float)j) / (float)divNum + (float)frame / 20.0f);
				float ny1 = origY + amplitude * sin(2.0f*DX_PI*((float)j + 1.0f) / (float)divNum + (float)frame / 20.0f);
				auto nv= Vector2(nx1 - nx0, ny1 - ny0);
				vv1 = nv.Normalized().Orthogonal().Scaled((float)snakeH / 2.0f);
				vv1 = (vv0 + vv1).Normalized().Scaled((float)snakeH / 2.0f);
			}

			if (i >0) {
			//	int j = i - 1;
			//	float px0 = origX + j * divw;
			//	float px1 = origX + (j + 1) * divw;
			//	float py0 = origY + amplitude * sin(2.0f*DX_PI*((float)j + (float)frame / 10.0f) / (float)divNum);
			//	float py1 = origY + amplitude * sin(2.0f*DX_PI*((float)j + 1.0f + (float)frame / 10.0f) / (float)divNum);
			//	auto nv = Vector2(px1 - px0, py1 - py0);
			//	vv0 = nv.Normalized().Orthogonal().Scaled((float)snakeH / 2.0f);
			//	vv0 = (vv0 + vv1).Normalized().Scaled((float)snakeH / 2.0f);
				vv0=lastVV1;
			}

			DrawLine(x0 - vv0.x, y0 - vv0.y,
					x0 + vv0.x, y0 + vv0.y, 0xffaaaa, 2);

			DrawLine(x1 - vv1.x, y1 - vv1.y,
				x1 + vv1.x, y1 + vv1.y, 0xffaaaa, 2);

			//DrawLine(x0 - vv.x, y0 - vv.y,
			//	x0 + vv.x, y0 + vv.y, 0xffaaaa, 3);

			DrawRectModiGraph(
				x0 - vv0.x,
				y0 - vv0.y,

				x1 - vv1.x, 
				y1 -vv1.y,

				x1 +vv1.x,
				y1 +vv1.y,

				x0 + vv0.x,
				y0 + vv0.y,

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

			lastVV1 = vv1;

			DrawLine(origX + i * divw, 100+y0, origX + (i + 1) * divw, 100+y1, 0xffffff, 1);

			DrawLine(x0 , 100+y0 - snakeH/2,
				x0 , 100+y0 +snakeH/2, 0xffffff, 2);

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