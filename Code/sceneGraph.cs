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
        // A parent SceneGraph is unneeded and makes it unnecesarily difficult
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

        public void Render(Matrix4 trans, Light[] lights, Vector4 cam, Matrix4 id)
        {
            id = Matrix4.Mult(mesh.transformation, id);                 // transform to world space
            trans = Matrix4.Mult(mesh.transformation, trans);           // transform to camera space
            mesh.Render(shader, trans, texture, lights, cam, id);       // render the mesh
            if (children != null)                                       // render the children
            {
                foreach (SceneGraph child in children)
                {
                    child.Render(trans, lights, cam, id);
                }
            }
        }
    }
}
