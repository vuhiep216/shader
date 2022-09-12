Shader "Unlit/Grass"
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
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color: COLOR;
            };

            struct grass
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color: COLOR;
            };

            float3 _CarvePosition;
			float2 _CarveRadius;

            grass vert (appdata v)
            {
                grass o;
                float t = _CosTime.w * 0.5 + 0.5;
                float x= v.vertex.x*t+v.uv.x*(1-t);
                float z= v.vertex.z*t+v.uv.y*(1-t);
                
                float4 newPos=float4(x,v.vertex.y,z,1.0);
                o.vertex = UnityObjectToClipPos(newPos);
                o.color=v.color;
                return o;
            }

            fixed4 frag (grass i) : SV_Target
            {
                fixed4 col = i.color;
                return col;
            }
            ENDCG
        }
    }
}
