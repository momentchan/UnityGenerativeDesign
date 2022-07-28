#include "Assets/Packages/unity-gist/Cginc/Shape.cginc"
#define PI 3.1415926
void DrawShape_float(float2 UV, float radius, int segments, float width, out float Out) {
	float o;

	for (uint i = 0; i < segments; i++) {
		float angle = 2 * PI / segments * i;
		float2 p = radius * float2(cos(angle), sin(angle)) + 0.5;
		o += drawLineHard(UV, 0.5, p, width);
	}
	Out = o;
}