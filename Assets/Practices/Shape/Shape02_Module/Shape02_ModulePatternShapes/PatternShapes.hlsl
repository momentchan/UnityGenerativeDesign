#include "Assets/Packages/unity-gist/Cginc/Shape.cginc"
#include "Assets/Packages/unity-gist/Cginc/Rotation.cginc"
#include "Assets/Packages/unity-gist/Cginc/Constant.cginc"

void RotateRectangles_float(float2 UV, float Border, float Count, float Rotation, out float Out)
{
    Out = 0;
    float size = 1;
    for (uint i = 0; i < Count; i++) {
        float2 newUV = rotateDegrees(UV, 0.5, i / Count * Rotation);

        Out += drawRectangleBorder(newUV, size, size, Border);
        size *= (1 - 3.0 / Count);
    }
}


void RotateRectanglesGradient_float(float2 UV, float Count, float Rotation, float3 Color, out float4 Out)
{
    Out = 0;
    float size = 1;
    for (uint i = 0; i < Count; i++) {
        float2 newUV = rotateDegrees(UV, 0.5, i / Count * Rotation);

        float rect = drawRectangleFill(newUV, size, size);
        float r = i / Count;
        float3 color = lerp(0, Color, r);

        Out.rgb += color * rect * r;
        Out.a += rect * r;
        size *= (1 - 3.0 / Count);
    }
    Out.a = saturate(Out.a);
}

void RotateCircle_float(float2 UV, float Count, float Rotation, float3 Color, out float4 Out)
{
    Out = 0;
    float size = 0.4;
    for (uint i = 0; i < Count; i++) {
        float2 newUV = rotateDegrees(UV, 0.5, i / Count * Rotation);

        float left = drawEllipse(newUV, float2(-1.0 * i * 1e-2 + 0.5, 0.5), size, size);
        float right = drawEllipse(newUV, float2(1.0 * i * 1e-2 + 0.5, 0.5), size, size);
        float circle = left + right;
        float r = i / Count;
        float4 color = float4(lerp(Color * circle, 1, r), circle * 0.5);

        Out = lerp(Out, color, color.a);
        size *= (1 - 1.5 / Count);
    }
    Out = saturate(Out);
}