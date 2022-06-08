Shader "Sprites/Custom/SpriteShadow"
{
        Properties
        {
            [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
            _Color("Tint", Color) = (1,1,1,1)
            [MaterialToggle] PixelSnap("Pixel snap", Float) = 0
            [HideInInspector] _RendererColor("RendererColor", Color) = (1,1,1,1)
            [HideInInspector] _Flip("Flip", Vector) = (1,1,1,1)
            [PerRendererData] _AlphaTex("External Alpha", 2D) = "white" {}
            [PerRendererData] _EnableExternalAlpha("Enable External Alpha", Float) = 0
            _Cutoff("Alpha Cutoff", Range(0,1)) = 0.5
        }

        SubShader
        {
            Tags
            {
                "Queue" = "Transparent"
                "IgnoreProjector" = "True"
                "RenderType" = "Transparent"
                "PreviewType" = "Plane"
                "CanUseSpriteAtlas" = "True"
                "DisableBatching" = "True"
            }

            Cull Off
            Lighting Off
            ZWrite Off
            Blend One OneMinusSrcAlpha

            CGPROGRAM
            #pragma surface surf Lambert vertex:vert fragment:frag alphatest:_Cutoff addshadow nofog nolightmap nodynlightmap keepalpha noinstancing
            #pragma multi_compile_local _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #include "UnitySprites.cginc"

                struct Input
                {
                    float2 uv_MainTex;
                    fixed4 color;
                };

                void vert(inout appdata_full v, out Input o)
                {
                    ////Bliboard Render
                    //UNITY_INITIALIZE_OUTPUT(Input, o);
                    //
                    //// get the camera basis vectors
                    //float3 forward = float3(0, 0, 1); //-normalize(UNITY_MATRIX_V._m20_m21_m22);
                    //float3 up = float3(0, 1, 0);//normalize(UNITY_MATRIX_V._m10_m11_m12);
                    //float3 right = normalize(UNITY_MATRIX_V._m00_m01_m02); //float3(1, 0, 0); 
                    //
                    //// rotate to face camera
                    //float4x4 rotationMatrix = float4x4(right, 0,
                    //    up, 0,
                    //    forward, 0,
                    //    0, 0, 0, 1);
                    //
                    ////float offset = _Object2World._m22 / 2;
                    //float offset = 0;
                    //v.vertex = mul(v.vertex + float4(0, offset, 0, 0), rotationMatrix) + float4(0, -offset, 0, 0);
                    //v.normal = mul(v.normal, rotationMatrix);

                    //Shadow Render
                    v.vertex = UnityFlipSprite(v.vertex, _Flip);

                    #if defined(PIXELSNAP_ON)
                        v.vertex = UnityPixelSnap(v.vertex);
                    #endif

                    UNITY_INITIALIZE_OUTPUT(Input, o);

                    o.color = v.color * _Color * _RendererColor;
                }

                void surf(Input IN, inout SurfaceOutput o)
                {
                    fixed4 c = SampleSpriteTexture(IN.uv_MainTex) * IN.color;
                    o.Albedo = c.rgb * c.a;
                    o.Alpha = c.a;
                }

            ENDCG
            }

        Fallback "Transparent/VertexLit"
}