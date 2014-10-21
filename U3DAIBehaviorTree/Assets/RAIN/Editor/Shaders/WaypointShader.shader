Shader "RAIN/WaypointShader"
{
    SubShader
    {
		Offset -2, -2
		Pass
		{
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
	
			float4 _colorSolid;
			float4 _colorOutline;
			sampler2D _outlineTexture;
			
			struct vert_out
			{
				float4 position : POSITION;
				float4 texcoord : TEXCOORD0;
			};
			
			vert_out vert(appdata_base v)
			{
				vert_out tOut;
				tOut.position = mul(UNITY_MATRIX_MVP, v.vertex);
				tOut.texcoord = v.texcoord;
				
				return tOut;
			}
	
			float4 frag(vert_out f) : COLOR
			{
				return lerp(_colorOutline, _colorSolid, tex2D(_outlineTexture, f.texcoord.xy).x);
			}
				
			ENDCG
		}
    }
    FallBack "Diffuse"
}
