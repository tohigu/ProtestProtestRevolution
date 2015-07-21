// Shader created with Shader Forge v1.17 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.17;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:33131,y:32725,varname:node_3138,prsc:2|emission-3745-RGB,alpha-3032-OUT;n:type:ShaderForge.SFN_Code,id:3032,x:32432,y:32735,varname:node_3032,prsc:2,code:aQBmACgAYwAuAGcAIAA+AD0AIAAwAC4ANgA3ACAAJgAmACAAYwAuAHIAIAA8AD0AIAAwAC4ANgA1ACAAJgAmACAAYwAuAGIAIAA8AD0AIAAwAC4ANgA1ACkACgB7AAoAcgBlAHQAdQByAG4AIAAwAC4AMAA7AAoAfQAgAAoACgByAGUAdAB1AHIAbgAgADEALgAwADsA,output:0,fname:SetAlpha,width:535,height:132,input:2,input_1_label:c|A-3745-RGB;n:type:ShaderForge.SFN_Tex2d,id:3745,x:32421,y:32654,ptovrint:False,ptlb:VideoTexture,ptin:_VideoTexture,varname:node_3745,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:8258,x:34368,y:32199,varname:node_8258,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:2011,x:34604,y:32136,varname:node_2011,prsc:2|A-8258-UVOUT;n:type:ShaderForge.SFN_Time,id:6567,x:34155,y:31915,varname:node_6567,prsc:2;n:type:ShaderForge.SFN_Vector2,id:3980,x:34200,y:32038,varname:node_3980,prsc:2,v1:1,v2:0.75;n:type:ShaderForge.SFN_Multiply,id:4534,x:34430,y:32002,varname:node_4534,prsc:2|A-6567-T,B-3980-OUT,C-6846-OUT;n:type:ShaderForge.SFN_Add,id:3155,x:34782,y:32022,varname:node_3155,prsc:2|A-2011-OUT,B-4534-OUT;n:type:ShaderForge.SFN_Vector1,id:6846,x:34297,y:32138,varname:node_6846,prsc:2,v1:0.25;proporder:3745;pass:END;sub:END;*/

Shader "Shader Forge/ShaderGrayson" {
    Properties {
        _VideoTexture ("VideoTexture", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            float SetAlpha( float3 c ){
            if(c.g >= 0.5 && c.r <= 0.65 && c.b <= 0.65)
            {
            return 0.0;
            } 
            
            return 1.0;
            }
            
            uniform sampler2D _VideoTexture; uniform float4 _VideoTexture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float4 _VideoTexture_var = tex2D(_VideoTexture,TRANSFORM_TEX(i.uv0, _VideoTexture));
                float3 emissive = _VideoTexture_var.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,SetAlpha( _VideoTexture_var.rgb ));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
