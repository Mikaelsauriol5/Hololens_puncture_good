﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/thickShader"
{
	Properties
	{
	_ThicknessTex("Thickness Texture", 2D) = "white" {}
	_Color("Color", Color) = (1, 1, 1, 1)
	_Sigma("Sigma", Float) = 1.0
	}

		SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag

		#include "UnityCG.cginc"

		struct appdata
		{
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
		};

		struct v2f
		{
		float2 uv : TEXCOORD0;
		float4 vertex : SV_POSITION;
		};

		v2f vert(appdata v)
		{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.uv = v.uv;

		// see http://docs.unity3d.com/Manual/SL-PlatformDifferences.html
		#if UNITY_UV_STARTS_AT_TOP
		o.uv.y = 1 - o.uv.y;
		#endif

		return o;
		}

		sampler2D _ThicknessTex;
		fixed3 _Color;
		float _Sigma;

		fixed4 frag(v2f i) : SV_Target
		{
			// adapted from http://prideout.net/blog/?p=51
			float thickness = abs(tex2D(_ThicknessTex, i.uv).r);
			if (thickness <= 0.0)
			{
			discard;
			}

			float intensity = exp(-_Sigma * thickness);
			fixed4 col = fixed4(intensity * _Color, 1);

			return col;
			}
			ENDCG
			}
	}
}
