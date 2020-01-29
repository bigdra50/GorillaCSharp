// ShaderToySample
vec3 rect(vec2 bl, vec2 tr, vec2 st){
   float d = .02;
   vec2 blInv = step(bl-d, st);
   vec2 trInv = step(tr-d, 1.-st);
   vec3 r2 = vec3(blInv.x * trInv.x * blInv.y * trInv.y);
   r2 = 1. - r2;
   // bottom - left
   bl = step(bl, st);

   // top - right
   tr = step(tr, 1.-st);

   vec3 r1 = vec3(bl.x * tr.x * bl.y * tr.y);
   return r1 + r2;
}

void mainImage( out vec4 fragColor, in vec2 fragCoord )
{

    vec2 uv = fragCoord/iResolution.xy;
    vec4 col;
    col.rgb = vec3(248./256., 241./256., 225./256.);
    float d = .02;

                
    vec3 hLine1 = rect(vec2(.0, .68), vec2(.0, .18), uv);
    vec3 hLine2 = rect(vec2(.25, .08), vec2(.0, .0), uv);
    vec3 vLine1 = rect(vec2(.25, .0), vec2(.25, .0), uv);
    vec3 vLine2 = rect(vec2(.98, .0), vec2(.0, .0), uv);
    vec3 vLine3 = rect(vec2(.08, .68), vec2(.0, .0), uv);

    col.rgb *= hLine1 * hLine2 * vLine1 * vLine2 * vLine3;

    if(uv.x <= .25 && uv.y >= .68){
       col.gb = vec2(0.);
    }
    if(uv.x >= .98 && uv.y >= .68){
       col.b = 0.;
    }
    if(uv.x >= .75 && uv.y <= .08){
       col.rg = vec2(0.);
    }

    fragColor = col;
}