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
        private float lijnLength = 1000;
        public voertuig (float x, float y, float z)
        {
            //List<List<double>> voertuigMatrix = new List<List<double>>{
            //    new List<double> {0,50,0,50, 0,50,0,50}, //x
            //    new List<double> {0,0,50,50, 0,0,50,50}, //y
            //    new List<double> {0,0,0,0,   50,50,50,50}  //z
            //};

            List<List<double>> voertuigMatrix = new List<List<double>>{
                new List<double> {0,50,0,50, 0,50,0,50}, //x
                new List<double> {250,250,300,300, 250,250,300,300}, //y
                new List<double> {0,0,0,0,   50,50,50,50}  //z
            };

            matrix = new Matrix3D(voertuigMatrix);

            matrix.transleer(x, y, z);
        }

        public Matrix3D getShootLine()
        { 
            Vector3D steunvector = new Vector3D((float)matrix.matrix[0][1], (float)matrix.matrix[1][1], (float)matrix.matrix[2][1]);
            Vector3D SecondstartPunt = new Vector3D((float)matrix.matrix[0][0], (float)matrix.matrix[1][0], (float)matrix.matrix[2][0]);

            Vector3D Richtingsvector = Vector3D.subtract(SecondstartPunt, steunvector);
            Richtingsvector = Vector3D.multiply(Richtingsvector, new Vector3D(0.5f, 0.5f, 0.5f));
            
            Vector3D endPoint = Vector3D.add(steunvector, Vector3D.multiply(new Vector3D(lijnLength, lijnLength, lijnLength), Richtingsvector));

            return new Matrix3D(new List<List<double>>{
                new List<double> { steunvector.x, endPoint.x}, //x
                new List<double> { steunvector.y, endPoint.y}, //y
                new List<double> { steunvector.z, endPoint.z }  //z
            });
        }
    }
}
