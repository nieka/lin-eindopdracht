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
        private float lijnLength = 300;
        public Vector3D steunvector { get; private set; }
        public voertuig (float x, float y, float z)
        {
           
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
            steunvector = new Vector3D((float)matrix.matrix[0][2], (float)matrix.matrix[1][2], (float)matrix.matrix[2][2]);
            Vector3D SecondstartPunt = new Vector3D((float)matrix.matrix[0][3], (float)matrix.matrix[1][3], (float)matrix.matrix[2][3]);

            Vector3D Richtingsvector = getRichtingsVector();

            Vector3D temp = Vector3D.multiply(new Vector3D(lijnLength, lijnLength, lijnLength), Richtingsvector);
            Vector3D endPoint = Vector3D.add(steunvector, temp);

            return new Matrix3D(new List<List<double>>{
                new List<double> { steunvector.x, endPoint.x}, //x
                new List<double> { steunvector.y, endPoint.y}, //y
                new List<double> { steunvector.z, endPoint.z }  //z
            });
        }

        public Vector3D getRichtingsVector()
        {
            steunvector = new Vector3D((float)matrix.matrix[0][2], (float)matrix.matrix[1][2], (float)matrix.matrix[2][2]);
            Vector3D SecondstartPunt = new Vector3D((float)matrix.matrix[0][3], (float)matrix.matrix[1][3], (float)matrix.matrix[2][3]);

            Vector3D Richtingsvector = Vector3D.subtract(SecondstartPunt, steunvector);
            float distance = Vector3D.distance(steunvector, SecondstartPunt);
            return  Vector3D.Divide(Richtingsvector, new Vector3D(distance, distance, distance));
        }
    }
}
