#pragma once
#include "Scene.h"
#include<vector>
#include<map>
#include<string>
#include<memory>
#include<array>


struct Rect {
    int x, y, w, h;
    int offX, offY;
};
class MimicFile;
class EnemyManager;
class GameScene :
    public Scene
{
private:
    std::shared_ptr<EnemyManager> enemyManager_;
    float fps_=0.0f;
    std::shared_ptr<MimicFile> cutDataFile_;
    std::vector<int> imgHs_;
    std::vector<std::string> filenames_;

    std::map<std::string, Rect> rectTable_;
    int imgH_ = 0;
    int frame_ = 0;
    int nowLoadCnt = 0;
    using UpdateFunc_t = void (GameScene::*)(Input& input);
    using DrawFunc_t = void(GameScene::*)();

    void InitializeUpdate(Input& input);
    void InitializeDraw();

    void LoadingUpdate(Input& input);
    void LoadingDraw();

    void LoadCompletedUpdate(Input& input);

    void NormalUpdate(Input& input);
    void NormalDraw();


    UpdateFunc_t updateFunc_;
    DrawFunc_t drawFunc_;
    std::array<size_t, 2> offsets_;
public:
    GameScene(SceneManager& manager);
    virtual void Update(Input& input)override;
    virtual void Draw()override;
};
