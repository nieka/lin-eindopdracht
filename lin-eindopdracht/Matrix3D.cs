using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lin_eindopdracht
{
    public class Matrix3D
    {
        private List<List<double>> matrix;

        public Matrix3D(List<List<double>> matrix)
        {
            this.matrix = matrix;
        }

        public void rotated(double graden)
        {
            //rotate code voor een 2d matrix
            //graden = ConvertToRadians(graden);

            //List<List<double>> R_matrix = new List<List<double>>();
            //R_matrix.Add(new List<double>());
            //R_matrix.Add(new List<double>());
            //R_matrix[0].Add(Math.Cos(graden));
            //R_matrix[0].Add(Math.Sin(-1 * graden));
            //R_matrix[1].Add(Math.Sin(graden));
            //R_matrix[1].Add(Math.Cos(graden));

            ////vermenigvuldig de matrix
            //matrix = Matrix3D.vermenigvuldig(R_matrix, matrix);
        }

        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public void transleer(float x, float y)
        {
            //schaal functie voor 2d matrix
            ////maak schaal matrix aan
            //List<List<double>> T_matrix = new List<List<double>>();
            //List<List<double>> M_matrix = matrix;
            //for (int i = 0; i < 3; i++)
            //{
            //    T_matrix.Add(new List<double>(3));
            //}
            //for (int i = 0; i < T_matrix.Count; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        T_matrix[i].Add(0);
            //    }
            //}

            ////zet 1s in de matrixs
            //T_matrix[0][0] = 1;
            //T_matrix[1][1] = 1;
            //T_matrix[2][2] = 1;
            ////zet verplaatsing x en y
            //T_matrix[0][2] = x;
            //T_matrix[1][2] = y;

            //List<double> rekenlist = new List<double>();
            //for (int i = 0; i < matrix[0].Count; i++)
            //{
            //    rekenlist.Add(1);
            //}
            //M_matrix.Add(rekenlist);
            //matrix = Matrix3D.vermenigvuldig(T_matrix, M_matrix);
            //matrix.RemoveAt(matrix.Count - 1);
        }

        public static List<List<double>> vermenigvuldig(List<List<double>> matrix1, List<List<double>> matrix2)
        {
            List<List<double>> matrix = new List<List<double>>();
            if(matrix1.Count == 0 || matrix2.Count == 0)
            {
                return matrix;
            }

            if (matrix1[0].Count != matrix2.Count)
            {
                return matrix;
            }

            //maak nieuwe matrix aan
            //voeg er rijen toe aan de matrrix
            for (int i = 0; i < matrix1.Count(); i++)
            {
                matrix.Add(new List<double>());
            }


            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix2[i].Count; j++)
                {
                    double waarde = 0;
                    for (int k = 0; k < matrix1[i].Count(); k++)
                    {
                        waarde += matrix1[i][k] * matrix2[k][j];
                    }
                    matrix[i].Add(waarde);
                }
            }

            return matrix;
        }
    }
}
