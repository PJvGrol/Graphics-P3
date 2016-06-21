using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Template_P3
{
    class SceneGraph
    {
        // Enable hierarchical ordering
        public SceneGraph[] children;

        public Mesh mesh;
        public Shader shader;
        public Texture texture;

        public SceneGraph(SceneGraph[] chldrn, Mesh msh, Shader shdr, Texture txtr)
        {
            children = chldrn;
            mesh = msh;
            shader = shdr;
            texture = txtr;
        }

        public void Render(Matrix4 cam, Light[] lights)
        {
            // Volgorde vermenigvuldiging?
            cam = Matrix4.Mult(mesh.transformation, cam);
            mesh.Render(shader, cam, texture, lights);
            if (children != null)
            {
                foreach (SceneGraph child in children)
                {
                    child.Render(cam, lights);
                }
            }
        }
    }
}
