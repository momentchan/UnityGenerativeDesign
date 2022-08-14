#include "Assets/Packages/unity-gist/Cginc/Shape.cginc"
#include "Assets/Packages/unity-gist/Cginc/Constant.cginc"
#include "Assets/Packages/unity-gist/Cginc/Rotation.cginc"

void DrawRadiation_float(float2 UV, float Count, float Width, out float Out) {
	Out = 0;
	for (uint i = 0; i < Count; i++) {
		float angle = (PI * 0.5 / Count * i) % PI;

		float2 newUV = rotateRadians(UV, float2(0.5, 0.5), angle);
		float w = Width * abs(angle - PI);
		Out += drawLineEq(newUV, 1, 0, w);

		float2 mirrorUV = (newUV - float2(0.5, 0.5));
		mirrorUV.x *= -1;
		mirrorUV += 0.5;
		Out += drawLineEq(mirrorUV, 1, 0, w);
	}
	Out = saturate(Out);
}