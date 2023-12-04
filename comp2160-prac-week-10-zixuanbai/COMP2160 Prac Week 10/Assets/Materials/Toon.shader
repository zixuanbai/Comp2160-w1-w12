Shader "Unlit/Toon"
{
	Properties
	{
	_Color("Color",Color) = (1, 1, 1, 1)
	_Intensifier("Intensifier",Color) = (.5,.5,.5,1)
	_MainTex("Texture", 2D) = "white" {}
	[HDR]
	_AmbientColor("Ambient Color", Color) = (0.4,0.4,0.4,1)
	[HDR]
	_SpecularColor("Specular Color", Color) = (0.9,0.9,0.9,1)
	_Glossiness("Glossiness", Float) = 32
	[HDR]
	_RimColor("Rim Color", Color) = (1,1,1,1)
	_RimAmount("Rim Amount", Range(0,1)) = 0.716
	_RimThreshold("Rim Threshold", Range(0, 1)) = 0.1

	_OutlineSize("Outline Size", Float) = 0.01
	_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_ID("Stencil ID", Int) = 1
	}
		SubShader
	{
		Pass
		{
			Tags
			{
				"LightMode" = "ForwardBase"
				"PassFlags" = "OnlyDirectional"
			}

			Stencil
			{
				Ref [_ID]
				Comp always
				Pass replace
				Fail keep
				ZFail keep
				


			}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase

			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"

			struct appdata
			{
				float2 uv : TEXCOORD0;
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float3 worldNormal : NORMAL;
				float2 uv : TEXCOORD0;
				float3 viewDir : TEXCOORD1;
				SHADOW_COORDS(2)
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vert(appdata v)
			{

				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.viewDir = WorldSpaceViewDir(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);;
				TRANSFER_SHADOW(o)
				return o;
			}


			float4 _Color;
			float4 _Intensifier;

			float4 _AmbientColor;

			float4 _SpecularColor;
			float _Glossiness;

			float4 _RimColor;
			float _RimAmount;
			float _RimThreshold;

			float4 frag(v2f i) : SV_Target
			{
				float3 normal = normalize(i.worldNormal);
				float3 viewDir = normalize(i.viewDir);

				float NdotL = dot(_WorldSpaceLightPos0, normal);
				float shadow = SHADOW_ATTENUATION(i);
				float lightIntensity = smoothstep(0, 0.01, NdotL * shadow);
				float4 light = lightIntensity * _LightColor0;



				float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);
				float NdotH = dot(normal, halfVector);

				float specularIntensity = pow(NdotH * lightIntensity, _Glossiness * _Glossiness);

				float specularIntensitySmooth = smoothstep(0.005, 0.01, specularIntensity);
				float4 specular = specularIntensitySmooth * _SpecularColor;

				float4 rimDot = 1 - dot(viewDir, normal);

				_RimColor = _Color + _Intensifier;
				float rimIntensity = rimDot * pow(NdotL, _RimThreshold);
				rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimIntensity);
				float4 rim = rimIntensity * _RimColor;

				// sample the texture
				float4 sample = tex2D(_MainTex, i.uv);

				return _Color * sample * (_AmbientColor + light + specular + rim);



			}
			ENDCG
		}

		//Second Pass used for Outline
		Pass
		{
			Stencil
			{
				Ref [_ID]
				Comp notequal
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"


			struct appdata
		{
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};

		struct v2f
		{
			float4 vertex : SV_POSITION;
		};

		float _OutlineSize;
		float4 _OutlineColor;

		v2f vert(appdata v)
		{
			v2f o;
			float3 normal = normalize(v.normal) * _OutlineSize;
			float3 pos = v.vertex + normal;

			o.vertex = UnityObjectToClipPos(pos);

			return o;
		}

		float4 frag(v2f i) : SV_Target
		{
			return _OutlineColor;
		}



			ENDCG


		}
	usePass "Legacy Shaders/VertexLit/SHADOWCASTER"
	}
}
