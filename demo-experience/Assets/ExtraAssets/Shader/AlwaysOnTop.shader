Shader "Custom/AlwaysOnTop"
{
	Properties{
		 _myColour("Colour", Color) = (1,1,1,1)
	}

    SubShader 
    {
        Tags { "Queue"="Overlay" "RenderType"="Overlay" }
        ZTest Always

        CGPROGRAM
        #pragma surface surf Lambert

        struct Input 
        {
			float2 uvMainTex;
            
        };

		fixed4 _myColour;

        void surf (Input IN, inout SurfaceOutput o)
        {
            
			o.Albedo = _myColour;
        }
        ENDCG
    }
    Fallback "Diffuse"
}