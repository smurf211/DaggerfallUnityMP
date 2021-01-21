Shader "Daggerfall/PixelFont"
{
	Properties
    {
        _MainTex ("Texture", any) = "" {}
        _ScissorRect("Scissor Rectangle", Vector) = (0,1,0,1)   // x=left, y=right, z=bottom, w=top - fullscreen is (0,1,0,1)
    }

	SubShader {

		Tags { "ForceSupported" = "True" "RenderType"="Overlay" } 
		
		Lighting Off 
		Blend SrcAlpha OneMinusSrcAlpha 
		Cull Off 
		ZWrite Off 
		Fog { Mode Off } 
		ZTest Always
		
		Pass {	
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
                float2 screenPos : TEXCOORD1;
			};

			sampler2D _MainTex;
            uniform float4 _MainTex_ST;
            float4 _ScissorRect;
			
			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
                o.screenPos = ComputeScreenPos(o.vertex);
				return o;
			}

			fixed4 frag (v2f i) : SV_Target
			{
                if (i.screenPos.x < _ScissorRect.x || i.screenPos.x > _ScissorRect.y ||
                    i.screenPos.y < _ScissorRect.z || i.screenPos.y > _ScissorRect.w)
                    discard;

                float alpha = tex2D(_MainTex, i.texcoord).a;

                return float4(i.color.rgb, alpha);
			}
			ENDCG 
		}
	} 
	
	Fallback off
}