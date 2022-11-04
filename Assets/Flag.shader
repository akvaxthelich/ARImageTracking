Shader "Flag/FlagShader" //Dear carmine: most of this code is from a github repository for this particular shader, i hope you do not mind me using it
{
	//the actual setup for use was not specified
	Properties{
		_MainTex("Albedo (RGB)", 2D) = "white" {} //tex2D
		_Speed("Speed", Range(0, 5.0)) = 1			//how fast
		_Frequency("Frequency", Range(0, 100)) = 1 //how many waves
		_Amplitude("Amplitude", Range(0, 5.0)) = 1 //how far
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			Cull off

			Pass {

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc" //cginc for defaults

				sampler2D _MainTex;
				float4 _MainTex_ST;

				struct v2f {
					float4 pos : SV_POSITION;
					float2 uv : TEXCOORD0;
				};

				float _Speed;
				float _Frequency; //instantiate shit from above
				float _Amplitude;

				v2f vert(appdata_base v)
				{
					v2f o;
					v.vertex.y += cos((v.vertex.x + _Time.y * _Speed) * _Frequency) * _Amplitude * (v.vertex.x - 5);
					//generate flag wave as vertex component
					//add cos of x pos * time, mult all variables. 

					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					return tex2D(_MainTex, i.uv); //leave color, apply over uv from v2f
				}

				ENDCG

			}
		}
			FallBack "Diffuse"
}