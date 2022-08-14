#include "Assets/Packages/unity-gist/Cginc/Shape.cginc"
#include "Assets/Packages/unity-gist/Cginc/Constant.cginc"
#include "Assets/Packages/unity-gist/Cginc/Rotation.cginc"

void DrawRadiation_float(float2 UV, float Count, float Width, float Pattern, out float Out) {
	Out = 0;
	float2 center = 0.5;
	float w = Width;
	float s = 1;
	for (uint i = 0; i < Count; i++) {
		if (Pattern == 1) {
			if (i <= Count / 2)
				w += 1e-3;
			else
				w -= 1e-3;
		}
		if (Pattern == 2) {
			if (i <= Count / 2)
				s = i / Count;
			else
				s = 1 - i / Count;
		}

		Out += s * drawLineHard(UV, float2(i / Count, 1), center, w);
		Out += s * drawLineHard(UV, float2(1, 1 - i / Count), center, w);
		Out += s * drawLineHard(UV, float2(1 - i / Count, 0), center, w);
		Out += s * drawLineHard(UV, float2(0, i / Count), center, w);
	}
	Out = saturate(Out);
}