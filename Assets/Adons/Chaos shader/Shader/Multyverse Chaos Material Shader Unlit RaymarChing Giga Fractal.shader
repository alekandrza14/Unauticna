Shader "Unauticna Multiverse Customs/Low UnLit Shaders/Multyverse Chaos Raymarching-Material Shader/Giga Fractal"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _MainColor("Color", Color) = (1,1,1,1)
        _Wfloattor("Numer Shape", int) = 0
        MAX_STEPS ("MAX_STEPS", int) = 100
        MAX_DIST ("MAX_DIST", int) = 100
        SURF_DIST  ("SURF_DIST", float) = 0.001
         _Iterations ("Iterations", Int) = 3
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }
ZWrite off
            Cull off
        LOD 100

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            int  MAX_STEPS ;
            int  MAX_DIST ;
            float SURF_DIST ;
            #include "UnityCG.cginc"
            
                int _Iterations;
uniform float4 _MainTex_TexelSize;
uniform float4x4 _CameraInvViewMatrix;
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 ro : TEXCOORD1;
                float3 hitPos : TEXCOORD2;
            };

            sampler2D _MainTex; 
            fixed4 _MainColor;
            float4 _MainTex_ST; 
            float _Wfloattor;
            float _Radius;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.ro = mul(unity_WorldToObject, float4( _WorldSpaceCameraPos,1));
                o.hitPos =  v.vertex;
                
                return o;
            }
           float smoothingFunc(float distA, float distB) {
    float k = 3.;
    float h = max(k - abs(distA-distB), 0.)/k;
    return min(distA, distB) - h*h*h*k*1.0/6.0;
}

float sphereReflection(float3 pt, float4 obj) {
    pt.y -= 1.;
    pt.xz = fmod(pt.xz, 2.) - float2(1.,1.0);
    return length(pt) - obj.w;
}

float sphere(float3 pt) {
    float radius = 1.;
    float4 sphere = float4(0, radius, 0, radius);
    //return abs(length(pt - sphere.xyz) - sphere.w); // hollow sphere distance estimator
    //return max(0.0, length(pt - sphere.xyz) - sphere.w); // solid sphere with no interior (has artifacts)
    return length(pt - sphere.xyz) - radius;
}



float infSphere(float3 pt) {
    // defined sphere
    float4 sphere = float4(0, 1, 0, 1);
    float4 sphere2 = float4(-2, 1, 6, 1);
    
    // sphere.w = radius of sphere
    float sphereDist, sphereDist2;
    sphereDist = length(pt - sphere.xyz) - sphere.w;
    //sphereDist2 = length(pt - sphere2.xyz) - sphere2.w;
    
    //sphereDist = abs(length(pt - sphere.xyz) - sphere.w); // hollow sphere distance estimator
    //sphereDist = max(0.0, length(pt - sphere.xyz) - sphere.w); // solid sphere with no interior (has artifacts)
    
    // mirrored version
    sphereDist = sphereReflection(pt, sphere);
    
    // take the closer distance between sphere and plane
    float DE;
    //DE = max(sphereDist, sphereDist2 *(-1.));
    
    //DE = smoothingFunc(sphereDist, sphereDist2);
    
    DE = sphereDist;
    
    return DE;
}

float sdBox(float3 pt, float3 b) {
    float3 box = abs(pt) - b;
    return length(max(box, 0.0)) + min(max(box.x, max(box.y, box.z)), 0.0);
}

matrix< float,4,4> rotationX( in float angle ) {
	return matrix< float,4,4>(	1.0,		0,			0,			0,
			 		0, 	cos(angle),	-sin(angle),		0,
					0, 	sin(angle),	 cos(angle),		0,
					0, 			0,			  0, 		1);
}

matrix< float,4,4> rotationY( in float angle ) {
	return matrix< float,4,4>(	1.0,		0,			0,			0,
			 		0, 	cos(angle),	-sin(angle),		0,
					0, 	sin(angle),	 cos(angle),		0,
					0, 			0,			  0, 		1);
}
 float SDF(float3 pos)
        {
            float3 q = abs(pos) - 0.5;
            return max(-length(pos)+0.6,length(max(q, 0.0)) + min(max(q.x, max(q.y, q.z)), 0.0));
        }
