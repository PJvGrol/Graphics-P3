#version 330
 
// shader input
in vec2 uv;						// interpolated texture coordinates
in vec4 normal;					// interpolated normal
uniform sampler2D pixels;		// texture sampler
uniform vec3 lights[7];



// shader output
out vec4 outputColor;

// fragment shader
void main()
{
    outputColor = texture( pixels, uv ) + 0.5f * vec4( normal.xyz, 1 );
}

//formula:
// output = ambient color + absorption due to material color(kleur) * (normaalvector * lightinvalvector) * lichtkleur + C_spec *(viewvector * reflectvector)^S * Lspec
// Lspec = lightsterkte
// Cspec = reflectiviteit van het materiaal.
//S zijnde een constante die er mooi uit ziet.