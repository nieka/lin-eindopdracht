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

        private double screenSize = 525;

        public controller(Canvas canvas)
        {
            this.canvas = canvas;

            //List<List<double>> voertuigMatrix = new List<List<double>>{
            //    new List<double> {1,50 ,1,50 ,1,50 ,1,50}, //x
            //    new List<double> {1,1 ,50,50 ,1,1 ,50,50}, //y
            //    new List<double> {1,1 ,1,1 ,50,1 ,50,50}  //z
            //};

            List<List<double>> voertuigMatrix = new List<List<double>>{
                new List<double> {40,40,70,70, 40,70,70,40}, //x
                new List<double> {40,70,70,40, 40,40,70,70}, //y
                new List<double> {40,40,40,40, 70,40,70,70}  //z
            };

            voertuig = new Matrix3D(voertuigMatrix);

            eye = new Vector3D(20, 20, 20);
            lookAt = new Vector3D(5, 5, 5);
            up = new Vector3D(0, 1, 0);

            draw();
        }

        public void draw()
        {
            //used matrixed 
            Matrix3D cameraMatrix = getCameraMatrix();
            Matrix3D projectieMatrix = getProjectieMatrix();

            Matrix3D temp = new Matrix3D(null);

            //drawig voertuig
             voertuig.matrix.Add(new List<double> { 1,1,1,1,1,1,1,1});
          //voertuig.matrix.Add(new List<double> { 1,1});
            voertuig.matrix = Matrix3D.vermenigvuldig(Matrix3D.vermenigvuldig(projectieMatrix.matrix, cameraMatrix.matrix),voertuig.matrix);
            naberekening(voertuig);

            //draw everthing
            canvas.Children.Clear();
            
            //drawing voertuig
            PointCollection voertuigPointCollection = new PointCollection();
            //adding the point to voertuigPointCollection
            for (int i = 0; i < voertuig.matrix[0].Count; i++)
            {
                //de x,y,z en w waardes ophalen
                double x = voertuig.matrix[0][i];
                double y = voertuig.matrix[1][i];
                double z = voertuig.matrix[2][i];
                double w = voertuig.matrix[3][i];

                //if w is smaller then 0 we don't need to draw it
                voertuigPointCollection.Add(new Point(x, y));
            }

            Polygon voertuigPolygon = new Polygon();
            voertuigPolygon.Points = voertuigPointCollection;
            voertuigPolygon.Stroke = Brushes.Black;
            voertuigPolygon.StrokeThickness = 1;
            canvas.Children.Add(voertuigPolygon);

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
            double near = 5;
            double far = 50;
            double fieldOfView = 90;
            double scale = near * Math.Tan(Matrix3D.ConvertToRadians(fieldOfView) * 0.5);

            List<List<double>> projectieMatrix = new List<List<double>>{
                new List<double> { scale, 0,0,0 }, //x
                new List<double> {0, scale,0,0}, //y
                new List<double> {0,0,(-1 * far) / (far-near), -1},  //z
                new List<double> {0,0,(-1 * far) * near / (far - near) ,0}
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
