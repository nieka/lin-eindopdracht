using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lin_eindopdracht
{
    class voertuig
    {
        public Matrix3D matrix { get; private set; }

        public voertuig (float x, float y, float z)
        {
            List<List<double>> voertuigMatrix = new List<List<double>>{
                new List<double> {0,50,0,50, 0,50,0,50}, //x
                new List<double> {0,0,50,50, 0,0,50,50}, //y
                new List<double> {0,0,0,0,   50,50,50,50}  //z
            };

            matrix = new Matrix3D(voertuigMatrix);

            matrix.transleer(x, y, z);
        }
    }
}