float sierpinskiPyramid(float3 pt) {
    float3 ori = float3(0.0,-0.,0.0);
    float3 a1 = float3(0.5,0.5,0.5)+ori;
	float3 a2 = float3(-0.5,-0.5,0.5)+ori;
	float3 a3 = float3(0.5,-0.5,-0.5)+ori;
	float3 a4 = float3(-0.5,0.5,-0.5)+ori;
    
    float3 c;
    int n = 0;
    float dist, d;
    float scale = 2.;
    while(n < 16) {
        c = a1;
        dist = length(pt - a1);
        d = length(pt - a2);
        if(d < dist) { 
            c = a2;
            dist = d;
        }
        d = length(pt - a3);
        if(d < dist) { 
            c = a3;
            dist = d;
        }
        d = length(pt - a4);
        if(d < dist) { 
            c = a4;
            dist = d;
        }
        pt = scale * pt - c * (scale - 1.0);
        n++;
    }
    
    return length(pt) * pow(scale, float(-n));
}

float sierpinskiPyramidFold(float3 pt) {
    float r;
    float offset = 0.5;
    float scale = 2.;
    pt.y -= 2.5;
    int n = 0;
    while(n < 15) {
        if(pt.x + pt.y < 0.) pt.xy = -pt.yx;
        if(pt.x + pt.z < 0.) pt.xz = -pt.zx;
        if(pt.y + pt.z < 0.) pt.zy = -pt.yz;
        pt = pt * scale - offset*(scale - 1.0);
        n++;
    }
    
    return (length(pt) * pow(scale, -float(n)));
}

float mengerSponge(float3 pt) {
    
    float scale = 0.5;
    float offset = -0.;
    float iterations = _Iterations;

    float dist = sdBox(float3(pt.x, pt.y+offset, pt.z), float3(scale,scale,scale));
    
    float s = 1.5;
    
    float da, db, dc;
    
    for(int i = 0; i < 4; i++) {
        float3 a = fmod(pt * s, 2.0) - 1.0;
        s *= iterations;
        float3 r = abs(1.0 - 3.0*abs(a));
        
        da = min(r.x, r.y);
        db = min(r.y, r.z);
        dc = min(r.z, r.x);
        
        float c = (max(da, max(db, dc)) - 1.) / s;
        if ( c > dist) dist = c;
    }
    
    return dist;
}

float alteredMenger(float3 pt){
    float scale = 0.5;
    float offset = -2.;
    float iterations = 3.;

    float dist = sdBox(float3(pt.x, pt.y+offset, pt.z), float3(scale,scale,scale));
    
    float s = 1.;
    
    float da, db, dc;
    
    for(int i = 0; i < 4; i++) {
        float3 a = fmod(pt * s, 2.0) - 1.0;
        s *= iterations;
        float3 r = abs(1.0 - 3.0*abs(a));
        
      //  r = float3(float4(r, 1.0,0.,0.) * rotationX(20.)).xyz;
        da = max(r.x+1.5, r.y);
      //  r = float3(float4(r, 1.0,0.,0.) * rotationY(80.)).xyz;
        
        da = max(da + r.x-0.5, r.y);
        db = max(r.y, r.z);
        dc = max(r.z+0.5, r.x);
        
        float c = (min(da, min(db, dc)) - 1.) / s;
        if ( c > dist) dist = c;
    }
    
    return dist;
}

matrix< float,4,4> rotationMatrix(float3 axis, float angle) {
    axis = normalize(axis);
    float s = sin(angle);
    float c = cos(angle);
    float oc = 1.0 - c;
    
    return matrix< float,4,4>(oc * axis.x * axis.x + c,           oc * axis.x * axis.y - axis.z * s,  oc * axis.z * axis.x + axis.y * s,  0.0,
                oc * axis.x * axis.y + axis.z * s,  oc * axis.y * axis.y + c,           oc * axis.y * axis.z - axis.x * s,  0.0,
                oc * axis.z * axis.x - axis.y * s,  oc * axis.y * axis.z + axis.x * s,  oc * axis.z * axis.z + c,           0.0,
                0.0,                                0.0,                                0.0,                                1.0);
}

float3 rotatePt(float3 pt, float3 axis, float angle) {
	// matrix< float,4,4> m = rotationMatrix(axis, angle);
	//return (m * float4(pt, 1.0)).xyz;
    return float3(1,1,1);
}

float evolvingFractal(float3 pt) {
    //float3 off = float3(0.7, 0.5, 0.15);
    //float3 off = float3(0.5, 0.85, 1.25);
    float3 off = float3(1.,1.,1.);
    float scale = 2.;
    pt.y -= 2.5;
    int n = 0;

    while(n < 8) {
        //pt = rotatePt(pt, float3(1.), 31.); // snowflake
       // pt = rotatePt(pt, float3(1), cos(10.+iTime*0.1));
        
        pt = abs(pt); // for cube
        
        if(pt.x + pt.y < 0.) pt.xy = -pt.yx;
        if(pt.x + pt.z < 0.) pt.xz = -pt.zx;
        if(pt.y + pt.z < 0.) pt.zy = -pt.yz;
          
      //  pt = rotatePt(pt, float3(0.35,0.2,0.3), -90.+iTime*0.1);
        
        pt.x = pt.x * scale - off.x*(scale - 1.0);
        pt.y = pt.y * scale - off.y*(scale - 1.0);
        pt.z = pt.z * scale - off.z*(scale - 1.0);
        
      //  pt = rotatePt(pt, float3(0.3,0.1,0.25), -70.+iTime*0.1);
        
        n++;
    }
    return (length(pt) * pow(scale, -float(n)));
}

