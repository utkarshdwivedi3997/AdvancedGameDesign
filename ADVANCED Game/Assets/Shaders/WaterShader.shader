// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/WaterShader" {
	Properties {
		_Tint("Main Tint", Color) = (1,1,1,0.5)
		_TintB("Secondary Tint", Color) = (1,1,1,0.5)
		_MainTex("Main Texture", 2D) = "white" {}
		_NoiseTex("Noise Texture", 2D) = "white" {}

		_Foam("Foamline Thickness", Range(0,10)) = 0.5
		_FoamTint("Foam Tint", Color) = (1,1,1,0.5)
		_FoamGradient("Foam Gradient", 2D) = "white" {}
		_FoamTexture("Foam Texture", 2D) = "white" {}
		_XScrollSpeed("X Scroll Speed", Range(0,10)) = 0.5
		_YScrollSpeed("Y Scroll Speed", Range(0,10)) = 0.5

		_NormalMain("Main Normal Map", 2D) = "bump" {}
		_NormalSecondary("Secondary Normal Map", 2D) = "bump" {}
		_NormalIntensity("Normal Intensity", Range(0,10)) = 1.0

		_Glossiness ("Smoothness", Range(0,1)) = 0.71
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Transparent" "IgnoreProjector"="True" "Queue"="Transparent" }
		LOD 100
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha:auto

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		// Variables
		sampler2D _MainTex, _NormalMain, _NormalSecondary;
		fixed4 _Color;
		float4 _Tint, _TintB, _FoamTint;
		float _NormalIntensity;
		uniform sampler2D _CameraDepthTexture; // Depth Texture
		//float4 _MainTex_ST;
		float _Foam, _XScrollSpeed, _YScrollSpeed;
		sampler2D _FoamGradient, _FoamTexture;
		half _Glossiness;

		struct Input {
			float2 uv_MainTex : TEXCOORD0;
			float2 uv_NormalMain;
			float2 uv_NormalSecondary;
			float4 screenPos; // : TEXCOORD2;
			float3 viewDir;
			float3 wNormal;
		};

		half _Metallic;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input i, inout SurfaceOutputStandard o) {
			fixed xScroll = _XScrollSpeed * _Time.y;
			fixed yScroll = _YScrollSpeed * _Time.y;
			fixed2 scrolledUV = i.uv_MainTex + half2(xScroll, yScroll);
			

			float fresnelEffect = pow((1.0 - saturate(dot(normalize(i.wNormal), normalize(i.viewDir)))), 2/*power*/);
			fixed4 tint = lerp(_Tint, _TintB, fresnelEffect);

			fixed4 col = tex2D(_MainTex, scrolledUV) * tint;	// texture times tint + UV scrolling

			// Normals
			fixed2 scrolledNormalA = i.uv_NormalMain + fixed2(xScroll, yScroll);
			fixed2 scrolledNormalB = i.uv_NormalSecondary + fixed2(-xScroll, -yScroll);
			fixed3 normalMapA = fixed4(_NormalIntensity, _NormalIntensity, 1, 1) * UnpackNormal(tex2D(_NormalMain, scrolledNormalA));
			fixed3 normalMapB = fixed4(0.5 * _NormalIntensity, 0.5 * _NormalIntensity, 1, 1) * UnpackNormal(tex2D(_NormalSecondary, scrolledNormalB));
			fixed3 normalMap = normalize(fixed3(normalMapA.rg+normalMapB.rg, normalMapA.b * normalMapB.b));
			o.Normal = normalMap;

			// Foam
			fixed4 depth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.screenPos)).r);	// depth
			float foamLine = 1 - saturate(_Foam * (depth - i.screenPos.w));	// foamline by comparing depth and screenposition
			fixed3 foamGradient = 1 - tex2D(_FoamGradient, float2(foamLine - _Time.y*0.2, 0) + normalMap.xy * 0.15);

			float2 foamDistortUV = normalMap.xy * 0.2;
			half3 foamColor = tex2D(_FoamTexture, scrolledUV + foamDistortUV).rgb * _FoamTint;

			//float4 foamRamp = float4(tex2D(_FoamTexture, float2(foamLine, 0.5)).rgb, 1.0);
			col.rgb += foamLine * _FoamTint * foamGradient * foamColor;	// add the foamline and tint to the texture
			col.a += foamLine * _FoamTint.a * foamGradient * foamColor;
			// Albedo comes from a texture tinted by color
			o.Albedo = col.rgb;

			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = col.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
