#include "Assets/Packages/unity-gist/Cginc/PhotoShopMath.cginc"

Texture2D<float4> _Source;
RWTexture2D<float4> _Result;
RWTexture2D<float4> _Sort;
int _Mode;

float GetSortValue(float3 rgb) {
	float3 hsv = rgb2hsv(rgb);
	if (_Mode == 1) return hsv.x;
	if (_Mode == 2) return hsv.y;
	if (_Mode == 3) return hsv.z;

	return Luma(rgb);
}

void CompareAndSwap(uint x, uint y, inout bool sorted) {
	uint2 current = uint2(x, y);
	uint2 next = current + uint2(1, 0);

	if (GetSortValue(_Sort[current].rgb) > GetSortValue(_Sort[next].rgb)) {
		float4 temp = _Sort[current];
		_Sort[current] = _Sort[next];
		_Sort[next] = temp;
		sorted = false;
	}
}

void Sort(uint x, uint xEnd, uint y) {
	bool sorted = false;
	while (!sorted) {
		sorted = true;
		for (uint i = x; i < xEnd - 1; i += 2)
			CompareAndSwap(i, y, sorted);

		for (i = x + 1; i < xEnd - 1; i += 2)
			CompareAndSwap(i, y, sorted);
	}
}

[numthreads(8, 8, 1)]
void Copy(uint3 id : SV_DispatchThreadID) {
	_Result[id.xy] = _Source[id.xy];
}