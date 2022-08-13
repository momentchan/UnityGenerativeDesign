#include "Assets/Packages/unity-gist/Shaders/CustomFunction/Circle.hlsl"
void MultipleCircle_float(float2 UV, float2 Center, float Count, float EndSize, out float Out) {

	for (uint i = 0; i < Count; i++) {
		float r = 1 - i / Count;
		float os = lerp(EndSize, 0.5, r);//// (1 - (1 -  EndSize) / Count * i) / 2;
		float2 c = lerp(Center, 0.5, r);
		float o;
		Circle_float(UV, c, os, os - 1e-2, o);
		Out += o;
	}
}