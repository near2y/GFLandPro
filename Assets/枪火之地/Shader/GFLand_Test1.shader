Shader "GFLand/Test1"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Height("Height", Range(-0.5,0.5)) = 0 
        _EdgeColor("Edge Color",Color) = (0,0,0,0)
        _EdgeWidth("Edge Width",Range(0,1)) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float height : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Height;
            fixed4 _EdgeColor;
            float _EdgeWidth;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                o.height = v.vertex.y;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                clip(_Height - i.height);

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);

                fixed4 c=  _EdgeColor * step(_Height - i.height,_EdgeWidth);

                return col + c;
            }
            ENDCG
        }
    }
}
