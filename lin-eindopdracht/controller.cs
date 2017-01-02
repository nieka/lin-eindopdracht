using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lin_eindopdracht
{
    class controller
    {
        private Canvas canvas;

        //vairable for drawing 
        private Vector3D eye;
        private Vector3D lookAt;
        private Vector3D up;

        public controller(Canvas canvas)
        {
            this.canvas = canvas;

            draw();
        }

        public void draw()
        {

        }
    }
}
