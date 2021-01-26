// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33412,y:33200,varname:node_4013,prsc:2|diff-1981-OUT,spec-1421-OUT,normal-6120-RGB,emission-3830-OUT,clip-177-OUT;n:type:ShaderForge.SFN_Tex2d,id:1246,x:31793,y:32579,ptovrint:False,ptlb:Diffuse texture2d,ptin:_Diffusetexture2d,varname:node_1246,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:83584c85b2653f740a44ea14cd173067,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:5707,x:31496,y:32744,ptovrint:False,ptlb:DiffuseColor,ptin:_DiffuseColor,varname:node_5707,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:9994,x:32090,y:32703,varname:node_9994,prsc:2|A-1246-RGB,B-6228-OUT;n:type:ShaderForge.SFN_Slider,id:979,x:31531,y:33071,ptovrint:False,ptlb:color range,ptin:_colorrange,varname:node_979,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:100;n:type:ShaderForge.SFN_Multiply,id:6228,x:31862,y:32853,varname:node_6228,prsc:2|A-5707-RGB,B-979-OUT;n:type:ShaderForge.SFN_Color,id:1110,x:32121,y:32970,ptovrint:False,ptlb:rim light color,ptin:_rimlightcolor,varname:node_1110,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:5631,x:32350,y:33096,varname:node_5631,prsc:2|A-1110-RGB,B-4454-OUT;n:type:ShaderForge.SFN_Tex2d,id:3325,x:32521,y:33202,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_3325,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:3305,x:32521,y:33387,ptovrint:False,ptlb:Metallic Color,ptin:_MetallicColor,varname:node_3305,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:1421,x:32765,y:33321,varname:node_1421,prsc:2|A-3325-RGB,B-3305-RGB;n:type:ShaderForge.SFN_Tex2d,id:7521,x:32569,y:33540,ptovrint:False,ptlb:EmiisionTex2d,ptin:_EmiisionTex2d,varname:node_7521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:9949,x:32380,y:33735,ptovrint:False,ptlb:EmissionColor,ptin:_EmissionColor,varname:node_9949,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:3830,x:32921,y:33577,varname:node_3830,prsc:2|A-7521-RGB,B-3404-OUT;n:type:ShaderForge.SFN_Multiply,id:3404,x:32571,y:33816,varname:node_3404,prsc:2|A-9949-RGB,B-5337-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5337,x:32291,y:34041,ptovrint:False,ptlb:Emission light range,ptin:_Emissionlightrange,varname:node_5337,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:6120,x:32951,y:33394,ptovrint:False,ptlb:Normal map,ptin:_Normalmap,varname:node_6120,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:3416,x:32675,y:33942,ptovrint:False,ptlb:DissvoleRange,ptin:_DissvoleRange,varname:node_3416,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1.3;n:type:ShaderForge.SFN_Tex2d,id:8003,x:32782,y:34106,ptovrint:False,ptlb:DissvoleMap,ptin:_DissvoleMap,varname:node_8003,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Step,id:4905,x:33155,y:34056,varname:node_4905,prsc:2|A-3416-OUT,B-8003-R;n:type:ShaderForge.SFN_Add,id:177,x:33328,y:33931,varname:node_177,prsc:2|A-6596-OUT,B-4905-OUT;n:type:ShaderForge.SFN_Fresnel,id:4454,x:31696,y:33460,varname:node_4454,prsc:2|EXP-6303-OUT;n:type:ShaderForge.SFN_Slider,id:6303,x:31180,y:33424,ptovrint:False,ptlb:rim light strength,ptin:_rimlightstrength,varname:node_6303,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:15,max:15;n:type:ShaderForge.SFN_Add,id:1981,x:32522,y:32918,varname:node_1981,prsc:2|A-9994-OUT,B-5631-OUT;n:type:ShaderForge.SFN_Vector1,id:6596,x:32990,y:33786,varname:node_6596,prsc:2,v1:0;proporder:1246-5707-979-1110-6303-3325-3305-7521-9949-5337-6120-3416-8003;pass:END;sub:END;*/

