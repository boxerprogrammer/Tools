#include<DxLib.h>
#include<vector>
#include"Geometry.h"

void
DrawFlexibleGraph(const Position2f& p0,const Position2f& p1,const Position2f& p2 ,const Position2f& p3,int handle, bool transp) {
	int srcW;
	int srcH;
	GetGraphSize(handle, &srcW, &srcH);
	VERTEX2D verts[4] = {};
	for (auto& v : verts) {
		v.dif.r = v.dif.g = v.dif.b = v.dif.a = 255;
		v.rhw = 1.0f;
	}

	float uw = (p1 - p0).Length();//上辺の長さ
	float dw = (p2 - p3).Length();//下辺の長さ
	float lh = (p3 - p0).Length();//左の高さ
	float rh = (p2 - p1).Length();//右の高さ

	float ruw = static_cast<float>(uw) / static_cast<float>(srcW);
	float rlh = static_cast<float>(lh) / static_cast<float>(srcH);
	float rdw = static_cast<float>(dw) / static_cast<float>(srcW);
	float rrh = static_cast<float>(rh) / static_cast<float>(srcH);

	verts[0].pos.x = p0.x;
	verts[0].pos.y = p0.y;
	verts[0].u = 0.0f;
	verts[0].v = 0.0f;

	verts[1].pos.x = p1.x;
	verts[1].pos.y = p1.y;
	verts[1].u = ruw;
	verts[1].v = 0.0f;

	verts[2].pos.x = p3.x;
	verts[2].pos.y = p3.y;
	verts[2].u = 0.0f;
	verts[2].v = 1.0f;


	verts[3].pos.x = p2.x;
	verts[3].pos.y = p2.y;
	verts[3].u = rdw;
	verts[3].v = 1.0f;

	unsigned short indices[6] = { 0,1,2,1,3,2 };

	DrawPolygonIndexed2D(verts, 4, indices, 2, handle, true);
}

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

float Saturate(float val, float minV = 0.0f, float maxV = 1.0f) {
	return min(max(val,minV), maxV);
}

//線分と点の当たり判定をとる(「遊び」として半径を設定)
//つまりカプセル状の当たり判定となる！！！
bool IntersectPosAndLine(const Position2f& p0, const Position2f& p1, const Position2f pos,float w,float r) {
	auto L = p1 - p0;
	auto P = pos - p0;

	auto t = Saturate(Dot(L,P)/L.SQLength());

	auto d = (pos - (p0 + L * t)).Length();

	return w + r >= d;

}

int WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int) {
	//
	ChangeWindowMode(true);
	SetWindowText("マップツール");
	DxLib_Init();
	SetDrawScreen(DX_SCREEN_BACK);
	auto mapH=LoadGraph("MapData.png");
	auto blockH = LoadGraph("block2.png");
	SetTextureAddressModeUV(DX_TEXADDRESS_WRAP, DX_TEXADDRESS_WRAP);

	char keystate[256];
	int x=100, y=100;
	int w = 32, dy = 0,h=32;

	std::vector<Position2f> points;
	points.emplace_back(x, y);
	points.emplace_back(x+w, y+dy);



	bool leftCaptured = false;//左ドラッグ状態にあるのか
	bool rightCaptured = false;//右ドラッグ状態にあるのか
	int capturedIdx = 0;

	while (ProcessMessage() == 0) {
		ClearDrawScreen();
		//DrawRectExtendGraph(100, 100, 300,132,0,0,32,32,mapH, true);
		GetHitKeyStateAll(keystate);
		Position2 mp;//マウス座標
		GetMousePoint(&mp.x, &mp.y);
		auto mouseInput = GetMouseInput();

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

		for (int i = 1; i < points.size(); ++i) {
			//DrawFlexibleGraph(x, y, w, 32,y+dy, blockH, true);
			Vector2f p(points[i-1]);
			Vector2f v(points[i] - points[i - 1]);
			
			auto vv = -v.Normalized().Orthogonaled().Scaled(h);

			auto p0 = p;
			auto p1 = p + v;
			auto p2 = p + v + vv;
			auto p3 = p + vv;
			DrawFlexibleGraph(p, p + v, p + v + vv, p + vv, blockH, true);
			DrawQuadrangleAA(p0.x, p0.y, p1.x, p1.y, p2.x, p2.y, p3.x, p3.y, 0xffffff, false, 1);



			//各辺と点の当たり判定
			//上辺
			if (IntersectPosAndLine(p0, p1, ConvertToVector2f(mp), 3, 3)) {
				DrawLine(p0.x, p0.y, p1.x, p1.y, 0xffaaaa, 3);
			}

			if (mouseInput == MOUSE_INPUT_LEFT && leftCaptured) {
				points[capturedIdx].x = mp.x;
				points[capturedIdx].y = mp.y-h/2;
			}
			if (mouseInput == MOUSE_INPUT_RIGHT && rightCaptured) {
				points[capturedIdx].x = mp.x;
				points[capturedIdx].y = mp.y - h / 2;
			}

			//右辺
			if (IntersectPosAndLine(p1, p2, ConvertToVector2f(mp), 3, 3)) {
				DrawLine(p1.x, p1.y, p2.x, p2.y, 0xffaaaa, 3);
				if (mouseInput == MOUSE_INPUT_LEFT) {
					leftCaptured = true;
					capturedIdx = i;
				}
				if (mouseInput == MOUSE_INPUT_RIGHT) {
					if (!rightCaptured) {
						points.push_back(points[i]);
						capturedIdx = points.size()-1;
					}
					rightCaptured = true;
				}
				
			}
			if (mouseInput != MOUSE_INPUT_RIGHT) {
				rightCaptured = false;
			}
			if (leftCaptured!=MOUSE_INPUT_LEFT) {
				leftCaptured = false;
			}
			//下辺
			if (IntersectPosAndLine(p2, p3, ConvertToVector2f(mp), 3, 3)) {
				DrawLine(p2.x, p2.y, p3.x, p3.y, 0xffaaaa, 3);
			}

			//左辺
			if (IntersectPosAndLine(p3, p0, ConvertToVector2f(mp), 3, 3)) {
				DrawLine(p3.x, p3.y, p0.x, p0.y, 0xffaaaa, 3);
			}
		}
		DrawFormatString(10, 10, 0xffffff, "capturedIdx=%d", capturedIdx);


		//DrawBox(x, y, x + w + 1, y + 32 + 1, 0xffffff, false);
		ScreenFlip();
	}

	DxLib_End();

}