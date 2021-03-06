﻿using System;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Template_P3 {

    public class Shader
    {
	    // data members
	    public int programID, vsID, fsID;
	    public int attribute_vpos;
	    public int attribute_vnrm;
	    public int attribute_vuvs;
	    public int uniform_mview;
        public int uniform_idmview;
        public int uniform_lights;
        public int uniform_lpos1;
        public int uniform_lpos2;
        public int uniform_lint1;
        public int uniform_lint2;
        public int uniform_lcol1;
        public int uniform_lcol2;
        public int uniform_cpos;
        public Vector3 ambientLightColor;
        public Light[] lights;

	    // constructor
	    public Shader( String vertexShader, String fragmentShader )
	    {
		    // compile shaders
		    programID = GL.CreateProgram();
		    Load( vertexShader, ShaderType.VertexShader, programID, out vsID );
		    Load( fragmentShader, ShaderType.FragmentShader, programID, out fsID );
		    GL.LinkProgram( programID );
		    Console.WriteLine( GL.GetProgramInfoLog( programID ) );
            
		    // get locations of shader parameters
		    attribute_vpos = GL.GetAttribLocation( programID, "vPosition" );
		    attribute_vnrm = GL.GetAttribLocation( programID, "vNormal" );
		    attribute_vuvs = GL.GetAttribLocation( programID, "vUV" );
            uniform_cpos = GL.GetUniformLocation(programID, "cPosition");
		    uniform_mview = GL.GetUniformLocation( programID, "transform" );
            uniform_idmview = GL.GetUniformLocation(programID, "idtransform");
            uniform_lights = GL.GetUniformLocation(programID, "lights");
            uniform_lcol1 = GL.GetUniformLocation(programID, "lcol1");
            uniform_lcol2 = GL.GetUniformLocation(programID, "lcol2");
            uniform_lpos1 = GL.GetUniformLocation(programID, "lpos1");
            uniform_lpos2 = GL.GetUniformLocation(programID, "lpos2");
            uniform_lint1 = GL.GetUniformLocation(programID, "lint1");
            uniform_lint2 = GL.GetUniformLocation(programID, "lint2");


        }

	    // loading shaders
	    void Load( String filename, ShaderType type, int program, out int ID )
	    {
		    // source: http://neokabuto.blogspot.nl/2013/03/opentk-tutorial-2-drawing-triangle.html
		    ID = GL.CreateShader( type );
		    using (StreamReader sr = new StreamReader( filename )) GL.ShaderSource( ID, sr.ReadToEnd() );
		    GL.CompileShader( ID );
		    GL.AttachShader( program, ID );
		    Console.WriteLine( GL.GetShaderInfoLog( ID ) );
	    }
    }
    
    public class Light
    {
        public Vector4 position;
        public Vector4 color;
        public float intensity;

        public Light(Vector4 pos, Vector4 col, float i)
        {
            position = pos;
            color = col;
            intensity = i;
        }
    }
} // namespace Template_P3
