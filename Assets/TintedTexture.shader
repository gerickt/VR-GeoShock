Shader "Tinted Texture" 
{
    Properties 
	{
      _MainTex ("Texture", 2D) = "white" {}
	  _Color ("Tint", Color) = (1, 1, 1, 1)
    }
    SubShader 
	{
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
      };
      sampler2D _MainTex;
	  half4 _Color;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * _Color;
      }
      ENDCG
    } 
    Fallback "Diffuse"
}