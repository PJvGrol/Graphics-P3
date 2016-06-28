#version 330
 
// shader input
in vec2 uv;						// interpolated texture coordinates
in vec4 normal;					// interpolated normal
in vec4 vpos;
in vec4 cpos;
uniform vec4 lpos;
uniform vec4 lcol;
uniform float lint;
uniform sampler2D pixels;		// texture sampler



// shader output
out vec4 outputColor;

// fragment shader
void main()
{
	vec4 inval = normalize(lpos - vpos);
	vec4 reflec = normalize(inval - (2*(dot(inval,normal)*normal)));
	float t = max(0,dot(reflec,normalize( cpos-vpos)));
    outputColor = texture( pixels, uv )* (0.2 + texture( pixels, uv) * dot(normalize(normal),inval)* lcol*4 + (0.2 * t*t*t*t * lint));
}

//formula:
// output = ambient color + absorption due to material color(kleur) * (normaalvector * lightinvalvector) * lichtkleur + C_spec *(viewvector * reflectvector)^S * Lspec
// Lspec = lightsterkte
// Cspec = reflectiviteit van het materiaal.
//S zijnde een constante die er mooi uit ziet.