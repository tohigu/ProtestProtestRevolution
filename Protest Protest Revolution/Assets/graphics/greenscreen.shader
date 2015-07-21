Shader "Custom/greenscreen" {
        Properties {
                _MainTex ("Base (RGB)", 2D) = "white" {}
        }
        SubShader {
                Tags { "Queue"="Transparent" "RenderType"="Transparent" }
                LOD 200
               
                CGPROGRAM
                #pragma surface surf Lambert alpha
 
                sampler2D _MainTex;
 
                struct Input {
                        float2 uv_MainTex;
                };
 
                void surf (Input IN, inout SurfaceOutput o) {
                        half4 c = tex2D (_MainTex, IN.uv_MainTex);
                        o.Albedo = c.rgb;
                       
                        // #################################
                        //
                        // CHANGE THESE VALUES DEPENDING ON WHAT SHOULD BE TRANSPARENT
                        //
                        // #################################
                        fixed v = fixed(c.g >= 200.0/255.0 && c.r <= 200.0/255.0 && c.b <= 200.0/255.0);
						o.Alpha = v;                            
                }
                ENDCG
        }
        FallBack "Diffuse"
}