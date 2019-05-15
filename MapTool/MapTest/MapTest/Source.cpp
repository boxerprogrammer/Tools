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

//四角形の中に点があるかどうかを判定する
bool PointInQuad(const Position2f& p0, const Position2f& p1, const Position2f& p2, const Position2f& p3, const Position2f pos) {
	return false;
}

int WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int) {
	//
	ChangeWindowMode(true);
	SetWindowText("マップツール");
	SetGraphMode(1280, 720, 32);
	DxLib_Init();
	SetDrawScreen(DX_SCREEN_BACK);
	
	auto mapH=LoadGraph("MapData.png");
	auto blockH = LoadGraph("block2.png");
	int w,  h;
	GetGraphSize(blockH, &w, &h);

	SetTextureAddressModeUV(DX_TEXADDRESS_WRAP, DX_TEXADDRESS_WRAP);

	char keystate[256];
	int x=100, y=100;

	std::vector<Position2f> points;
	points.emplace_back(x, y);
	points.emplace_back(x+w, y);

	bool leftCaptured = false;//左ドラッグ状態にあるのか
	bool rightCaptured = false;//右ドラッグ状態にあるのか
	int capturedIdx = 0;

	while (ProcessMessage() == 0) {
		ClearDrawScreen();
		GetHitKeyStateAll(keystate);
		Position2 mp;//マウス座標
		GetMousePoint(&mp.x, &mp.y);
		auto mouseInput = GetMouseInput();

		for (int i = 1; i < points.size(); ++i) {
			//データ通りに描画
			Vector2f p(points[i-1]);
			Vector2f v(points[i] - points[i - 1]);
			auto vv = -v.Normalized().Orthogonaled().Scaled(h);
			auto p0 = p;//左上
			auto p1 = p + v;//右上
			auto p2 = p + v + vv;//右下
			auto p3 = p + vv;//左下

			//次の奴チェックして、次の奴があるなら合うように補正する
			if (i + 1 < points.size()) {
				Vector2f p(points[i]);
				Vector2f v2(points[i+1] - points[i]);
				auto vv2 = -v2.Normalized().Orthogonaled().Scaled(h);//次の左下
				auto vv3 = (vv + vv2).Normalized().Scaled(h);//左下
				p2 = p1 + vv3;
			}

			//前の奴チェックして、前の奴があるなら合うように補正する
			if (i-1 > 0) {
				Vector2f p(points[i-2]);
				Vector2f v2(points[i -1] - points[i-2]);
				auto vv2 = -v2.Normalized().Orthogonaled().Scaled(h);//前の右下
				auto vv3 = (vv + vv2).Normalized().Scaled(h);//右下
				p3 = p0 + vv3;
			}


			DrawFlexibleGraph(p0, p1, p2, p3, blockH, true);
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
				//「選択状態だよ」描画
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

			//下辺
			if (IntersectPosAndLine(p2, p3, ConvertToVector2f(mp), 3, 3)) {
				DrawLine(p2.x, p2.y, p3.x, p3.y, 0xffaaaa, 3);
			}

			//左辺
			if (IntersectPosAndLine(p3, p0, ConvertToVector2f(mp), 3, 3)) {
				//「選択状態だよ」描画
				DrawLine(p3.x, p3.y, p0.x, p0.y, 0xffaaaa, 3);
				if (mouseInput == MOUSE_INPUT_LEFT) {
					leftCaptured = true;
					capturedIdx = i-1;
				}
				if (mouseInput == MOUSE_INPUT_RIGHT) {
					if (!rightCaptured) {
						points.insert(points.begin(), points.front());
						capturedIdx = 0;
					}
					rightCaptured = true;
				}
			}

			if (mouseInput != MOUSE_INPUT_RIGHT) {
				rightCaptured = false;
			}
			if (mouseInput != MOUSE_INPUT_LEFT) {
				leftCaptured = false;
			}



		}
		//DrawFormatString(10, 10, 0xffffff, "capturedIdx=%d", capturedIdx);


		//DrawBox(x, y, x + w + 1, y + 32 + 1, 0xffffff, false);
		ScreenFlip();
	}

	DxLib_End();

}