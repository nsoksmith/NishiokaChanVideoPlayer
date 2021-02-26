Shader "すみすのやかた/NishiokaChanBlur_Mask"
{
    Properties
    {
        _Mask ("Mask", 2D) = "white" {}
        _Factor ("Factor", Range(0, 50)) = 1.0
        _Black ("Black Level", Range(0, 1)) = 0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }

        GrabPass { }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma fragmentoption ARB_precision_hint_fastest

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv2 : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 uv : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = ComputeGrabScreenPos(o.pos);
                o.uv2 = v.uv2;
                return o;
            }

            sampler2D _Mask;
            sampler2D _GrabTexture;
            float4 _GrabTexture_TexelSize;
            float _Factor;

            half4 frag (v2f i) : SV_Target
            {

                fixed4 MaskTest = tex2D(_Mask, i.uv2);
                if (MaskTest.x <= 0.5){
					discard;
				}

                half4 pixelCol = half4(0, 0, 0, 0);

                #define ADDPIXEL(weight,kernelX) tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(float4(i.uv.x + _GrabTexture_TexelSize.x * kernelX * _Factor, i.uv.y, i.uv.z, i.uv.w))) * weight

                pixelCol += ADDPIXEL(0.05, 4.0);
                pixelCol += ADDPIXEL(0.09, 3.0);
                pixelCol += ADDPIXEL(0.12, 2.0);
                pixelCol += ADDPIXEL(0.15, 1.0);
                pixelCol += ADDPIXEL(0.18, 0.0);
                pixelCol += ADDPIXEL(0.15, -1.0);
                pixelCol += ADDPIXEL(0.12, -2.0);
                pixelCol += ADDPIXEL(0.09, -3.0);
                pixelCol += ADDPIXEL(0.05, -4.0);
                return pixelCol;
            }
            ENDCG
        }

        GrabPass { }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma fragmentoption ARB_precision_hint_fastest

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv2 : TEXCOORD1;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 uv : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = ComputeGrabScreenPos(o.pos);
                o.uv2 = v.uv2;
                return o;
            }

            sampler2D _Mask;
            sampler2D _GrabTexture;
            float4 _GrabTexture_TexelSize;
            float _Factor;
            float _Black;

            fixed4 frag (v2f i) : SV_Target
            {

                float4 MaskTest = tex2D(_Mask, i.uv2);
                if (MaskTest.x <= 0.5){
					discard;
				}

                fixed4 pixelCol = fixed4(0, 0, 0, 0);

                #define ADDPIXEL(weight,kernelY) tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(float4(i.uv.x, i.uv.y + _GrabTexture_TexelSize.y * kernelY * _Factor, i.uv.z, i.uv.w))) * weight

                pixelCol += ADDPIXEL(0.05, 4.0);
                pixelCol += ADDPIXEL(0.09, 3.0);
                pixelCol += ADDPIXEL(0.12, 2.0);
                pixelCol += ADDPIXEL(0.15, 1.0);
                pixelCol += ADDPIXEL(0.18, 0.0);
                pixelCol += ADDPIXEL(0.15, -1.0);
                pixelCol += ADDPIXEL(0.12, -2.0);
                pixelCol += ADDPIXEL(0.09, -3.0);
                pixelCol += ADDPIXEL(0.05, -4.0);
                pixelCol *= 1 - _Black;
                return pixelCol;
            }
            ENDCG
        }
    }
}