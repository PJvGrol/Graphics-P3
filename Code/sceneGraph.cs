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

        public Mesh current;

        public SceneGraph(SceneGraph prnt, SceneGraph[] chldrn, Mesh mesh)
        {
            parent = prnt;
            children = chldrn;
            current = mesh;
        }

        public void Render(Matrix4 cam)
        {
            foreach(SceneGraph child in children)
            {
                Render(Matrix4.Mult(current.transformation, cam));
            }
        }
    }
}
