using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace lin_eindopdracht
{
    class controller
    {
        private Canvas canvas;

        //entiteiten
        private voertuig voertuig;
        private Monster monster;
        private List<Kogel> kogels;

        //vairable for drawing 
        private Vector3D eye;
        private Vector3D lookAt;
        private Vector3D up;

        private double screenSize;

        public controller(Canvas canvas)
        {
            this.canvas = canvas;
            screenSize = canvas.Width;

            kogels = new List<Kogel>();

            voertuig = new voertuig(0, 0,0);
            monster = new Monster(-200, -200, -200, canvas.Width, canvas.Height);

            eye = new Vector3D(200, 200, 200);
            lookAt = new Vector3D(0, 0, 0);
            up = new Vector3D(0, 1, 0);
        }

        public void update()
        {
            monster.grow();
            //check if the bullets need to be removed
            for(int i=0; i< kogels.Count; i++)
            {
                Kogel kogel = kogels[i];
                if(kogel.liveSpan == 100)
                {
                    //remove bullet
                    kogels.Remove(kogel);
                }
            }
            draw();
        }

        public void draw()
        {
            //used matrixed 
            Matrix3D cameraMatrix = getCameraMatrix();
            Matrix3D projectieMatrix = getProjectieMatrix();

            //matrix used to transform the 3d points to matrix with are correctly shown in 2d
            Matrix3D convertMatrix = new Matrix3D(Matrix3D.vermenigvuldig(projectieMatrix.matrix, cameraMatrix.matrix));

            //clear canvas
            canvas.Children.Clear();

            //draw voertuig
            Matrix3D tempVoertuigMatrix = new Matrix3D(voertuig.matrix.matrix);
            tempVoertuigMatrix.matrix.Add(new List<double> { 1, 1, 1, 1, 1, 1, 1, 1 });
            tempVoertuigMatrix.matrix = Matrix3D.vermenigvuldig(convertMatrix.matrix, tempVoertuigMatrix.matrix);
            naberekening(tempVoertuigMatrix);
            drawMatrix(tempVoertuigMatrix.matrix);
            voertuig.matrix.matrix.RemoveAt(voertuig.matrix.matrix.Count - 1);

            //draw monster
            Matrix3D tempMonsterMatrix = new Matrix3D(monster.matrix.matrix);
            tempMonsterMatrix.matrix.Add(new List<double> { 1, 1, 1, 1, 1, 1, 1, 1 });
            tempMonsterMatrix.matrix = Matrix3D.vermenigvuldig(convertMatrix.matrix, tempMonsterMatrix.matrix);
            naberekening(tempMonsterMatrix);
            drawMatrix(tempMonsterMatrix.matrix);
            monster.matrix.matrix.RemoveAt(monster.matrix.matrix.Count - 1);

            //draw help schiet lijn
            Matrix3D tempLijnMatrix = voertuig.getShootLine();
            tempLijnMatrix.matrix.Add(new List<double> { 1, 1 });
            tempLijnMatrix.matrix = Matrix3D.vermenigvuldig(convertMatrix.matrix, tempLijnMatrix.matrix);
            naberekening(tempLijnMatrix);
            drawLine(tempLijnMatrix.matrix, Brushes.LightSteelBlue);

            //draw kogels
            foreach (Kogel kogel in kogels)
            {
                Matrix3D tempKogelMatrix = kogel.getKogelMatrix();
                tempKogelMatrix.matrix.Add(new List<double> { 1, 1 });
                tempKogelMatrix.matrix = Matrix3D.vermenigvuldig(convertMatrix.matrix, tempKogelMatrix.matrix);
                naberekening(tempKogelMatrix);
                drawLine(tempKogelMatrix.matrix, Brushes.Red);
            }

        }

        public void logMatrix(Matrix3D tempVoertuigMatrix)
        {
            Console.WriteLine("-------------------x waardes -----------------");
            for (int i = 0; i < tempVoertuigMatrix.matrix[0].Count; i++)
            {
                Console.WriteLine(tempVoertuigMatrix.matrix[0][i]);
            }
            Console.WriteLine("-------------------y waardes -----------------");
            for (int i = 0; i < tempVoertuigMatrix.matrix[1].Count; i++)
            {
                Console.WriteLine(tempVoertuigMatrix.matrix[1][i]);
            }
            Console.WriteLine("-------------------z waardes -----------------");
            for (int i = 0; i < tempVoertuigMatrix.matrix[2].Count; i++)
            {
                Console.WriteLine(tempVoertuigMatrix.matrix[2][i]);
            }
            Console.WriteLine("-------------------w waardes -----------------");
            for (int i = 0; i < tempVoertuigMatrix.matrix[3].Count; i++)
            {
                Console.WriteLine(tempVoertuigMatrix.matrix[3][i]);
            }
        }
    
        public void move(Key k)
        {
            int moveValue = 5;
            switch (k)
            {
                case Key.Up:
                    //move up
                    voertuig.matrix.transleer(0, -moveValue, 0);
                    break;
                case Key.Down:
                    //move back
                    voertuig.matrix.transleer(0, moveValue, 0);
                    break;
                case Key.Left:
                    //move left
                    voertuig.matrix.transleer(-moveValue, 0, 0);
                    break;
                case Key.Right:
                    //move right
                    voertuig.matrix.transleer(moveValue, 0, 0);
                    break;
                case Key.Q:
                    voertuig.matrix.rotatedSelf(moveValue, RotateType.XAS);
                    break;
                case Key.E:
                    voertuig.matrix.rotatedSelf(-moveValue, RotateType.XAS);
                    break;
                case Key.Space:
                    kogels.Add(new Kogel(voertuig.getRichtingsVector(), new Vector3D((float)voertuig.matrix.matrix[0][1], (float)voertuig.matrix.matrix[1][1], (float)voertuig.matrix.matrix[2][1])));
                    break;
            }
           
        }
       
        public void drawLine(List<List<double>> list,Brush brush)
        {
            Line line = new Line();
            line.Stroke = brush;

            line.X1 = list[0][0];
            line.X2 = list[0][1];
            line.Y1 = list[1][0];
            line.Y2 = list[1][1];

            line.StrokeThickness = 2;
            canvas.Children.Add(line);
        }

        public void drawMatrix(List<List<double>> list)
        {
            PointCollection points = new PointCollection();

            //adding the point to voertuigPointCollection
            for (int i = 0; i < voertuig.matrix.matrix[0].Count; i++)
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
            bottom.Add(points[2]);
            bottom.Add(points[3]);
            bottom.Add(points[7]);
            bottom.Add(points[6]);

            //creating polygon shape for side
            Polygon voertuigPolygonBottom = new Polygon();
            voertuigPolygonBottom.Points = bottom;
            voertuigPolygonBottom.Stroke = Brushes.Black;
            voertuigPolygonBottom.StrokeThickness = 1;

            voertuigPolygonBottom.Fill = botColour;

            canvas.Children.Add(voertuigPolygonBottom);


            //right
            SolidColorBrush rightColour = new SolidColorBrush();
            rightColour.Color = Colors.Blue;
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
            frontColour.Color = Colors.Blue;
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


            //left
            SolidColorBrush leftColour = new SolidColorBrush();
            leftColour.Color = Colors.Blue;
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


            //back
            SolidColorBrush backColour = new SolidColorBrush();
            backColour.Color = Colors.Blue;
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


            // //top
            SolidColorBrush topColour = new SolidColorBrush();
            topColour.Color = Colors.Blue;
            PointCollection top = new PointCollection();

            top.Add(points[1]);
            top.Add(points[0]);
            top.Add(points[4]);
            top.Add(points[5]);

            // creating polygon shape for side
            Polygon voertuigPolygontop = new Polygon();
            voertuigPolygontop.Points = top;
            voertuigPolygontop.Stroke = Brushes.Black;
            voertuigPolygontop.StrokeThickness = 1;

            voertuigPolygontop.Fill = topColour;

            canvas.Children.Add(voertuigPolygontop);
            //bottom
            SolidColorBrush testColour = new SolidColorBrush();
            testColour.Color = Colors.Red;

            PointCollection test = new PointCollection();
            test.Add(new Point(list[0][1], list[1][1]));
            test.Add(new Point(list[0][0], list[1][0]));


            //creating polygon shape for side
            Polygon testBottom = new Polygon();
            testBottom.Points = test;
            testBottom.Stroke = Brushes.Red;
            testBottom.StrokeThickness = 1;

            testBottom.Fill = testColour;

            canvas.Children.Add(testBottom);
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
                
               if(w == 0)
                {
                    w = 1;
                }
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
                new List<double> {0,0,-far / (far-near), -1},  //z
                new List<double> {0,0,(-far * near) / (far - near) ,0}
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
