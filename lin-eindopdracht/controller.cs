using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace lin_eindopdracht
{
    class controller
    {
        private Canvas canvas;
        private Matrix3D voertuig;

        //vairable for drawing 
        private Vector3D eye;
        private Vector3D lookAt;
        private Vector3D up;

        private double screenSize = 600;

        public controller(Canvas canvas)
        {
            this.canvas = canvas;

            List<List<double>> voertuigMatrix = new List<List<double>>{
                new List<double> {0,50,0,50, 0,50,0,50}, //x
                new List<double> {0,0,50,50, 0,0,50,50}, //y
                new List<double> {0,0,0,0,   50,50,50,50}  //z
            };

            //List<List<double>> voertuigMatrix = new List<List<double>>{
            //    new List<double> {1,5,1,5   ,1,5,1,5}, //x
            //    new List<double> {1,1,5,5   ,1,1,5,5 }, //y
            //    new List<double> {1,1,1,1   ,5,5,5,5}  //z
            //};

            voertuig = new Matrix3D(voertuigMatrix);

            eye = new Vector3D(200, 200, 200);
            lookAt = new Vector3D(0, 0, 0);
            up = new Vector3D(0, 1, 0);

            draw();
        }

        public void draw()
        {
            //used matrixed 
            Matrix3D cameraMatrix = getCameraMatrix();
            Matrix3D projectieMatrix = getProjectieMatrix();

            Matrix3D temp = new Matrix3D(null);
            temp.matrix = Matrix3D.vermenigvuldig(projectieMatrix.matrix, cameraMatrix.matrix);

            //drawig voertuig
            voertuig.matrix.Add(new List<double> { 1, 1, 1, 1, 1, 1, 1, 1 });
            voertuig.matrix = Matrix3D.vermenigvuldig(temp.matrix,voertuig.matrix);
            naberekening(voertuig);

            //clear canvas
            canvas.Children.Clear();
            
            //draw voertuig matrix
            drawMatrix(voertuig.matrix);
        }


        public void drawMatrix(List<List<double>> list)
        {


            PointCollection points = new PointCollection();

            //adding the point to voertuigPointCollection
            for (int i = 0; i < voertuig.matrix[0].Count; i++)
            {
                //collection the x,y,z,w values of the matrix
                double x = list[0][i];
                double y = list[1][i];
                double z = list[2][i];
                double w = list[3][i];

                //if w is smaller then 0 we don't need to draw it
                points.Add(new Point(x, y));
            }


            //bottom
            SolidColorBrush botColour = new SolidColorBrush();
            botColour.Color = Colors.Blue;

            PointCollection bottom = new PointCollection();
            //List<List<double>> voertuigMatrix = new List<List<double>>{
            //    new List<double> {1,5,1,5   ,1,5,1,5}, //x
            //    new List<double> {1,1,5,5   ,1,1,5,5 }, //y
            //    new List<double> {1,1,1,1   ,5,5,5,5}  //z
            //};
            bottom.Add(points[2]);
            bottom.Add(points[3]);

            bottom.Add(points[7]);
            bottom.Add(points[6]);
            //bottom.Add(new Point(0, 10));
            //bottom.Add(new Point(10, 10));
            //bottom.Add(new Point(10, 20));
            //bottom.Add(new Point(0, 20));


            //creating polygon shape for side
            Polygon voertuigPolygonBottom = new Polygon();
            voertuigPolygonBottom.Points = bottom;
            voertuigPolygonBottom.Stroke = Brushes.Black;
            voertuigPolygonBottom.StrokeThickness = 1;

            voertuigPolygonBottom.Fill = botColour;

            canvas.Children.Add(voertuigPolygonBottom);


            //back
            SolidColorBrush backColour = new SolidColorBrush();
            backColour.Color = Colors.Yellow;
            PointCollection back = new PointCollection();

            back.Add(points[0]);
            back.Add(points[1]);
            back.Add(points[3]);
            back.Add(points[2]);
            

            //creating polygon shape for side
            Polygon voertuigPolygonback = new Polygon();
            voertuigPolygonback.Points = back;
            voertuigPolygonback.Stroke = Brushes.Black;
            voertuigPolygonback.StrokeThickness = 1;

            voertuigPolygonback.Fill = backColour;

            canvas.Children.Add(voertuigPolygonback);


            //left
            SolidColorBrush leftColour = new SolidColorBrush();
            leftColour.Color = Colors.Green;
            PointCollection left = new PointCollection();

            left.Add(points[0]);
            left.Add(points[2]);
            left.Add(points[6]);
            left.Add(points[4]);


            //creating polygon shape for side
            Polygon voertuigPolygonleft = new Polygon();
            voertuigPolygonleft.Points = left;
            voertuigPolygonleft.Stroke = Brushes.Black;
            voertuigPolygonleft.StrokeThickness = 1;

            voertuigPolygonleft.Fill = leftColour;

            canvas.Children.Add(voertuigPolygonleft);


            //right
            SolidColorBrush rightColour = new SolidColorBrush();
            rightColour.Color = Colors.Red;
            PointCollection right = new PointCollection();

            right.Add(points[1]);
            right.Add(points[3]);
            right.Add(points[7]);
            right.Add(points[5]);


            //creating polygon shape for side
            Polygon voertuigPolygonright = new Polygon();
            voertuigPolygonright.Points = right;
            voertuigPolygonright.Stroke = Brushes.Black;
            voertuigPolygonright.StrokeThickness = 1;

            voertuigPolygonright.Fill = rightColour;

            canvas.Children.Add(voertuigPolygonright);


            //front
            SolidColorBrush frontColour = new SolidColorBrush();
            frontColour.Color = Colors.Purple;
            PointCollection front = new PointCollection();

            front.Add(points[4]);
            front.Add(points[5]);
            front.Add(points[7]);
            front.Add(points[6]);


            //creating polygon shape for side
            Polygon voertuigPolygonfront = new Polygon();
            voertuigPolygonfront.Points = front;
            voertuigPolygonfront.Stroke = Brushes.Black;
            voertuigPolygonfront.StrokeThickness = 1;

            voertuigPolygonfront.Fill = frontColour;

            canvas.Children.Add(voertuigPolygonfront);


           // //top
           // SolidColorBrush topColour = new SolidColorBrush();
           // topColour.Color = Colors.Aqua;
           // PointCollection top = new PointCollection();

           // top.Add(points[1]);
           // top.Add(points[2]);
           // top.Add(points[4]);
           // top.Add(points[5]);



           //// creating polygon shape for side
           // Polygon voertuigPolygontop = new Polygon();
           // voertuigPolygontop.Points = top;
           // voertuigPolygontop.Stroke = Brushes.Black;
           // voertuigPolygontop.StrokeThickness = 1;

           // voertuigPolygontop.Fill = topColour;

           // canvas.Children.Add(voertuigPolygontop);
        }

        public void naberekening(Matrix3D matrix)
        {
            for(int i=0; i< matrix.matrix[0].Count; i++)
            {
                //de x,y,z en w waardes ophalen
                double x = matrix.matrix[0][i];
                double y = matrix.matrix[1][i];
                double z = matrix.matrix[2][i];
                double w = matrix.matrix[3][i];
                
               
                x = screenSize / 2 + (x + 1) / w * screenSize * 0.5;
                y = screenSize / 2 + (y + 1) / w * screenSize * 0.5;
                z *= -1;

                //de x,y,z en w waardes terug zetten
                matrix.matrix[0][i] = x;
                matrix.matrix[1][i] = y;
                matrix.matrix[2][i] = z;
            }
        }
        

        private Matrix3D getProjectieMatrix()
        {
            //local variables used
            double near = 50;
            double far = 300;
            double fieldOfView = 90;
            double scale = near * Math.Tan(Matrix3D.ConvertToRadians(fieldOfView) * 0.5f);

            List<List<double>> projectieMatrix = new List<List<double>>{
                new List<double> { scale, 0,0,0 }, //x
                new List<double> {0, scale,0,0}, //y
                new List<double> {0,0,-(far + near) / (far-near), -1},  //z
                new List<double> {0,0,-(2 * far * near) / (far - near) ,0}
            };

            return new Matrix3D(projectieMatrix);

        }

        private Matrix3D getCameraMatrix()
        {
            //local variables used
            Vector3D x;
            Vector3D y;
            Vector3D z;

            z = Vector3D.subtract(eye, lookAt);
            z.normalize();
            y = up;
            y.normalize();
            x = Vector3D.uitProduct(y, z);
            x.normalize();
            y = Vector3D.uitProduct(z, x);
            y.normalize();

            List<List<double>> cameraMatrix = new List<List<double>>{
                new List<double> {x.x,x.y,x.z,-1 * Vector3D.inProduct(x, eye) }, //x
                new List<double> {y.x,y.y,y.z,-1 * Vector3D.inProduct(z, eye)}, //y
                new List<double> {z.x,z.y,z.z,-1 * Vector3D.inProduct(y, eye)},  //z
                new List<double> {0,0,0,1}
            };

            return new Matrix3D(cameraMatrix);
        }
    }
}
