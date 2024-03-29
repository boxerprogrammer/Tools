#pragma once
#include<cmath>
template<typename T>
struct Vector2D {
	Vector2D() : x(0), y(0) {}
	Vector2D(T inx, T iny) : x(inx), y(iny) {}
	T x;
	T y;
	void operator+=(const Vector2D<T>& in) {
		x += in.x;
		y += in.y;
	}
	void operator*=(float scale) {
		x *= scale;
		y *= scale;
	}

	void operator*=(const Vector2D<T>& v) {
		x *= v.x;
		y *= v.y;
	}

	void operator-=(const Vector2D<T>& in) {
		x -= in.x;
		y -= in.y;
	}

	Vector2D<int> ToIntVec()const {
		Vector2D<int> v(x, y);
		return v;
	}
	Vector2D<float> ToFloatVec()const {
		Vector2D<float> v(x, y);
		return v;
	}
	float Length()const {
		return hypot(x, y);
	}

	float SQLength()const {
		return x*x+y*y;
	}

	Vector2D<float> Normalized()const {
		auto len = Length();
		if (len == 0.0f) {
			return Vector2D<float>(0, 0);
		}
		return Vector2D<float>((float)x / len, (float)y / len);
	}

	//90°回転する
	Vector2D<float> Orthogonaled()const {
		return Vector2D<float>((float)y , (float)-x );
	}

	//拡大
	Vector2D<float> Scaled(float scale) {
		return Vector2D<float>(x*scale, y*scale);
	}

	const Vector2D<T> operator-()const {
		return Vector2D<T>(-x, -y);
	}

};

template<typename T>
bool operator==(const Vector2D<T>& lv, const Vector2D<T>& rv) {
	return lv.x == rv.x&&lv.y == rv.y;
}


//Vector2D<T>のための+オペレータオーバーロード
template<typename T>
Vector2D<T> operator+(const Vector2D<T>& lv, const Vector2D<T>& rv) {
	return Vector2D<T>(lv.x + rv.x, lv.y + rv.y);
}

template<typename T>
Vector2D<T> operator-(const Vector2D<T>& lv, const Vector2D<T>& rv) {
	return Vector2D<T>(lv.x - rv.x, lv.y - rv.y);
}

template<typename T>
Vector2D<T> operator*(const Vector2D<T>& lv, const float scale) {
	return Vector2D<T>(lv.x*scale, lv.y*scale);
}


template<typename T>
Vector2D<T> operator*(const Vector2D<T>& lv, const  Vector2D<T>& rv) {
	return Vector2D<T>(lv.x * rv.x, lv.y * rv.y);
}

//整数型ベクトル
typedef Vector2D<int> Vector2;
typedef Vector2 Position2;

//実数ベクトル
typedef Vector2D<float> Vector2f;
typedef Vector2f Position2f;

Vector2f ConvertToVector2f(const Vector2& v);

float Dot(const Vector2f& lval, const Vector2f& rval);
float Cross(const Vector2f& lval, const Vector2f& rval);


struct Mat3x3 {
	float e[3][3];
};

Vector2f operator*(const Vector2f& inv, const Mat3x3& mat);

Mat3x3 Identity();
Mat3x3 Rotate(float angle);
Mat3x3 Translate(const Vector2f& v);
Mat3x3 CenteredRotate(const Position2f& p,float angle);


struct Size {
	int w, h;
};

struct Rect {
	Position2 pos;
	Size size;
	int offX, offY;
};