#pragma once
#include "Scene.h"
class TitleScene :
    public Scene
{
private:
	
public:
	TitleScene(SceneManager& scene);
	virtual void Update(Input& input)override;
	virtual void Draw()override;
};

