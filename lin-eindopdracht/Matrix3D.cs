﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lin_eindopdracht
{
    public class Matrix3D
    {
        public List<List<double>> matrix { get; set; }

        public Matrix3D(List<List<double>> matrix)
        {
            this.matrix = matrix;
        }

        public void schaal(double x, double y, double z)
        {
            //maak schaal matrix aan
            List<List<double>> S_matrix = new List<List<double>>();
            S_matrix.Add(new List<double> { x, 0, 0 });
            S_matrix.Add(new List<double> { 0, y, 0 });
            S_matrix.Add(new List<double> { 0, 0, z });

            //vermenigvuldig de matrix
            matrix = Matrix3D.vermenigvuldig(S_matrix, matrix);
        }

        public void rotated(double graden, RotateType type)
        {
            //rotate code voor een 2d matrix
            graden = ConvertToRadians(graden);

            List<List<double>> R_matrix = new List<List<double>>();

            switch (type)
            {
                case RotateType.XAS:
                    R_matrix.Add(new List<double>() { 1, 0, 0 });
                    R_matrix.Add(new List<double>() { 0, Math.Cos(graden), -1 * Math.Sin(graden) });
                    R_matrix.Add(new List<double>() { 0 , Math.Sin(graden) , Math.Cos(graden) });
                    break;
                case RotateType.YAS:
                    R_matrix.Add(new List<double>() { Math.Cos(graden), 0, -1 * Math.Sin(graden) });
                    R_matrix.Add(new List<double>() { 0, 1, 0 });
                    R_matrix.Add(new List<double>() { Math.Sin(graden), 0 ,Math.Cos(graden) });
                    break;

                case RotateType.ZAS:
                    R_matrix.Add(new List<double>() { Math.Cos(graden),-1 * Math.Sin(graden), 0 });
                    R_matrix.Add(new List<double>() { Math.Sin(graden),Math.Cos(graden), 0 });
                    R_matrix.Add(new List<double>() { 0,0,1});
                    break;
            }
            

            //vermenigvuldig de matrix
            matrix = Matrix3D.vermenigvuldig(R_matrix, matrix);
        }

        public void rotatedSelf(double graden, RotateType type)
        {
            //List<List<double>> tempmatrix = matrix;
            graden = ConvertToRadians(graden);

            float x = (float)matrix[0][0];
            float y = (float)matrix[0][1];
            float z = (float)matrix[0][2];
            double t1 = Math.Atan2(z, x);
            double t2 = Math.Atan2(y, (Math.Sqrt(x * x + y * y)));

            transleer(-x, -y, -z);

            //rotated(t, RotateType.YAS);
            //rotated(t2, RotateType.ZAS);
            //rotated(graden, RotateType.XAS);
            //rotated(t2, RotateType.ZAS);
            //rotated(t,RotateType.YAS);
            
            List<List<double>> R1_matrix = new List<List<double>>();
            R1_matrix.Add(new List<double>() { Math.Cos(t1), 0, -1 * Math.Sin(t1) });
            R1_matrix.Add(new List<double>() { 0, 1, 0 });
            R1_matrix.Add(new List<double>() { Math.Sin(t1), 0, Math.Cos(t1) });
            matrix = Matrix3D.vermenigvuldig(R1_matrix, matrix);

            List<List<double>> R2_matrix = new List<List<double>>();
            R2_matrix.Add(new List<double>() { Math.Cos(t2), -1 * Math.Sin(t2), 0 });
            R2_matrix.Add(new List<double>() { Math.Sin(t2), Math.Cos(t2), 0 });
            R2_matrix.Add(new List<double>() { 0, 0, 1 });
            matrix = Matrix3D.vermenigvuldig(R2_matrix, matrix);

            List<List<double>> R3_matrix = new List<List<double>>();
            R3_matrix.Add(new List<double>() { 1, 0, 0 });
            R3_matrix.Add(new List<double>() { 0, Math.Cos(graden), -1 * Math.Sin(graden) });
            R3_matrix.Add(new List<double>() { 0, Math.Sin(graden), Math.Cos(graden) });
            matrix = Matrix3D.vermenigvuldig(R3_matrix, matrix);

            List<List<double>> R4_matrix = new List<List<double>>();
            R4_matrix.Add(new List<double>() { 1, 0, 0 });
            R4_matrix.Add(new List<double>() { 0, Math.Cos(t2), -1 * Math.Sin(t2) });
            R4_matrix.Add(new List<double>() { 0, Math.Sin(t2), Math.Cos(t2) });
            matrix = Matrix3D.vermenigvuldig(R4_matrix, matrix);

            List<List<double>> R5_matrix = new List<List<double>>();
            R5_matrix.Add(new List<double>() { Math.Cos(t1), 0, -1 * Math.Sin(t1) });
            R5_matrix.Add(new List<double>() { 0, 1, 0 });
            R5_matrix.Add(new List<double>() { Math.Sin(t1), 0, Math.Cos(t1) });
            matrix = Matrix3D.vermenigvuldig(R5_matrix, matrix);
            
            //matrix = tempmatrix;
            transleer(x,y,z);
        }
        public void rotatedSelfv2(double graden, RotateType type)
        {
            //List<List<double>> tempmatrix = matrix;
            graden = ConvertToRadians(graden);
            
            float x = (float)matrix[0][0];
            float y = (float)matrix[0][1];
            float z = (float)matrix[0][2];
            double t1 = Math.Atan2(z, x);
            double t2 = Math.Atan2(y, (Math.Sqrt(x * x + y * y)));
            Matrix3D RotateMatrix = new Matrix3D(null);
            //translatie matrix
            List<List<double>> Translatie = new List<List<double>>();
            Translatie.Add(new List<double>() { 1,0,0 , -x });
            Translatie.Add(new List<double>() { 0, 1, 0, -y });
            Translatie.Add(new List<double>() { 0,0,1,-z });
            Translatie.Add(new List<double>() { 0,0,0,1});

            List<List<double>> R1_matrix = new List<List<double>>();
            R1_matrix.Add(new List<double>() { Math.Cos(t1), 0, Math.Sin(t1),0 });
            R1_matrix.Add(new List<double>() { 0, 1, 0,0 });
            R1_matrix.Add(new List<double>() { -1 * Math.Sin(t1), 0, Math.Cos(t1) , 0});
            R1_matrix.Add(new List<double>() { 0, 0, 0 , 1 });
              RotateMatrix.matrix = Matrix3D.vermenigvuldig(R1_matrix,Translatie);

            List<List<double>> R2_matrix = new List<List<double>>();
            R2_matrix.Add(new List<double>() { Math.Cos(t2), Math.Sin(t2), 0, 0 });
            R2_matrix.Add(new List<double>() { -1 * Math.Sin(t2), Math.Cos(t2), 0,0 });
            R2_matrix.Add(new List<double>() { 0, 0, 1 ,0});
            R2_matrix.Add(new List<double>() { 0, 0, 0 ,1 });
             RotateMatrix.matrix = Matrix3D.vermenigvuldig(R2_matrix, RotateMatrix.matrix);

            List<List<double>> R3_matrix = new List<List<double>>();
            R3_matrix.Add(new List<double>() { 1, 0, 0 ,0});
            R3_matrix.Add(new List<double>() { 0, Math.Cos(graden), -1 * Math.Sin(graden),0 });
            R3_matrix.Add(new List<double>() { 0, Math.Sin(graden), Math.Cos(graden),0 });
            R3_matrix.Add(new List<double>() { 0, 0, 0, 1 });
            RotateMatrix.matrix = Matrix3D.vermenigvuldig(R3_matrix,RotateMatrix.matrix);

            List<List<double>> R4_matrix = new List<List<double>>();
            R4_matrix.Add(new List<double>() { Math.Cos(t2), -1 * Math.Sin(t2), 0,0 });
            R4_matrix.Add(new List<double>() { Math.Sin(t2), Math.Cos(t2), 0,0 });
            R4_matrix.Add(new List<double>() { 0, 0, 1, 0});
            R4_matrix.Add(new List<double>() { 0, 0, 0, 1});
            RotateMatrix.matrix = Matrix3D.vermenigvuldig(R4_matrix,RotateMatrix.matrix);

            List<List<double>> R5_matrix = new List<List<double>>();
            R5_matrix.Add(new List<double>() { Math.Cos(t1), 0, -1 * Math.Sin(t1),0 });
            R5_matrix.Add(new List<double>() { 0, 1, 0,0 });
            R5_matrix.Add(new List<double>() { Math.Sin(t1), 0, Math.Cos(t1),0 });
            R5_matrix.Add(new List<double>() { 0, 0, 0, 1 });
            RotateMatrix.matrix = Matrix3D.vermenigvuldig(R5_matrix, RotateMatrix.matrix);

            Translatie = new List<List<double>>();
            Translatie.Add(new List<double>() { 1, 0, 0, x });
            Translatie.Add(new List<double>() { 0, 1, 0, y });
            Translatie.Add(new List<double>() { 0, 0, 1, z });
            Translatie.Add(new List<double>() { 0, 0, 0, 1 });
            RotateMatrix.matrix = Matrix3D.vermenigvuldig(Translatie,RotateMatrix.matrix);

            matrix.Add(new List<double> { 1, 1, 1, 1, 1, 1, 1, 1 });
            matrix = Matrix3D.vermenigvuldig(RotateMatrix.matrix,matrix);
            matrix.RemoveAt(matrix.Count - 1);
        }

        public void transleer(float x, float y,float z)
        {
            //maak schaal matrix aan
            List<List<double>> T_matrix = new List<List<double>>();
            List<List<double>> M_matrix = matrix;
            for (int i = 0; i < 4; i++)
            {
                T_matrix.Add(new List<double>(4));
            }
            for (int i = 0; i < T_matrix.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    T_matrix[i].Add(0);
                }
            }

            //zet 1s in de matrixs
            T_matrix[0][0] = 1;
            T_matrix[1][1] = 1;
            T_matrix[2][2] = 1;
            T_matrix[3][3] = 1;
            //zet verplaatsing x en y
            T_matrix[0][3] = x;
            T_matrix[1][3] = y;
            T_matrix[2][3] = z;

            List<double> rekenlist = new List<double>();
            for (int i = 0; i < matrix[0].Count; i++)
            {
                rekenlist.Add(1);
            }
            M_matrix.Add(rekenlist);
            matrix = Matrix3D.vermenigvuldig(T_matrix, M_matrix);
            matrix.RemoveAt(matrix.Count - 1);
        }

        //static methodes
        public static double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public static List<List<double>> inverse(List<List<double>> matrix)
        {
            double temp = Matrix3D.Determinant(matrix);
            //check if we can calculate the inverse
            if (temp == 0)
            {
                return null;
            }

            //identiteitMatrix matrix
            List<List<double>> identiteitsmatrix = new List<List<double>>();
            identiteitsmatrix.Add(new List<double> { 1, 0, 0 });
            identiteitsmatrix.Add(new List<double> { 0, 1, 0 });
            identiteitsmatrix.Add(new List<double> { 0, 0, 1 });

            //zet de rij met de hoogste waarde bovenaan
            int highstrow = 0;
            double highstNumber = 0;
            for (int i = 0; i < matrix.Count; i++)
            {
                for(int j=0; j<matrix[i].Count; j++)
                {
                    if(matrix[i][j] > highstNumber)
                    {
                        highstNumber = matrix[i][j];
                        highstrow = i;
                    }
                }
            }

            List<double> tempRow = matrix[0];
            matrix[0] = matrix[highstrow];
            matrix[highstrow] = tempRow;
            tempRow = identiteitsmatrix[0];
            identiteitsmatrix[0] = identiteitsmatrix[highstrow];
            identiteitsmatrix[highstrow] = tempRow;


            //Per colum zetten we de identiteit matrix naar de normale matrix
            for (int i=0; i<matrix[0].Count; i++)
            {
                //multiply to get 1 on the correct position
                double multiplier = 1 / matrix[i][i];
                //multiply the whole row 
                for(int j=0; j< matrix[0].Count; j++)
                {
                    //we can use here the i as first parameter because we know that the amtrix is a sqaure
                    matrix[i][j] *= multiplier;
                    identiteitsmatrix[i][j] *= multiplier;
                }

                //make the other number in the collom zero
                //set the other collom values to zero
                for (int j = 0; j < matrix.Count; j++)
                {
                    //we want to make the other collums zero so we don't pick the collum we multiplayed
                    if(i!= j)
                    {
                        if (matrix[j][i] != 0)
                        {
                            multiplier = matrix[j][i];

                            for (int k = 0; k < matrix[j].Count; k++)
                            {
                                matrix[j][k] -= multiplier * matrix[i][k];
                                identiteitsmatrix[j][k] -= multiplier * identiteitsmatrix[i][k];
                            }
                        }
                    }
                }
            }

            return identiteitsmatrix;
        }

        public static double Determinant(List<List<double>> matrix)
        {
            //check if it is a 3 x 3 matrix
            if(matrix.Count != 3 || matrix[0].Count != 3)
            {
                return 0;
            }
            double a = matrix[0][0];
            double b = matrix[0][1];
            double c = matrix[0][2];
            double d = matrix[1][0];
            double e = matrix[1][1];
            double f = matrix[1][2];
            double g = matrix[2][0];
            double h = matrix[2][1];
            double i = matrix[2][2];

            return a * (e * i - h * f ) - d *(b*i - h*c)+g*(b*f - e*c);

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
