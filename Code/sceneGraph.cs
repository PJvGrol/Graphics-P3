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

        public void Render(Matrix4 cam)
        {

        }
    }
}
