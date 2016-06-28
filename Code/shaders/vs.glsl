#version 330
 
// shader input
in vec2 vUV;				// vertex uv coordinate
in vec3 vNormal;			// untransformed vertex normal
in vec3 vPosition;			// untransformed vertex position
in vec4 cPosition;

// shader output
out vec4 normal;			// transformed vertex normal
out vec4 vpos;
out vec4 cpos;
out vec2 uv;				
uniform mat4 transform;
uniform mat4 idtransform;
 
// vertex shader
void main()
{
	// transform vertex using supplied matrix
	gl_Position = transform * vec4(vPosition, 1.0);

	// forward normal and uv coordinate; will be interpolated over triangle
	normal = idtransform * vec4( vNormal, 0.0f );
	vpos = idtransform* vec4(vPosition, 0.0f);
	cpos =  cPosition; //* tranform;
	uv = vUV;
}