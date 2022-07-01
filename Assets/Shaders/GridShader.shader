Shader "Terrain/Grid"
{
   Properties
   {
      _MainColor("Main Color", Color) = (0.5, 1.0, 1.0)
      _MaskTexture("Texture", 2D) = "white" {}
      _Amount ("Normal Fade", Range(1.7, 25)) = 5.0
      
      [Header(Grid)]
      _Scale("Scale", Float) = 1.0
      _Thickness("Lines Thickness", Range(0.01, 0.5)) = 0.005
   }
   SubShader
   {
      Tags { "Queue" = "Transparent" "RenderType" = "Opaque" "ForceNoShadowCasting" = "False" "SHADOWSUPPORT"="true"}
      LOD 100

      ZWrite On // We need to write in depth to avoid tearing issues
      Blend SrcAlpha OneMinusSrcAlpha

      Pass
      {
         CGPROGRAM
         #pragma vertex vert
         #pragma fragment frag
         #pragma multi_compile UNITY_SINGLE_PASS_STEREO STEREO_INSTANCING_ON STEREO_MULTIVIEW_ON

         #include "UnityCG.cginc"
         #include "AutoLight.cginc"

         struct appdata
         {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
            float2 uv1 : TEXCOORD1;
            float3 normal : NORMAL;
            float3 worldPos : TEXCOORD2;
            LIGHTING_COORDS(3,4)
            UNITY_VERTEX_INPUT_INSTANCE_ID
         };

         struct v2f
         {
            float2 uv : TEXCOORD0;
            float2 uv1 : TEXCOORD1;
            float3 worldPos : TEXCOORD2;
            float3 worldNormal : TEXCOORD3;
            float4 vertex : SV_POSITION;
           
            UNITY_VERTEX_OUTPUT_STEREO
            
         };

         sampler2D _GridTexture;
         float4 _GridTexture_ST;
			
         sampler2D _MaskTexture;
         float4 _MaskTexture_ST;

         float _Amount;
         float _Scale;
         float _GraduationScale;

         float _Thickness;
         float _SecondaryFadeInSpeed;

         fixed4 _MainColor;
         fixed4 _SecondaryColor;
         fixed4 _BackgroundColor;

         v2f vert (appdata v)
         {
            v2f output;
            UNITY_SETUP_INSTANCE_ID(v);
            UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
            
            output.vertex = UnityObjectToClipPos(v.vertex);

            // Remap UVs from [0:1] to [-0.5:0.5] to make scaling effect start from the center 
            output.uv = v.uv - 0.5f;
            // Scale the whole thing if necessary
            output.uv *= _GraduationScale;
            output.worldPos = mul(unity_ObjectToWorld, v.vertex);
            output.worldPos.x -= _Scale;
            output.worldPos.y -= _Scale;

            output.worldPos += float3(0.5,0.5,0.5);
            output.worldNormal = UnityObjectToWorldNormal(v.normal);
            
            // UVs for mask texture
            output.uv1 = TRANSFORM_TEX(v.uv1, _MaskTexture);
            return output;
         }

         // Remap value from a range to another
         float remap(float value, float from1, float to1, float from2, float to2) {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
         }

         fixed4 frag (v2f i) : SV_Target
         {
            fixed4 maskCol = tex2D(_MaskTexture, i.uv1);
            fixed4 col = maskCol;
				
            // With the ceil value of the log10 of the scale, we obtain the closest measure unit above (eg : 165 -> 3, 0.146 -> 0, 0.001 -> -3)
            // Then, we do 10^(this value) to get the actual value of that unit in meters
            // Finally, we divide the scale by this unit in meters to have our log mapped scale
            // This way, we are sure our logMappedScale is between 0.1 and 1
            float logMappedScale = 1/ (_Scale * 10);
            
            float2 pos;

            pos.x = floor(frac((i.worldPos.x - 0.5 * _Thickness) * logMappedScale) + _Thickness * logMappedScale);
            pos.y = floor(frac((i.worldPos.z - 0.5 * _Thickness) * logMappedScale) + _Thickness * logMappedScale);

            pos.x = floor(frac((i.worldPos.x - 0.5 * _Thickness) * 10.0 * logMappedScale) + _Thickness * 10.0 * logMappedScale);
            pos.y = floor(frac((i.worldPos.z - 0.5 * _Thickness) * 10.0 * logMappedScale) + _Thickness * 10.0 * logMappedScale);

            if (pos.x == 1 || pos.y == 1)
            {
               float amount = saturate(-(_Amount * i.worldNormal.y * -i.worldNormal.y + 1 / _Amount)) * (i.worldNormal.y > 0);;
               col.x += (_MainColor.x - 0.3) * amount;
               col.y += (_MainColor.y - 0.3) * amount;
               col.z += (_MainColor.z - 0.3) * amount;
            }
            
            // Apply mask multiplying by its alpha
            col.a *= maskCol.a;
            return col;
         }

         ENDCG
      }
   }
   FallBack "Diffuse"
}