Shader "Hidden/Draw"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "Assets/Packages/unity-gist/Cginc/Rotation.cginc"
			#include "Assets/Packages/unity-gist/Cginc/Shape.cginc"

			sampler2D _MainTex;

			float2 _MousePos;
			float _Alpha;
			float _Width;
			float3 _Color;

			fixed4 frag(v2f_img i) : SV_Target
			{
				float2 uv = rotateDegrees(i.uv, 0.5, 45);

				float sides = floor(lerp(3, 10, saturate(_MousePos.y)));
				float ws = abs(saturate(_MousePos.x) - 0.5) * 3;
				float wb = ws + _Width;

				float sp = drawPolygon(uv, sides, ws, ws);
				float bp = drawPolygon(uv, sides, wb, wb);
				float p = bp - sp;

				fixed4 col = p;
				col.rgb *= _Color;
				col.a *= _Alpha;

				return saturate(col);
			}
			ENDCG
		}
	}
}
