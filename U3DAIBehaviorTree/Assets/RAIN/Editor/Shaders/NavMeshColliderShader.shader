Shader "RAIN/NavMeshColliderShader"
{
    SubShader
    {
		Offset -1, -1
		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
						
			float _maxSlopeCos; 
			float4 _colorPass; 
			float4 _colorFail; 
			float4 _ambientLight;
		
			struct vert_out
			{
				float4 position : POSITION;
				float3 normal : TEXCOORD0;
			};
			
			vert_out vert(appdata_base v)
			{
				vert_out tOut;
				tOut.position = mul(UNITY_MATRIX_MVP, v.vertex);
				tOut.normal = normalize(v.normal);
				
				return tOut;
			}
	
			float4 frag(vert_out f) : COLOR
			{
				float3 tLight = normalize(float3(10, 10, 10));
				
				float4 tAmbient = _ambientLight;
				float4 tDiffuse = clamp(float4(1, 1, 1, 1) * max(dot(f.normal, tLight), 0), 0, 1);
				
            	if (f.normal.y > (_maxSlopeCos - 0.001))
					return _colorPass * (tDiffuse + tAmbient);
				else
					return _colorFail * (tDiffuse + tAmbient);
			}
			
			ENDCG
		}
    }
    FallBack "Diffuse"
}
