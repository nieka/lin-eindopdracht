using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lin_eindopdracht
{
    class Monster
    {
        public Matrix3D matrix { get; private set; }
        private double growSpeed = 5;
        private double maxGrowWidth;
        private double maxGrowHeight;

        public Monster(float x, float y, float z, double canvasWidth, double canvasHeight )
        {
            List<List<double>> voertuigMatrix = new List<List<double>>{
                new List<double> {0,20,0,20, 0,20,0,20}, //x
                new List<double> {0,0,20,20, 0,0,20,20}, //y
                new List<double> {0,0,0,0,   20,20,20,20}  //z
            };

            matrix = new Matrix3D(voertuigMatrix);
            matrix.transleer(x, y, z);

            maxGrowHeight = canvasHeight / 3;
            maxGrowWidth = canvasWidth / 3;

        }

        public void grow()
        {
            //not working correctly
            //if(Math.Abs(matrix.matrix[0][1] - matrix.matrix[0][1]) < maxGrowWidth && Math.Abs(matrix.matrix[1][1] - matrix.matrix[1][3]) < maxGrowWidth)
            //{
            //    matrix.schaal(growSpeed, growSpeed, growSpeed);
            //}

            //if (matrix.matrix[2][4] < 0)
            //{
            //    matrix.transleer(0, 0, (float)growSpeed);
            //}
            
        }
    }
}
