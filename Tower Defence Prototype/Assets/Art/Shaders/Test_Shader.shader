Shader "Custom/FluffyCasualMobileShader"
{
    Properties
    {
        _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        _MainTex("Main Texture", 2D) = "white" { }
        _LightDirection("Light Direction", Vector) = (0.577, 0.577, 0.577, 0)
        _ShadowColor("Shadow Color", Color) = (0.1, 0.1, 0.1, 1)
        _HighlightColor("Highlight Color", Color) = (1, 1, 1, 1)
        _ShadowAmount("Shadow Intensity", Range(0, 1)) = 0.5
        _HighlightAmount("Highlight Intensity", Range(0, 1)) = 0.5
        _Saturation("Saturation", Range(0, 2)) = 1.0
    }

    SubShader
    {
        Tags { "Queue" = "Geometry" }

        Pass
        {
            Name "BASEPASS"
            ZWrite On
            ZTest LEqual

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            // Shader properties
            sampler2D _MainTex;
            float4 _BaseColor;
            float4 _ShadowColor;
            float4 _HighlightColor;
            float3 _LightDirection;
            float _ShadowAmount;
            float _HighlightAmount;
            float _Saturation;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.normal = v.normal;
                return o;
            }

            // Function to adjust the saturation of a color
            float4 AdjustSaturation(float4 color, float saturation)
            {
                // Convert color to grayscale (luminance)
                float luminance = dot(color.rgb, float3(0.3, 0.59, 0.11));

                // Mix the grayscale color with the original color based on the saturation value
                return float4(lerp(float3(luminance, luminance, luminance), color.rgb, saturation), color.a);
            }

            float4 frag(v2f i) : SV_Target
            {
                // Get the texture color and apply the base color
                float4 texColor = tex2D(_MainTex, i.uv) * _BaseColor;

                // Adjust the saturation
                texColor = AdjustSaturation(texColor, _Saturation);

                // Calculate the diffuse lighting based on light direction
                float diff = max(dot(normalize(i.normal), normalize(_LightDirection)), 0.0);

                // Apply shadow and highlight effects, scaled by their respective intensity values
                float4 shadow = _ShadowColor * (1.0 - diff) * _ShadowAmount;
                float4 highlight = _HighlightColor * diff * _HighlightAmount;

                // Combine shadow, highlight, and base texture color
                return texColor + shadow + highlight;
            }

            ENDCG
        }
    }

    Fallback "Diffuse"
}
