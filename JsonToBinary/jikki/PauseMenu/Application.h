#pragma once

#include<random>

class Application
{
private:
	std::mt19937 mt_;
	Application() {};
	Application(const Application&)=delete;
	void operator=(const Application&)=delete;
public:
	static Application& GetInstance() {
		static Application instance;
		return instance;
	}

	bool Init();
	void Run();
	void Terminate();

	std::mt19937 CreateRandomObject();

};