float evolvingFractal2(float3 pt) {
    float3 off = float3(1.25,1.,1.);
    float scale = 2.;
    pt.y -= 2.5;
    int n = 0;

    while(n < 10) {
        //pt = rotatePt(pt, float3(1.), 31.); // snowflake
      //  pt = rotatePt(pt, float3(1.), sin(0.+iTime*0.1));
        
        pt = abs(pt); // for cube
        
        if(pt.x + pt.y < 0.) pt.xy = -pt.yx;
        if(pt.x + pt.z < 0.) pt.xz = -pt.zx;
        if(pt.y + pt.z < 0.) pt.zy = -pt.yz;
          
     //   pt = rotatePt(pt, float3(0.35,0.2,0.3), -90.+iTime*0.1);
        
        pt.x = pt.x * scale - off.x*(scale - 1.0);
        pt.y = pt.y * scale - off.y*(scale - 1.0);
        pt.z = pt.z * scale - off.z*(scale - 1.0);
        
     //   pt = rotatePt(pt, float3(0.3,0.1,0.25), -70.+iTime*0.1);
        
        n++;
    }
    return (length(pt) * pow(scale, -float(n)));
}

// distance from pt to closest object
float GetDist(float3 pt) {
    float DE;
     if(_Wfloattor == 2) DE = SDF(pt);
    //DE = sphere(pt);
    //DE = infSphere(pt);
    //DE = sierpinskiPyramid(pt);
  if(_Wfloattor == 0) DE = sierpinskiPyramidFold((pt-float3(0,-2.5,0)));
   if(_Wfloattor == 1) DE = 
   min(mengerSponge(pt*float3(1,-1,1)),
   min(mengerSponge(pt*float3(-1,-1,1)),
   min(mengerSponge(pt*float3(1,1,-1)),
   min(mengerSponge(pt*float3(-1,1,1)),
   min(mengerSponge(pt*float3(1,1,-1)),
   min(mengerSponge(pt*float3(-1,1,-1)),
   min(mengerSponge(pt*float3(-1,-1,-1)),
   min(mengerSponge(pt),mengerSponge(pt*float3(1,-1,-1))
   )
   )
   )
   )
   )
   )
   )
   );
    //DE = alteredMenger(pt);
    //DE = evolvingFractal(pt);
  // DE = evolvingFractal2(pt);

    // DE for ground plane
    float planeDist = pt.y;
    DE = DE;
    
    return DE;
}
           
            float Raymarch(float3 ro, float3 rd) {
                float dO = 0;
                float ds;
                for (int i = 0; i < MAX_STEPS;i++) {
                    

                            
                    float3 p = (ro + dO * rd);
                
                    ds = GetDist(p);
                    dO += ds;
                    if (ds<SURF_DIST || dO> MAX_DIST) break;
                    
                }
                return dO;
            }
            float3 GetNormal(float3 p) {
                float2 e = float2(1e-2, 0);
                float3 n = GetDist(p) - float3(
                    GetDist(p - e.xyy),
                    GetDist(p - e.yxy),
                    GetDist(p - e.yyx)

                    );
                return normalize(n);
            }
            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv ;
                float3 ro = i.ro;
                float3 rd = normalize(i.hitPos-ro); //normalize(float3(uv.x, uv.y, 1));
                
                float d = Raymarch(ro, rd);
                fixed4 col = 0;
                float3 p = ro + rd * d;
                fixed4 tex = tex2D(_MainTex, float3(p.x+_Wfloattor, p.y+_Wfloattor, 0)+float3(p.z, p.y+_Wfloattor, 0)+float3(p.x+_Wfloattor, p.z+_Wfloattor, 0));
                float m = dot(uv,uv);
                tex *= _MainColor;
                if (d < MAX_DIST) {

                    float3 n = GetNormal(p);
                    col.rgb = n;
                }
                else discard;

            
               

                if (tex.a != 0) {

                   if(dot(col, _WorldSpaceLightPos0.xyz)*2 > 0.1)
                       {
                            col = dot(col, _WorldSpaceLightPos0.xyz)*2;
                       }
                       else
                       {
                            col = 0.1;
                       }
                    col = lerp(col+fixed4(0,0,0,0), tex, 0.6);
                }
                else discard;
                return col*_MainColor;
            }
            ENDCG
        }
    }
}
