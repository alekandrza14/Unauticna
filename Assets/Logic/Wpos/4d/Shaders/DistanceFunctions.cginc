﻿// Sphere
float fmod2(float a, float b)
{
     float c = frac(abs(a / b)) * abs(b);
     
     return c;

}
// s: radius
float sdSphere(float3 p, float s)
{
	return length(p) - s;
}

// Box
// b: size of box in x/y/z
float sdBox(float3 p, float3 b)
{
	float3 d = abs(p) - b;
	return min(max(d.x, max(d.y, d.z)), 0.0) + length(max(d, 0.0));
}
float sdVoid()
{
	
	return 8000;
}
  float Sphere(float4 p, float3 c, float r)
{
    return length(p - c) - r;
}
float GetDist2(float4 p) 
{
     p.y += 0.5f;
   //  p.x+=100000;
   //  p.y-=100000;
   //  p.z-=100000;
   //  p.w-=100000;
     float c = 14.5f;
        
   
     p.x = fmod2(p.x+0.5f*c,c)-0.5f*c;
     p.y = fmod2(p.y+0.5f*c,c)-0.5f*c;
       
     p.z += 0.5f;
         
     p.z = fmod2(p.z+0.5f*c,c)-0.5f*c;
     p.w = fmod2(p.w+0.5f*c,c)-0.5f*c;

    
    return max(-(length(p)- 12),-10000);
       
}
float sdCubeLine(float4 p) 
{
    
  
     float c = 14.5f;
        
   
     p.x = fmod2(p.x+0.5f*c,c)-0.5f*c;
     p.y = fmod2(p.y+0.5f*c,c)-0.5f*c;
       
     
         
     p.z = fmod2(p.z+0.5f*c,c)-0.5f*c;
     float4 d2 = abs(p);
     p.w = fmod2(p.w+0.5f*c,c)-0.5f*c;
     float4 d = abs(p);
      d -= 1;
      d.x -= 5;
      d.z -= 5;
      d.w -= 5;
	
    return max(length(max(d, 0)) + min(max(d.x, max(d.y, max(d.z, d.w))), 0),d2.w-14.5f*1.5);
       
}

float sdCylinder2( float3 p, float3 c )
{
  return length(p.xz-c.xy)-c.z;
}

float GetDist3(float4 pos,float4 b) 
{
    float4 p = pos;
	p = p/  b;
    // p.x+=100000;
   //  p.y-=100000;
   //  p.z-=100000;
   //  p.w-=100000;
     float4 c = float4(14.5f,14.5f, 14.5f, 14.5f)/b;
   
     p.x = fmod2(p.x + 0.5f * c.x, c.x) - 0.5f * c.x;
     p.y = fmod2(p.y + 0.5f * c.y, c.y) - 0.5f * c.y;


     p.z = fmod2(p.z + 0.5f * c.z, c.z) - 0.5f * c.z;
     p.w = fmod2(p.w + 0.5f * c.w, c.w) - 0.5f * c.w;

    
    return (length(p)- 1.0f);
       
} float GetDist4(float4 pos, float4 b)
{
    float4 p = pos;
    p = p / b;
    // p.x+=100000;
   //  p.y-=100000;
   //  p.z-=100000;
   //  p.w-=100000;
    float4 c = float4(14.5f, 14.5f, 14.5f, 14.5f) / b;

    p.x = fmod2(p.x + 0.5f * c.x, c.x) - 0.5f * c.x;
    p.y = fmod2(p.y + 0.5f * c.y, c.y) - 0.5f * c.y;


    p.z = fmod2(p.z + 0.5f * c.z, c.z) - 0.5f * c.z;
    p.w = fmod2(p.w + 0.5f * c.w, c.w) - 0.5f * c.w;


    return (length(p) - 1.0f) * b;

} 
float GetTarelkaLoop(float4 pos, float4 b)
{
    float4 p = pos;
    p = p / b;
    // p.x+=100000;
   //  p.y-=100000;
   //  p.z-=100000;
   //  p.w-=100000;
    float4 c = float4(14.5f, 14.5f, 14.5f, 14.5f) / b;

    p.x = fmod2(p.x + 0.5f * c.x, c.x) - 0.5f * c.x;
    p.y = fmod2(p.y + 0.5f * c.y, c.y) - 0.5f * c.y;


    p.z = fmod2(p.z + 0.5f * c.z, c.z) - 0.5f * c.z;
    p.w = fmod2(p.w + 0.5f * c.w, c.w) - 0.5f * c.w;


    return max( - min(-(length(p) - 1.0f), (length(p) - 0.7f)),-p.y) * 3;

}
float GetDist(float4 pos) 
{
    if (length(pos) > 982.3) 
    {
        return Sphere(pos, 0, 982.3);
    }
    pos = pos/ 471.2;
    float4 z = pos;
    float dr = 2.0;
    float r = 0.0;
    for (int i = 0; i < 9; ++i) 
    {
        // Convert to polar coordinates
        r = length(z);
        if (r > 2)
            break;
        float theta = acos(z.y/r);
        float phi = atan2(z.z,z.x);
        dr =  pow(r, 8 - 0.5) * 8 * dr + 0.5;
        
        // Scale and rotate the point
        float zr = pow(r, 8);
        theta = theta * 8;
        phi = phi * 8;
        
        // Convert back to cartesian coordinates
        z = zr * float4(sin(theta)*cos(phi), cos(theta), sin(phi)*sin(theta), sin(phi)*sin(theta));
        
        z += pos;
    }
        
    float d = 471.2 * 0.5 * log(r) * r / dr;
    return d;
}
    