Shader "GFLand/Monster" {
    Properties {
        _Diffusetexture2d ("Diffuse texture2d", 2D) = "white" {}
        _DiffuseColor ("DiffuseColor", Color) = (1,1,1,1)
        _colorrange ("color range", Range(0, 100)) = 1
        _rimlightcolor ("rim light color", Color) = (0.5,1,1,1)
        _rimlightstrength ("rim light strength", Range(0, 15)) = 15
        _Metallic ("Metallic", 2D) = "white" {}
        _MetallicColor ("Metallic Color", Color) = (0.5,0.5,0.5,1)
        _EmiisionTex2d ("EmiisionTex2d", 2D) = "white" {}
        _EmissionColor ("EmissionColor", Color) = (1,1,1,1)
        _Emissionlightrange ("Emission light range", Float ) = 0
        _Normalmap ("Normal map", 2D) = "bump" {}
        _DissvoleRange ("DissvoleRange", Range(0, 1.3)) = 0
        _DissvoleMap ("DissvoleMap", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Diffusetexture2d; uniform float4 _Diffusetexture2d_ST;
            uniform float4 _DiffuseColor;
            uniform float _colorrange;
            uniform float4 _rimlightcolor;
            uniform sampler2D _Metallic; uniform float4 _Metallic_ST;
            uniform float4 _MetallicColor;
            uniform sampler2D _EmiisionTex2d; uniform float4 _EmiisionTex2d_ST;
            uniform float4 _EmissionColor;
            uniform float _Emissionlightrange;
            uniform sampler2D _Normalmap; uniform float4 _Normalmap_ST;
            uniform float _DissvoleRange;
            uniform sampler2D _DissvoleMap; uniform float4 _DissvoleMap_ST;
            uniform float _rimlightstrength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normalmap_var = UnpackNormal(tex2D(_Normalmap,TRANSFORM_TEX(i.uv0, _Normalmap)));
                float3 normalLocal = _Normalmap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _DissvoleMap_var = tex2D(_DissvoleMap,TRANSFORM_TEX(i.uv0, _DissvoleMap));
                clip((0.0+step(_DissvoleRange,_DissvoleMap_var.r)) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float4 _Metallic_var = tex2D(_Metallic,TRANSFORM_TEX(i.uv0, _Metallic));
                float3 specularColor = (_Metallic_var.rgb*_MetallicColor.rgb);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Diffusetexture2d_var = tex2D(_Diffusetexture2d,TRANSFORM_TEX(i.uv0, _Diffusetexture2d));
                float3 node_9994 = (_Diffusetexture2d_var.rgb*(_DiffuseColor.rgb*_colorrange));
                float3 node_5631 = (_rimlightcolor.rgb*pow(1.0-max(0,dot(normalDirection, viewDirection)),_rimlightstrength));
                float3 diffuseColor = (node_9994+node_5631);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _EmiisionTex2d_var = tex2D(_EmiisionTex2d,TRANSFORM_TEX(i.uv0, _EmiisionTex2d));
                float3 emissive = (_EmiisionTex2d_var.rgb*(_EmissionColor.rgb*_Emissionlightrange));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Diffusetexture2d; uniform float4 _Diffusetexture2d_ST;
            uniform float4 _DiffuseColor;
            uniform float _colorrange;
            uniform float4 _rimlightcolor;
            uniform sampler2D _Metallic; uniform float4 _Metallic_ST;
            uniform float4 _MetallicColor;
            uniform sampler2D _EmiisionTex2d; uniform float4 _EmiisionTex2d_ST;
            uniform float4 _EmissionColor;
            uniform float _Emissionlightrange;
            uniform sampler2D _Normalmap; uniform float4 _Normalmap_ST;
            uniform float _DissvoleRange;
            uniform sampler2D _DissvoleMap; uniform float4 _DissvoleMap_ST;
            uniform float _rimlightstrength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normalmap_var = UnpackNormal(tex2D(_Normalmap,TRANSFORM_TEX(i.uv0, _Normalmap)));
                float3 normalLocal = _Normalmap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _DissvoleMap_var = tex2D(_DissvoleMap,TRANSFORM_TEX(i.uv0, _DissvoleMap));
                clip((0.0+step(_DissvoleRange,_DissvoleMap_var.r)) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float4 _Metallic_var = tex2D(_Metallic,TRANSFORM_TEX(i.uv0, _Metallic));
                float3 specularColor = (_Metallic_var.rgb*_MetallicColor.rgb);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Diffusetexture2d_var = tex2D(_Diffusetexture2d,TRANSFORM_TEX(i.uv0, _Diffusetexture2d));
                float3 node_9994 = (_Diffusetexture2d_var.rgb*(_DiffuseColor.rgb*_colorrange));
                float3 node_5631 = (_rimlightcolor.rgb*pow(1.0-max(0,dot(normalDirection, viewDirection)),_rimlightstrength));
                float3 diffuseColor = (node_9994+node_5631);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float _DissvoleRange;
            uniform sampler2D _DissvoleMap; uniform float4 _DissvoleMap_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _DissvoleMap_var = tex2D(_DissvoleMap,TRANSFORM_TEX(i.uv0, _DissvoleMap));
                clip((0.0+step(_DissvoleRange,_DissvoleMap_var.r)) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
