#include<DxLib.h>
void
DrawFlexibleGraph(int dx, int dy, int w, int h,/* int sx, int sy, int sw, int sh,*/ int handle, bool transp) {
	int srcW;
	int srcH;
	GetGraphSize(handle, &srcW, &srcH);
	VERTEX2D verts[4] = {};
	for (auto& v : verts) {
		v.dif.r = v.dif.g = v.dif.b = v.dif.a = 255;
		v.rhw = 1.0f;
	}
	float rw = static_cast<float>(w) / static_cast<float>(srcW);
	float rh = static_cast<float>(h) / static_cast<float>(srcH);

	verts[0].pos.x = dx;
	verts[0].pos.y = dy;
	verts[0].u = 0.0f;
	verts[0].v = 0.0f;

	verts[1].pos.x = dx+w;
	verts[1].pos.y = dy;
	verts[1].u = rw;
	verts[1].v = 0.0f;

	verts[2].pos.x = dx;
	verts[2].pos.y = dy+h;
	verts[2].u = 0.0f;
	verts[2].v = 1.0f;


	verts[3].pos.x = dx+w;
	verts[3].pos.y = dy + h;
	verts[3].u = rw;
	verts[3].v = 1.0f;

	unsigned short indices[6] = { 0,1,2,1,3,2 };

	DrawPolygonIndexed2D(verts, 4, indices, 2, handle, true);
}

void
DrawFlexibleGraph(int dx, int dy, int w, int h,int ry,/* int sx, int sy, int sw, int sh,*/ int handle, bool transp) {
	int srcW;
	int srcH;
	GetGraphSize(handle, &srcW, &srcH);
	VERTEX2D verts[4] = {};
	for (auto& v : verts) {
		v.dif.r = v.dif.g = v.dif.b = v.dif.a = 255;
		v.rhw = 1.0f;
	}
	float rw = static_cast<float>(w) / static_cast<float>(srcW);
	float rh = static_cast<float>(h) / static_cast<float>(srcH);

	verts[0].pos.x = dx;
	verts[0].pos.y = dy;
	verts[0].u = 0.0f;
	verts[0].v = 0.0f;

	verts[1].pos.x = dx + w;
	verts[1].pos.y = ry;
	verts[1].u = rw;
	verts[1].v = 0.0f;

	verts[2].pos.x = dx;
	verts[2].pos.y = dy + h;
	verts[2].u = 0.0f;
	verts[2].v = 1.0f;


	verts[3].pos.x = dx + w;
	verts[3].pos.y = ry + h;
	verts[3].u = rw;
	verts[3].v = 1.0f;

	unsigned short indices[6] = { 0,1,2,1,3,2 };

	DrawPolygonIndexed2D(verts, 4, indices, 2, handle, true);
}


int WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int) {
	//
	ChangeWindowMode(true);
	DxLib_Init();
	SetDrawScreen(DX_SCREEN_BACK);
	auto mapH=LoadGraph("MapData.png");
	auto blockH = LoadGraph("block2.png");
	SetTextureAddressModeUV(DX_TEXADDRESS_WRAP, DX_TEXADDRESS_WRAP);

	char keystate[256];
	int x=100, y=100;
	int w = 32, dy = 0;
	while (ProcessMessage() == 0) {
		ClearDrawScreen();
		//DrawRectExtendGraph(100, 100, 300,132,0,0,32,32,mapH, true);
		GetHitKeyStateAll(keystate);
		if (keystate[KEY_INPUT_RIGHT]) {
			++x;
		}
		if (keystate[KEY_INPUT_LEFT]) {
			--x;
		}
		if (keystate[KEY_INPUT_UP]) {
			--y;
		}
		if (keystate[KEY_INPUT_DOWN]) {
			++y;
		}

		if (keystate[KEY_INPUT_A]) {
			--w;
		}
		if (keystate[KEY_INPUT_D]) {
			++w;
		}

		if (keystate[KEY_INPUT_W]) {
			--dy;
		}
		if (keystate[KEY_INPUT_S]) {
			dy++;
		}

		DrawFlexibleGraph(x, y, w, 32,y+dy, blockH, true);
		DrawBox(x, y, x + w + 1, y + 32 + 1, 0xffffff, false);
		ScreenFlip();
	}

	DxLib_End();

}