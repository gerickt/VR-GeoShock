Shader "Tinted Masked Texture" 
{
    Properties 
	{
      _MainTex ("Texture", 2D) = "white" {}
	  _Color ("Tint", Color) = (1, 1, 1, 1)
    }
    SubShader 
	{
      Tags { "RenderType" = "Transparent" }
      CGPROGRAM
      #pragma surface surf Lambert alpha
      struct Input 
	  {
          float2 uv_MainTex;
      };
      sampler2D _MainTex;
	  half4 _Color;
      void surf (Input IN, inout SurfaceOutput o) 
	  {
		  half4 t = tex2D (_MainTex, IN.uv_MainTex).rgba;
          o.Albedo = t.rgb * _Color * t.a;
		  o.Alpha = t.a;
      }
      ENDCG
    } 
    Fallback "Diffuse"
}
