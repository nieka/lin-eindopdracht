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
            List<List<double>> monsterMatrix = new List<List<double>>{
                new List<double> {-1000,-950, -1000, -950, -1000, -950, - 1000, -950}, //x
                new List<double> {250,250,300,300, 250,250,300,300}, //y
                new List<double> {0,0,0,0,   50,50,50,50}  //z
            };

            matrix = new Matrix3D(monsterMatrix);
            matrix.transleer(x, y, z);

            maxGrowHeight = canvasHeight / 3;
            maxGrowWidth = canvasWidth / 3;
        }

        public void grow()
        {
            if (Math.Abs(matrix.matrix[0][1] - matrix.matrix[0][1]) < maxGrowWidth && Math.Abs(matrix.matrix[1][1] - matrix.matrix[1][3]) < maxGrowWidth)
            {
                matrix.schaal(growSpeed, growSpeed, 1);
            }

            //move monster closer to 
            if (matrix.matrix[2][4] < 0)
            {
                matrix.transleer(MOVESPEED, 0, 0);
            }

        }

        public bool HulpLijnRaaktVlak(Vector3D punt)
        {
            //bottum
            List<List<double>> vlak = new List<List<double>>{
                new List<double> {matrix.matrix[0][2],matrix.matrix[0][3],matrix.matrix[0][7]}, //x
                new List<double> {matrix.matrix[1][2],matrix.matrix[1][3],matrix.matrix[1][7]}, //y
                new List<double> {matrix.matrix[2][2], matrix.matrix[2][3], matrix.matrix[2][7] }  //z
            };
            if(Matrix3D.puntInVlak(punt,new Matrix3D(vlak))){
                return true;
            }
            //right
            vlak = new List<List<double>>{
                new List<double> {matrix.matrix[0][1],matrix.matrix[0][3],matrix.matrix[0][7]}, //x
                new List<double> {matrix.matrix[1][1],matrix.matrix[1][3],matrix.matrix[1][7]}, //y
                new List<double> {matrix.matrix[2][1], matrix.matrix[2][3], matrix.matrix[2][7] }  //z
            };
            if (Matrix3D.puntInVlak(punt, new Matrix3D(vlak))){
                return true;
            }
            //front
            vlak = new List<List<double>>{
                new List<double> {matrix.matrix[0][4],matrix.matrix[0][5],matrix.matrix[0][7]}, //x
                new List<double> {matrix.matrix[1][4],matrix.matrix[1][5],matrix.matrix[1][7]}, //y
                new List<double> {matrix.matrix[2][4], matrix.matrix[2][5], matrix.matrix[2][7] }  //z
            };
            if (Matrix3D.puntInVlak(punt, new Matrix3D(vlak))){
                return true;
            }
            //left
            vlak = new List<List<double>>{
                new List<double> {matrix.matrix[0][0],matrix.matrix[0][2],matrix.matrix[0][6]}, //x
                new List<double> {matrix.matrix[1][0],matrix.matrix[1][2],matrix.matrix[1][6]}, //y
                new List<double> {matrix.matrix[2][0], matrix.matrix[2][2], matrix.matrix[2][6] }  //z
            };
            if (Matrix3D.puntInVlak(punt, new Matrix3D(vlak)))
            {
                return true;
            }
            //back
            vlak = new List<List<double>>{
                new List<double> {matrix.matrix[0][0],matrix.matrix[0][1],matrix.matrix[0][3]}, //x
                new List<double> {matrix.matrix[1][0],matrix.matrix[1][1],matrix.matrix[1][3]}, //y
                new List<double> {matrix.matrix[2][0], matrix.matrix[2][1], matrix.matrix[2][3] }  //z
            };
            if (Matrix3D.puntInVlak(punt, new Matrix3D(vlak)))
            {
                return true;
            }

            //top
            vlak = new List<List<double>>{
                new List<double> {matrix.matrix[0][1],matrix.matrix[0][0],matrix.matrix[0][4]}, //x
                new List<double> {matrix.matrix[1][1],matrix.matrix[1][0],matrix.matrix[1][4]}, //y
                new List<double> {matrix.matrix[2][1], matrix.matrix[2][0], matrix.matrix[2][4] }  //z
            };
            if (Matrix3D.puntInVlak(punt, new Matrix3D(vlak)))
            {
                return true;
            }
            return false;
        
        }
    }
}
