#include "Assets/Packages/unity-gist/Cginc/Shape.cginc"

void DrawPattern_float(float2 UV, float Count, float Width, float2 Offset, float Pattern, out float Out) {
	Out = 0;
	if (Pattern == 0) {
		float2 center = Offset;
		for (uint i = 0; i < Count; i++) {
			Out += drawLineHard(UV, float2(i / Count, 1), center, Width);
			Out += drawLineHard(UV, float2(1, 1 - i / Count), center, Width);
			Out += drawLineHard(UV, float2(1 - i / Count, 0), center, Width);
			Out += drawLineHard(UV, float2(0, i / Count), center, Width);
		}
	}
	else {
		for (uint i = 0; i < Count; i++) {
			Out += drawLineHard(UV, float2(1, i / Count), float2(0, Offset.y), Width);
			Out += drawLineHard(UV, float2(0, i / Count), float2(1, 1 - Offset.y), Width);
		}
	}
}