﻿// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/FogLight"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Colour ("Colour", Color) = (0, 0, 1, 1)
		_Bias ("Bias", Float) = 0
		_ScanFrequency ("Scan Frequency", Float) = 100
		_ScanSpeed ("Scan Speed", Float) = 100
	} 
	SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType"="Alpha" }
		LOD 100
		ZWrite Off
		Blend SrcAlpha One
		Cull off


		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float4 objVertex : TEXCOORD1;
			};

			fixed4 _Colour;

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _Bias;
			float _ScanSpeed;
			float _ScanFrequency;

			
			v2f vert (appdata v)
			{
				v2f o;
				o.objVertex = mul(unity_ObjectToWorld, v.vertex);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv - 0.5);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				col = _Colour * max(0.5, cos((i.objVertex.y + i.objVertex.z) * _ScanFrequency + 
				(_Time.x + _Time.y + _Time.z) * _ScanSpeed) + _Bias);
				return col;
			}
			ENDCG
		}
	}
}
