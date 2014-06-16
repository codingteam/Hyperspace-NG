Shader "Custom/Planet/Gas"
{
	Properties
	{
		_DetailTex ("Detail texture", 2D) = "white" {}
		_DarkColor("Dark color", Color) = (0,0,0,1)
		_LightColor("Light color", Color) = (1,1,1,1)
		_Bands("Number of bands", float) = 1
		_Curvature("Curvature", float) = 1
		_Offset("Offset", float) = 0
		_DetailAmount ("Detail amount", float) = 0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _DetailTex;
		
		float4 _DarkColor;
		float4 _LightColor;
		float _Bands;
		float _Curvature;
		float _Offset;
		float _DetailAmount;
		
		const float pi = 3.14159;

		struct Input
		{
			float2 uv_DetailTex;
		};

		void surf (Input IN, inout SurfaceOutput o)
		{
			float pitch = frac(IN.uv_DetailTex.y * _Bands + _Offset)* 2 - 1;
			float majorColor = 1 - pow(abs(pitch), _Curvature);
			float detail = length(tex2D(_DetailTex, IN.uv_DetailTex).rgb);
			float resultingColor = lerp(majorColor, detail, _DetailAmount);
			o.Albedo = lerp (_DarkColor, _LightColor, resultingColor);
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
