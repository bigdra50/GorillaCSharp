Shader "GLSL2ShaderLab/Template"
{
    Properties
    {
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            float mod(float x, float y)
            {
                return x - y * floor(x / y);
            }

            float2 mod(float2 x float2 y)
            {
                return x - y * floor(x / y);
            }

            float3 mod(float3 x, float3 y)
            {
                return x - y * floor(x / y);
            }

            float4 mod(float4 x, float4 y)
            {
                return x - y * floor(x / y);
            }

            fixed4 fragCoord = 1;
            
            // ----- GLSL Code -----

            
            // ---------------------

            fixed4 frag (v2f_img i) : SV_Target
            {

                return fragCoord;
            }
            ENDCG
        }
    }
}
