﻿#version 330
 
// shader input
in vec2 uv;						// interpolated texture coordinates
in vec4 normal;					// interpolated normal
in vec4 vpos;
in vec4 cpos;
uniform vec4 lpos1;
uniform vec4 lcol1;
uniform float lint1;
uniform vec4 lpos2;
uniform vec4 lcol2;
uniform float lint2;
uniform sampler2D pixels;		// texture sampler



// shader output
out vec4 outputColor;

// fragment shader
void main()
{
	vec4 inval1 = normalize(lpos1 - vpos);
	vec4 inval2 = normalize(lpos2 - vpos);
	vec4 reflec1 = normalize(inval1 - (2*(dot(inval1,normal)*normal)));
	vec4 reflec2 = normalize(inval1 - (2*(dot(inval2,normal)*normal)));
	float t = max(0,dot(reflec1,normalize( cpos-vpos)));
    outputColor = texture( pixels, uv )* (0.2 + texture( pixels, uv) * dot(normalize(normal),inval1)* lcol1*4 + (0.2 * t*t*t*t * lint1));
}

//formula:
// output = ambient color + absorption due to material color(kleur) * (normaalvector * lightinval1vector) * lichtkleur + C_spec *(viewvector * reflectvector)^S * Lspec
// Lspec = lightsterkte
// Cspec = reflectiviteit van het materiaal.
//S zijnde een constante die er mooi uit ziet.