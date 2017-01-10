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
        private const float MOVESPEED = 5;
        private double maxGrowWidth;
        private double maxGrowHeight;

        public Monster(float x, float y, float z, double canvasWidth, double canvasHeight )
        {
            //List<List<double>> voertuigMatrix = new List<List<double>>{
            //    new List<double> {0,50,0,50, 0,50,0,50}, //x
            //    new List<double> {250,250,300,300, 250,250,300,300}, //y
            //    new List<double> {0,0,0,0,   50,50,50,50}  //z
            //};
            List<List<double>> monsterMatrix = new List<List<double>>{
                new List<double> {-1000,-950, -1000, -950, -1000, -950, - 1000, -950}, //x
                new List<double> {250,250,300,300, 250,250,300,300}, //y
                new List<double> {0,0,0,0,   50,50,50,50}  //z
            };
            //List<List<double>> monsterMatrix = new List<List<double>>{
            //        new List<double> {0,50,0,50, 0,50,0,50}, //x
            //        new List<double> {0,0,50,50, 0,0,50,50}, //y
            //        new List<double> {0,0,0,0,   50,50,50,50}  //z
            //};

            matrix = new Matrix3D(monsterMatrix);
            matrix.transleer(x, y, z);

            maxGrowHeight = canvasHeight / 3;
            maxGrowWidth = canvasWidth / 3;

        }

        public void grow()
        {
            if (Math.Abs(matrix.matrix[0][1] - matrix.matrix[0][1]) < maxGrowWidth && Math.Abs(matrix.matrix[1][1] - matrix.matrix[1][3]) < maxGrowWidth)
            {
                matrix.schaal(growSpeed, growSpeed, growSpeed);
            }

            //move monster closer to 
            if (matrix.matrix[2][4] < 0)
            {
                matrix.transleer(MOVESPEED, 0, 0);
            }

        }
    }
}
