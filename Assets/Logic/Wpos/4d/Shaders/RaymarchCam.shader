//

Shader "Raymarch/RaymarchCam"
{
    Properties
    {
        _MainTex ("RendrerTexture", 2D) = "white" {}
        _GeometryTex("Texture", 2D) = "white" {}
        _GeometryTex1("Texture1", 2D) = "white" {}
        _GeometryTex2("Texture2", 2D) = "white" {}
        _GeometryTex3("Texture3", 2D) = "white" {}
        _GeometryTex4("Texture4", 2D) = "white" {}
        _GeometryTex5("Texture5", 2D) = "white" {}
        _GeometryTex6("Texture6", 2D) = "white" {}
        _GeometryTex7("Texture7", 2D) = "white" {}
        _GeometryTex8("Texture8", 2D) = "white" {}
        _GeometryTex9("Texture9", 2D) = "white" {}
        _GeometryTex10("Texture10", 2D) = "white" {}
        _GeometryTex11("Texture11", 2D) = "white" {}
        _GeometryTex12("Texture12", 2D) = "white" {}
        _GeometryTex13("Texture13", 2D) = "white" {}
        _GeometryTex14("Texture14", 2D) = "white" {}
        _distance("distance", Range(0,1000)) = 1 
        hue("hue", Range(0,1)) = 1 
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members ray)
//#pragma exclude_renderers d3d11
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            // the distancefuctions are located on another script

            #include "DistanceFunctions.cginc"

            // All the variables feeded through the camera
            
            sampler2D _MainTex;
            sampler2D _GeometryTex;
            sampler2D _GeometryTex1;
            sampler2D _GeometryTex2;
            sampler2D _GeometryTex3;
            sampler2D _GeometryTex4;
            sampler2D _GeometryTex5;
            sampler2D _GeometryTex6;
            sampler2D _GeometryTex7;
            sampler2D _GeometryTex8;
            sampler2D _GeometryTex9;
            sampler2D _GeometryTex10;
            sampler2D _GeometryTex11;
            sampler2D _GeometryTex12;
            sampler2D _GeometryTex13;
            uniform sampler2D _CameraDepthTexture;
            uniform float4x4 _CamFrustrum, _CamToWorld;
            uniform float3 _wRotation;
            uniform float _hxRotation;
            uniform float w;
            uniform float lpx;
            uniform float _maxDistance;
            uniform float _precision;
            uniform float _max_iteration;
            uniform float _maxShadowDistance;
            uniform float _lightIntensity;
            uniform int _nrOfCascades;
            uniform float _shadowIntensity;
            uniform float _shadowSoftness;
            uniform float _aoIntensity;

            uniform float3 _lightDir;
            uniform float3 _player;
            uniform fixed4 _skyColor;
            uniform fixed4 _ChaosColor;
            int _distance;  
            float hue;

            uniform int _useNormal;
            uniform int _useShadow;
            uniform int _useNegativeLight;
            uniform int _useNegative;

            static const float PI = 3.14159265f;

            struct Shape {

                
                float4 position;
                float4 scale;
                float3 rotation;
                float3 rotationW;
                float3 colour;
                int shapeType;
                int operation;
                float blendStrength;
                int numChildren;
                int numTexture;
            }; 
            
           
            StructuredBuffer<Shape> shapes;
            int numShapes;


            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 ray : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                half index = v.vertex.z;
                v.vertex.z = 1;

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv.xy;

                o.ray = _CamFrustrum[(int)index].xyz;

                o.ray /= abs(o.ray.z);

                o.ray = mul(_CamToWorld, o.ray);

                return o;
            }

            // the distancefunction for the fractals
            float GetShapeDistance(Shape shape, float4 p4D) {

                p4D -= shape.position;
                
                p4D.xz = mul(p4D.xz, float2x2(cos(shape.rotation.y), sin(shape.rotation.y), -sin(shape.rotation.y), cos(shape.rotation.y)));
                p4D.yz = mul(p4D.yz, float2x2(cos(shape.rotation.x), -sin(shape.rotation.x), sin(shape.rotation.x), cos(shape.rotation.x)));
                p4D.xy = mul(p4D.xy, float2x2(cos(shape.rotation.z), -sin(shape.rotation.z), sin(shape.rotation.z), cos(shape.rotation.z)));

                p4D.xw = mul(p4D.xw, float2x2(cos(shape.rotationW.x), sin(shape.rotationW.x), -sin(shape.rotationW.x), cos(shape.rotationW.x)));
                p4D.zw = mul(p4D.zw, float2x2(cos(shape.rotationW.z), -sin(shape.rotationW.z), sin(shape.rotationW.z), cos(shape.rotationW.z)));
                p4D.yw = mul(p4D.yw, float2x2(cos(shape.rotationW.y), -sin(shape.rotationW.y), sin(shape.rotationW.y), cos(shape.rotationW.y)));

              
                
                
                if (shape.shapeType == 0) {
                    return sdHypersphere(p4D , shape.scale.x);
                }
                else if (shape.shapeType == 1) {
                    return sdHypercube(p4D, shape.scale);
                }
                else if (shape.shapeType == 2) {
                    return sdDuoCylinder(p4D, shape.scale.xy);
                }
                else if (shape.shapeType == 3) {
                    return sdPlane(p4D, shape.scale);
                }
                else if (shape.shapeType == 4) {
                    return sdCone(p4D, shape.scale);
                }
                else if (shape.shapeType == 5) {
                    return sd5Cell(p4D, shape.scale);
                }
                else if (shape.shapeType == 6) {
                    return sd16Cell(p4D, shape.scale);
                }
                else if (shape.shapeType == 7) {
                    return sdVoid();
                }
                else if (shape.shapeType == 8) {
                    return GetDist2(p4D);
                }else if (shape.shapeType == 9) {
                    return GetDist3(p4D,shape.scale);

                }else if (shape.shapeType == 10) {
                    return GetDist4(p4D,shape.scale);

                }else if (shape.shapeType == 11) {
                    return sdVoid();
                }else if (shape.shapeType == 12) {
                    return sdCylinder2((float3)p4D,(float3)shape.scale);
                }else if (shape.shapeType == 13) {
                    return sdVoid();
                }else if (shape.shapeType == 14) {
                    return GetTarelkaLoop(p4D, shape.scale);
                }else if (shape.shapeType == 15) {
                    return sdCubeLine(p4D);
                }

                return _maxDistance;
            }
           
          

            float4 distanceField(float3 p)
            {
                float4 p4D = float4 (p, w);
                if (length(_wRotation) != 0) {
                    p4D.xw = mul(p4D.xw, float2x2(cos(_wRotation.x), -sin(_wRotation.x), sin(_wRotation.x), cos(_wRotation.x)));
                    p4D.yw = mul(p4D.yw, float2x2(cos(_wRotation.y), -sin(_wRotation.y), sin(_wRotation.y), cos(_wRotation.y)));
                    p4D.zw = mul(p4D.zw, float2x2(cos(_wRotation.z), -sin(_wRotation.z), sin(_wRotation.z), cos(_wRotation.z)));
                }
                if(_hxRotation != 0)
                {
                     p4D.x = lpx;
                }

                float globalDst = _maxDistance;
                float3 globalColour = 1;

                for (int i = 0; i < numShapes; i++) {
                    Shape shape = shapes[i];
                    int numChildren = shape.numChildren;

                    float localDst = GetShapeDistance(shape, p4D);
                    float3 localColour = shape.colour;


                    for (int j = 0; j < numChildren; j++) {
                        Shape childShape = shapes[i + j + 1];
                        float childDst = GetShapeDistance(childShape, p4D);

                        float4 combined = Combine(localDst, childDst, localColour, childShape.colour, childShape.operation, childShape.blendStrength);
                        localColour = combined.xyz;
                        localDst = combined.w;
                    }
                    i += numChildren; // skip over children in outer loop

                    float4 globalCombined = Combine(globalDst, localDst, globalColour, localColour, shape.operation, shape.blendStrength);
                    globalColour = globalCombined.xyz;
                    globalDst = globalCombined.w;
                }

                return float4(globalDst, globalColour);

            }
            float2 distanceField2(float3 p)
            {
                float4 p4D = float4 (p, w);
                if (length(_wRotation) != 0) {
                    p4D.xw = mul(p4D.xw, float2x2(cos(_wRotation.x), -sin(_wRotation.x), sin(_wRotation.x), cos(_wRotation.x)));
                    p4D.yw = mul(p4D.yw, float2x2(cos(_wRotation.y), -sin(_wRotation.y), sin(_wRotation.y), cos(_wRotation.y)));
                    p4D.zw = mul(p4D.zw, float2x2(cos(_wRotation.z), -sin(_wRotation.z), sin(_wRotation.z), cos(_wRotation.z)));
                }


                float globalDst = _maxDistance;
                float3 globalColour = 1;

                for (int i = 0; i < numShapes; i++) {
                    Shape shape = shapes[i];
                    int numChildren = shape.numChildren;

                    float localDst = GetShapeDistance(shape, p4D);
                    int localColour = shape.numTexture;


                    for (int j = 0; j < numChildren; j++) {
                        Shape childShape = shapes[i + j + 1];
                        float childDst = GetShapeDistance(childShape, p4D);

                        float4 combined = Combine(localDst, childDst, localColour, childShape.colour, childShape.operation, childShape.blendStrength);
                        localColour = shape.numTexture;
                        localDst = combined.w;
                    }
                    i += numChildren; // skip over children in outer loop

                    float4 globalCombined = Combine(globalDst, localDst, globalColour, localColour, shape.operation, shape.blendStrength);
                    globalColour = globalCombined.xyz;
                    globalDst = globalCombined.w;
                }

                return float4(globalDst, globalColour);

            }

            void Unity_Hue_Radians_float(float3 In, float Offset, out float3 Out)
{
    float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
    float4 P = lerp(float4(In.bg, K.wz), float4(In.gb, K.xy), step(In.b, In.g));
    float4 Q = lerp(float4(P.xyw, In.r), float4(In.r, P.yzx), step(P.x, In.r));
    float D = Q.x - min(Q.w, Q.y);
    float E = 1e-10;
    float3 hsv = float3(abs(Q.z + (Q.w - Q.y)/(6.0 * D + E)), D / (Q.x + E), Q.x);

    float hue = hsv.x + Offset;
    hsv.x = (hue < 0)
            ? hue + 1
            : (hue > 1)
                ? hue - 1
                : hue;

    // HSV to RGB
    float4 K2 = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
    float3 P2 = abs(frac(hsv.xxx + K2.xyz) * 6.0 - K2.www);
    Out = hsv.z * lerp(K2.xxx, saturate(P2 - K2.xxx), hsv.y);
}
            // returns the normal in a single point of the fractal

            float3 getNormal(float3 p)
            {

              float d = distanceField(p).x;
                const float2 e = float2(.01, 0);
              float3 n = d - float3(distanceField(p - e.xyy).x,distanceField(p - e.yxy).x,distanceField(p - e.yyx).x);
              return normalize(n);

            }

            // calcutates hard shadows in a point

            float hardShadowCalc( in float3 ro, in float3 rd, float mint, float maxt)
            {
                float res = 0.5;
                for( float t=mint; t<maxt; )
                {
                    float h = min(distanceField(ro + rd*t).x, sdVerticalCapsule(ro + rd*t - _player, 1, 0.5));
                    if( h<0.001 )
                        return 0.0;
                    t += h;
                }
                return res;
            }

            // calcutates soft shadows in a point

            float softShadowCalc( in float3 ro, in float3 rd, float mint, float maxt, float k )
            {
                float res = 1.0;
                float ph = 1e20;
                for( float t=mint; t<maxt; )
                {
                    float h = distanceField(ro + rd*t).x;
                    if( h<0.001 )
                        return 0.0;
                    float y = h*h/(2.0*ph);
                    float d = sqrt(h*h-y*y);
                    res = min( res, k*d/max(0.0,t-y) );
                    ph = h;
                    t += h;
                }
                return res;
            }
            
              float3  poss;
              // the actual raymarcher
            float4 Pos(float3 ro, float3 rd, float depth)
            {


                float t = 0; //distance traveled

              float3  pos;
              int textureIndex;
                for (int i = 0; i < _max_iteration/2; i++)
                {
                    //sends out ray from the camera
                    float3 p = ro + rd * t;



                    // check if to far
                    if(t > _maxDistance || t >= depth)
                    {

                        //environment
                        break;

                    }
                    
                    float2 d = distanceField2(p); 
                    if ((d.x) < _precision) //hit
                    {
                    pos =p;
                    textureIndex = d.y;
                    }
                    t += d.x;
                }
                return float4( pos, textureIndex);
            }
            // the actual raymarcher
            fixed4 raymarching(float3 ro, float3 rd, float depth, float3 col)
            {

                fixed4 result = fixed4(0,0,0,0.5); // default

                float t = 0; //distance traveled


                for (int i = 0; i < _max_iteration; i++)
                {
                    //sends out ray from the camera
                    float3 p = ro + rd * t;



                    // check if to far
                    if(t > _maxDistance || t >= depth)
                    {

                        //environment
                        result = fixed4(rd,0);
                        break;

                    }

                    //return distance to fractal
                    float4 d = distanceField(p);

                    

                    if ((d.x) < _precision) //hit
                    {
                        poss = p;
                        float3 colorDepth;
                        float light;
                        float shadow;
                        //shading

                        float3 color = d.yzw;
                         if(color.x+color.y+color.z <= 0.01)
               {
                   color = col;
               }
               
            // color.xyz += tex2D(_GeometryTex, float2(p.x-p.z,p.z-p.y));

                        if(_useNormal == 1){
                            float3 n = getNormal(p);
                            light = dot(-_lightDir, n); //lambertian shading
                            if(_nrOfCascades > 0){
                                light = floor(light * _nrOfCascades + 1)/(float)(_nrOfCascades);
                            }
                           
                            light = light * (1 - _lightIntensity) + _lightIntensity;
                        }
                        else  light = 1;

                     if(_useShadow == 1){
                          shadow = (hardShadowCalc(p, -_lightDir, 0.1, _maxShadowDistance) * (1 - _shadowIntensity) + _shadowIntensity); // soft shadows

                     }
                     else if(_useShadow == 2){
                         shadow = (softShadowCalc(p, -_lightDir, 0.1, _maxShadowDistance, _shadowSoftness) * (1 - _shadowIntensity) + _shadowIntensity); // soft shadows
                     }
                    // shadow = 1;

                        float ao = (1 - 2 * i/float(_max_iteration)) * (1 - _aoIntensity) + _aoIntensity; // ambient occlusion

                        float3 colorLight = float3 (color * light * shadow * ao); // multiplying all values between 0 and 1 to return final color

                        colorDepth = float3 (colorLight*(_maxDistance-t)/(_maxDistance) + _skyColor.rgb*(t)/(_maxDistance)); // multiplying with distance

                        //colorDepth = pow( colorDepth, (1.0/2.2) );
                        result = fixed4(colorDepth ,1);
                        break;

                    }

                    t += d.x;


                }

                return result;
            }
            // the fragment shader
            fixed4 frag (v2f i) : SV_Target
            {
               float2 magicuv = float2((int)(i.uv.x*200),(int)(i.uv.y*200))/200;
               float3 magicRay = float3((int)(i.ray.x*64),(int)(i.ray.y*64),(int)(i.ray.z*64))/64;
               
               float depth = LinearEyeDepth(tex2D(_CameraDepthTexture, i.uv).r);
               depth *= length(i.ray * _distance);

               fixed3 col = tex2D(_MainTex, i.uv);

               float3 rayDirection = normalize(i.ray.xyz);
               float3 rayOrigin = _WorldSpaceCameraPos;
               fixed4 result;
              float4 pos = Pos(rayOrigin, rayDirection, depth);
                result = raymarching(rayOrigin, rayDirection, depth,col);
                fixed4 subresult;
                if (pos.x + pos.y + pos.z != 0)
                {


                    if (pos.w == 0)
                    {
                        subresult = tex2D(_GeometryTex, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    }
                    if (pos.w == 1)
                    {
                        subresult = tex2D(_GeometryTex1, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    }                  
                    if (pos.w == 2)
                    {
                        subresult = tex2D(_GeometryTex2, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    }                 
                    if (pos.w == 3)
                    {
                        subresult = tex2D(_GeometryTex3, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    }                 
                    if (pos.w == 4)
                    {
                        subresult = tex2D(_GeometryTex4, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    }                  
                    if (pos.w == 5)
                    {
                        subresult = tex2D(_GeometryTex5, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    }                
                    if (pos.w == 6)
                    {
                        subresult = tex2D(_GeometryTex6, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    }                 
                    if (pos.w == 7)
                    {
                        subresult = tex2D(_GeometryTex7, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    }               
                    if (pos.w == 8)
                    {
                        subresult = tex2D(_GeometryTex8, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    }                  
                    if (pos.w == 9)
                    {
                        subresult = tex2D(_GeometryTex9, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    }                
                    if (pos.w == 10)
                    {
                        subresult = tex2D(_GeometryTex10, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    }                
                    if (pos.w == 11)
                    {
                        subresult = tex2D(_GeometryTex11, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    }                
                    if (pos.w == 12)
                    {
                        subresult = tex2D(_GeometryTex12, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    }                 
                    if (pos.w == 13)
                    {
                        subresult = tex2D(_GeometryTex13, float2(pos.x - pos.z, pos.z - pos.y)) * result.xyzw;


                    } 
                   
                }
                else
                {
                    subresult = result.xyzw;
                }
                float3 col2;
                Unity_Hue_Radians_float(float3(col * (1.0 - result.w) + subresult.xyz * result.w),hue,col2);
                if(_ChaosColor.a == 0)
                {
                _ChaosColor = float4(1,1,1,1);
                }
                if(_useNegativeLight)
                { 
                    float light = col2.xyz;
                   light *= -2;
                  // light +=1;
                 
               //  col2.rgb += light+0.5f;
                 if( light<-0.5)
                 {
                       col2.rgb += light+0.5f;
                 }
                }if(_useNegative)
                { 
                    col2.xyz;
                    col2.xyz *= -1;
                    col2.xyz +=1;
                 
             
                }
                col2 *= _ChaosColor;
               return  fixed4( col2,1);

            }
            ENDCG
        }
    }
}