// 4D HyperCube
float sdHypercube (float4 p, float4 b)
{
    float4 d = abs(p) - b;
	return min(max(d.x,max(d.y,max(d.z,d.w))),0.0) + length(max(d,0.0));
}

float sdHypersphere (float4 p, float s)
{
    return length(p) - s;
}

// http://eusebeia.dyndns.org/4d/duocylinder
float sdDuoCylinder( float4 p, float2 r1r2) {
  float2 d = abs(float2(length(p.xz),length(p.yw))) - r1r2;
  return min(max(d.x,d.y),0.) + length(max(d,0.));
}
float sdVerticalCapsule( float3 p, float h, float r )
{
  p.y -= clamp( p.y, 0.0, h );
  return length( p ) - r;
}
float sdCone(float4 p, float4 h)
{
    return max(length(p.xzw) - h.x, abs(p.y) - h.y) - h.x * p.y;
}
float sd16Cell(float4 p, float s)
{
    p = abs(p);
    return (p.x + p.y + p.z + p.w - s)* 0.57735027f;
}
float sd5Cell(float4 p, float4 a)
{
  return (max(max(max( abs(p.x+p.y+(p.w/a.w))-p.z,abs(p.x-p.y+(p.w/a.w))+p.z), abs(p.x - p.y - (p.w/a.w))+p.z),abs(p.x+p.y-(p.w/a.w))-p.z)-a.x)/sqrt(3.);
}

// plane
float sdPlane(float4 p, float4 s)
{

    float plane = dot(p, normalize(float4(0, 1, 0, 0))) - (sin(p.x * s.x + p.w) + sin(p.z * s.z) + sin((p.x * 0.34 + p.z * 0.21)*s.w))/s.y;
    return plane;

}




// Tetrahedron
float sdTetrahedron(float3 p, float a, float4x4 rotate45)
{
    
  //p = mul(rotate45, float4(p,1)).xyz;
  return (max( abs(p.x+p.y)-p.z,abs(p.x-p.y)+p.z)-a)/sqrt(3.);
  
    
}

// Octahedron
float sdOctahedron(float3 p, float a, float4x4 rotate45)
{
  p = mul(rotate45, float4(p,1)).xyz;
  return (abs(p.x)+abs(p.y)+abs(p.z)-a)/3;
}

// BOOLEAN OPERATORS //

float4 Blend( float a, float b, float3 colA, float3 colB, float k )
{
    float h = clamp( 0.5+0.5*(b-a)/k, 0.0, 1.0 );
    float blendDst = lerp( b, a, h ) - k*h*(1.0-h);
    float3 blendCol = lerp(colB,colA,h);
    return float4(blendCol, blendDst);
}

float4 Combine(float dstA, float dstB, float3 colA, float3 colB, int operation, float k) {
    float dst = dstA;
    float3 colour = colA;

    //union
    if (operation == 0) {
        float h = clamp( 0.5 + 0.5*(dstA-dstB)/k, 0.0, 1.0 );
        colour = lerp(colA, colB, h);
        dst = lerp( dstA,dstB , h ) - k*h*(1.0-h);
    } 
    // Blend
    else if (operation == 1) {
        float4 blend = Blend(dstA,dstB,colA,colB, k);
        dst = blend.w;
        colour = blend.xyz;
    }
    // substract
    else if (operation == 2) {
        // max(a,-b)
        float h = clamp( 0.5 - 0.5*(dstB+dstA)/k, 0.0, 1.0 );
        colour = lerp(colA, colB, h);
        dst = lerp( dstA,-dstB , h ) + k*h*(1.0-h);
    }
    // intersect
    else if (operation == 3) {
        // max(a,b)
        float h = clamp( 0.5 - 0.5*(dstA-dstB)/k, 0.0, 1.0 );
        colour = lerp(colA, colB, h);
        dst = lerp( dstA,dstB , h ) + k*h*(1.0-h);
    }

    return float4(colour,dst);
}


//transform object

float3 sdTransform (float3 p, float4x4 _globalTransform)
{
    return mul(_globalTransform, float4(p,1)).xyz;
}









