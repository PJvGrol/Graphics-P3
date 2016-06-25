using System.Diagnostics;
using OpenTK;

// minimal OpenTK rendering framework for UU/INFOGR
// Jacco Bikker, 2016

namespace Template_P3 {
    class Game
    {
	    // member variables
	    public Surface screen;					// background surface for printing etc.
	    Mesh mesh, floor;						// a mesh to draw using OpenGL
        SceneGraph scenegraph ;
	    const float PI = 3.1415926535f;			// PI
	    float a = 0;							// teapot rotation angle
	    Stopwatch timer;						// timer for measuring frame duration
	    Shader shader;							// shader to use for rendering
	    Texture wood;							// texture to use for rendering
        Matrix4 cam = new Matrix4(1.0f,0,0,0,0,1.0f,0,0,0,0,1.0f,0,0,0,0,1.0f);
        Light[] lights;

	    // initialize
	    public void Init()
	    {
		    // load teapot
		    mesh = new Mesh( "../../assets/teapot.obj" );
            floor = new Mesh("../../assets/floor.obj");
            // initialize stopwatch
		    timer = new Stopwatch();
		    timer.Reset();
		    timer.Start();
		    // create shaders
		    shader = new Shader( "../../shaders/vs.glsl", "../../shaders/fs.glsl" );
		    // load a texture
		    wood = new Texture( "../../assets/wood.jpg" );
            scenegraph = new SceneGraph(new SceneGraph[] { new SceneGraph(null, mesh, shader, wood) }, floor, shader, wood);
            // load lights
            lights = new Light[1];
            lights[0] = new Light(new Vector4(4, 4, -15 ,1), new Vector4(1, 1,1 , 1), 10);
        }

	    // tick for background surface
	    public void Tick()
	    {
		    screen.Clear( 0 );
		    screen.Print( "I GUESS IT IS TIME4TEA", 2, 2, 0xffff00 );
	    }

	    // tick for OpenGL rendering code
	    public void RenderGL()
	    {
		    // measure frame duration
		    float frameDuration = timer.ElapsedMilliseconds;
		    timer.Reset();
		    timer.Start();
            var keyboard = OpenTK.Input.Keyboard.GetState();
            if (keyboard[OpenTK.Input.Key.W])
            {
                cam *= Matrix4.CreateTranslation(0, 0, 0.1f);
            }
            if(keyboard[OpenTK.Input.Key.S])
            {
                cam *= Matrix4.CreateTranslation(0, 0, -0.1f);
            }
            if (keyboard[OpenTK.Input.Key.Space])
            {
                cam *= Matrix4.CreateTranslation(0,-0.1f, 0);
            }
            if (keyboard[OpenTK.Input.Key.ShiftLeft])
            {
                cam *= Matrix4.CreateTranslation(0, 0.1f, 0);
            }
            if (keyboard[OpenTK.Input.Key.A])
            {
                cam *= Matrix4.CreateTranslation(0.1f, 0, 0);
            }
            if (keyboard[OpenTK.Input.Key.D])
            {
                cam *= Matrix4.CreateTranslation(-0.1f, 0, 0);
            }
            if (keyboard[OpenTK.Input.Key.I])
            {
                cam *= Matrix4.CreateRotationX(0.1f);
            }
            if (keyboard[OpenTK.Input.Key.Q])
            {
                cam *= Matrix4.CreateRotationY(-0.1f);
            }
            if (keyboard[OpenTK.Input.Key.E])
            {
                cam *= Matrix4.CreateRotationY(0.1f);
            }
            if (keyboard[OpenTK.Input.Key.K])
            {
                cam *= Matrix4.CreateRotationX(-0.1f);
            }
            if (keyboard[OpenTK.Input.Key.J])
            {
                cam *= Matrix4.CreateRotationZ(-0.1f);
            } 
            if (keyboard[OpenTK.Input.Key.L])
            {
                cam *= Matrix4.CreateRotationZ(0.1f);
            }
		    // prepare matrix for vertex shader
		    Matrix4 transform = Matrix4.CreateFromAxisAngle( new Vector3( 0, 1, 0 ), a );
		    transform *= Matrix4.CreateTranslation( 0, -4, -15 );
            transform *= cam;
		    transform *= Matrix4.CreatePerspectiveFieldOfView( 1.2f, 1.3f, .1f, 1000 );

		    // update rotation
		    a += 0.001f * frameDuration; 
		    if (a > 2 * PI) a -= 2 * PI;

		    // render scene
		    // mesh.Render( shader, transform, wood , lights);
		    // floor.Render( shader, transform, wood , lights);
            scenegraph.Render(transform, lights);
	    }
    }
} // namespace Template_P3