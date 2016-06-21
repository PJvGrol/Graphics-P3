#version 330
 
// shader input
in vec2 uv;						// interpolated texture coordinates
in vec4 normal;					// interpolated normal
uniform vec4 lpos;
uniform vec4 lcol;
uniform sampler2D pixels;		// texture sampler
uniform float lights[7];



// shader output
out vec4 outputColor;

// fragment shader
void main()
{
	vec4 woop;
	vec4 woop2;
	woop = lpos;
	woop2 = lcol;
    outputColor = texture( pixels, uv ) *(0.5 + texture( pixels, uv) * (normal*woop)* woop2);
}

//formula:
// output = ambient color + absorption due to material color(kleur) * (normaalvector * lightinvalvector) * lichtkleur + C_spec *(viewvector * reflectvector)^S * Lspec
// Lspec = lightsterkte
// Cspec = reflectiviteit van het materiaal.
//S zijnde een constante die er mooi uit ziet.