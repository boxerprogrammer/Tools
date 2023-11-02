#pragma once
#include "Scene.h"
class GameoverScene :
    public Scene
{
public:
    GameoverScene(SceneManager& manager);
    virtual void Update(Input& input)override;
    virtual void Draw()override;
};

