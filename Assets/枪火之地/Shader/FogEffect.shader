
Shader "custom/Fog_test" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _FogDensity ("Fog Density", Float) = 1.0
        _FogColor ("Fog Color", Color) = (1, 1, 1, 1)
        _FogStart ("Fog Start", Float) = 0.0
        _FogEnd ("Fog End", Float) = 1.0
    }
    SubShader {
        CGINCLUDE
        #include "UnityCG.cginc"
 
        float4x4 _FrustumCornersRay;
 
        sampler2D _MainTex;
        half4 _MainTex_TexelSize;
        //深度纹理
        sampler2D _CameraDepthTexture;
        half _FogDensity;
        fixed4 _FogColor;
        float _FogStart;
        float _FogEnd;
		float4 _CamPos;
		float _H_floor;
		float _H_top;
        struct v2f {
            float4 pos : SV_POSITION;
           float2 uv : TEXCOORD0;
            float2 uv_depth : TEXCOORD1;
            float4 interpolatedRay : TEXCOORD2;
        };
 
        v2f vert(appdata_img v) {
            v2f o;
            o.pos = UnityObjectToClipPos(v.vertex);
 
         o.uv = v.texcoord;
            o.uv_depth = v.texcoord;
            #if UNITY_UV_STARTS_AT_TOP
            if (_MainTex_TexelSize.y < 0)
                o.uv_depth.y = 1 - o.uv_depth.y;
            #endif
 
            int index = 0;
            if (v.texcoord.x < 0.5 && v.texcoord.y < 0.5) {
                index = 0;
            } else if (v.texcoord.x > 0.5 && v.texcoord.y < 0.5) {
                index = 1;
            } else if (v.texcoord.x > 0.5 && v.texcoord.y > 0.5) {
                index = 2;
            } else {
                index = 3;
            }
            #if UNITY_UV_STARTS_AT_TOP
            if (_MainTex_TexelSize.y < 0)
                index = 3 - index;
            #endif
 
            o.interpolatedRay = _FrustumCornersRay[index];
 
            return o;
        }
 
        fixed4 frag(v2f i) : SV_Target {
			float linearDepth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv_depth));
            float3 worldPos = _WorldSpaceCameraPos + linearDepth * i.interpolatedRay.xyz;
			float _distance = distance(worldPos,_CamPos);
            float fogDensity = (_distance-_FogStart)*0.3 / (_FogEnd - _FogStart); //越远越浓
			fogDensity *=(_H_top - worldPos.y) / (_H_top - _H_floor);//离地面越高越稀薄
            fogDensity = saturate(fogDensity * _FogDensity) ;
			fixed4 finalColor= tex2D(_MainTex, i.uv);
           finalColor.rgb = lerp(finalColor.rgb, _FogColor.rgb, fogDensity*0.3);
            return finalColor ;
        }
 
        ENDCG
 
        Pass {              
            CGPROGRAM  
            #pragma vertex vert  
            #pragma fragment frag  
 
            ENDCG
        }
    } 
    FallBack Off
}