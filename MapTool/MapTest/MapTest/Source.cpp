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
	verts[2].v = rlh;


	verts[3].pos.x = p2.x;
	verts[3].pos.y = p2.y;
	verts[3].u = rdw;
	verts[3].v = rrh;

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
	verts[2].v = rh;


	verts[3].pos.x = dx+w;
	verts[3].pos.y = dy + h;
	verts[3].u = rw;
	verts[3].v = rh;

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
	verts[2].v = rh;


	verts[3].pos.x = dx + w;
	verts[3].pos.y = ry + h;
	verts[3].u = rw;
	verts[3].v = rh;

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

const int screen_w = 1280;
const int screen_h = 720;

int WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int) {
	//
	ChangeWindowMode(true);
	SetWindowText("マップツール");
	SetGraphMode(screen_w, screen_h, 32);
	DxLib_Init();
	SetDrawScreen(DX_SCREEN_BACK);
	
	auto mapH=LoadGraph("MapData.png");

	//知ってしまった…LoadDivGraphおよびDerivationGraphは同一リソースアドレスを参照していることを…
	//つまりデータとしては分かれてない。という事はDrawGraph内部であたかも別リソースのように扱えるように
	//しているだけで、実際には分かれてないのだ。くっそー。
	int block0H = LoadGraph("img/ground00.png");
	int blockH= LoadGraph("img/ground0.png");
	int block2H = LoadGraph("img/ground1.png");
	int block3H = LoadGraph("img/ground2.png");
	//int partsOrigH;
	//int partsH[16];
	//partsOrigH=LoadGraph("img/bg_chips.png");
	//for (int i = 0; i < 16; ++i) {
	//	int idxX = i % 4;
	//	int idxY = i / 4;
	//	partsH[i]=DerivationGraph(idxX * 32, idxY * 32, 32, 32, partsOrigH);
	//}
	//DeleteGraph(partsOrigH);
	//LoadDivGraph("img/bg_chips.png", 16, 4, 4, 32, 32, partsH);
	//blockH = partsH[0];
	//DrawGraph(100, 100, blockH, true);
	//ScreenFlip();
	//WaitKey();


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

			//DrawFlexibleGraph(Vector2f(p0.x, p0.y + 63), Vector2f(p1.x, p1.y + 63), Vector2f(p2.x, 720), Vector2f(p3.x, 720), block3H, true);
			//DrawFlexibleGraph(Vector2f(p0.x, p0.y + 30), Vector2f(p1.x, p1.y + 30), Vector2f(p2.x, p2.y + 32), Vector2f(p3.x, p3.y + 32), block2H, true);


			//DrawTile(0, 0, 128, 128, 3, 1, 1.0f, 0.0f, block2H, true);
		

			auto pl = p0;
			auto pr = p0;

			if (p1.x < pl.x) {
				pl= p1;
			}
			if (p2.x < pl.x) {
				pl = p2;
			}
			else if (pl.x==p2.x&&pl.y<p2.y) {
				pl = p2;
			}
			if (p3.x < pl.x) {
				pl = p3;
			}
			else if (pl.x == p3.x&&pl.y < p3.y) {
				pl = p3;
			}
			pl.y = p3.y;

			if (p1.x > pr.x) {
				pr = p1;
			}
			if (p2.x > pr.x) {
				pr = p2;
			}else if (pr.x == p2.x&&pr.y < p2.y) {
				pr = p2;
			}
			if (p3.x > pr.x) {
				pr = p3;
			}else if (pr.x == p3.x&&pr.y < p3.y) {
				pr = p3;
			}
			pr.y = p2.y;

			//ブロック表示
			auto a = (p1.y - p0.y) / (p1.x - p0.x);
			
			//左ひとつめ
			//DrawGraph(pl.x, pl.y, a<=0?blockH:block2H, true);
			int blocknum = (pr.x - pl.x) / w;

			auto absa = fabsf(a);
			
			int remainW = pr.x - pl.x;
			remainW %= w;
			if (a < 0) {//右上がり
				for (int i = 1; i <= blocknum ; ++i) {
					//DrawGraph(pr.x - i * w, pr.y - (i-1) * w*a, block2H, true);

					DrawFlexibleGraph(pr.x - i * w, pr.y - (i - 1) * w*a, w, screen_h - pr.y+2, block2H, false);
				}

				DrawFlexibleGraph(pl.x, pl.y, remainW+1, screen_h-pl.y+2, block2H, true);
			}else {//右下がり
				for (int i = 0; i < blocknum; ++i) {
					DrawFlexibleGraph(pl.x + i * w, pl.y + i * w*a, w, screen_h - pl.y+2, block2H, false);
					//DrawGraph(pl.x + i * w, pl.y + i * w*a, block2H, true);
				}

				int remainX = pr.x - remainW-1;
				int remainY = pr.y;
				DrawFlexibleGraph(remainX, remainY, remainW+1, screen_h-remainY+2, block2H, true);
			}

			//右ひとつめ
			//DrawGraph(pr.x-32, pr.y, a < 0 ? block2H : blockH, true);

			//斜めありのグラフィクス表示
			DrawFlexibleGraph(p0, p1, p2, p3, blockH, true);

			//枠
			//DrawQuadrangleAA(p0.x, p0.y, p1.x, p1.y, p2.x, p2.y, p3.x, p3.y, 0xffffff, false, 1);


			DrawCircle(points[0].x, points[0].y, 2, 0xffffff);
			DrawCircle(points[0].x, points[0].y, 4, 0xffffff, false);
			//コントロールポイントの明示
			for (int i = 1; i < points.size(); ++i) {
				//for (auto& p : points) {
				DrawLine(points[i].x, points[i].y, points[i - 1].x, points[i - 1].y, 0xffffff, 2);
				DrawCircle(points[i].x, points[i].y, 2, 0xffffff);
				DrawCircle(points[i].x, points[i].y, 4, 0xffffff, false);
			}

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
						if (i < points.size() - 1) {
							auto it = points.begin() + i;
							points.insert(it,points[i] + v.Normalized().Scaled(2.0f));
							capturedIdx = i+1;
						}
						else {
							points.push_back(points[i] + v.Normalized().Scaled(2.0f));
							capturedIdx = points.size() - 1;
						}
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
						if (i == 1) {
							points.insert(points.begin(), points.front());
							capturedIdx = 0;
						}
						//else {
						//	points.insert(points.begin() + i - 1, points[i-1]);
						//	capturedIdx = i - 1;
						//}
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