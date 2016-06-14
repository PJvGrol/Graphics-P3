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
        public SceneGraph parent;
        public SceneGraph[] children;

        public Mesh mesh;
        public Shader shader;
        public Texture texture;

        public SceneGraph(SceneGraph prnt, SceneGraph[] chldrn, Mesh msh)
        {
            parent = prnt;
            children = chldrn;
            mesh = msh;
        }

        public void Render(Matrix4 cam)
        {
            cam = Matrix4.Mult(cam, mesh.transformation);
            mesh.Render(shader, cam, texture);
            foreach (SceneGraph child in children)
            {
                Render(cam);
            }
        }
    }
}
