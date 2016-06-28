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

        public void Render(Matrix4 trans, Light[] lights, Vector4 cam)
        {
            trans = Matrix4.Mult(mesh.transformation, trans);
            mesh.Render(shader, trans, texture, lights, cam);
            if (children != null)
            {
                foreach (SceneGraph child in children)
                {
                    child.Render(trans, lights, cam);
                }
            }
        }
    }
}
