using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractals
{
    /// <summary>
    /// Класс, содержащий функционал для создания треугольника Серпинского.
    /// </summary>
    internal class SierpinskiTriangle : BaseParameters
    {
        private Polygon triangle;
        private Canvas drawCanvas;
        private int depthOfRecursion;
        /// <summary>
        /// Переопределенное свойство, отвечающее за глубину рекурсии.
        /// </summary>
        protected override int DepthOfRecursion
        {
            get
            {
                return depthOfRecursion;
            }
            set
            {
                // Проверка на корректность введенного значения.
                if (value > 8 || value < 1)
                {
                    throw new ArgumentException("Значение для треугольника Серпинского не должно превышать 8 и быть меньше 1.");
                }
                depthOfRecursion = value;
            }
        }
        /// <summary>
        /// Конструктор, отвечающий за первый шаг отрисовки треугольника Серпинского.
        /// </summary>
        /// <param name="iterations">Глубина рекурсии.</param>
        /// <param name="drawCanvas">Полотно, на котором будет отрисован фрактал.</param>
        public SierpinskiTriangle(int iterations, Canvas drawCanvas)
        {
            DepthOfRecursion = iterations;
            this.drawCanvas = drawCanvas;
            this.drawCanvas.Children.Clear();
            DrawTriangle(new Point(275, 5), new Point(50, 400), new Point(500, 400), new SolidColorBrush(Colors.Blue));
            DrawFracral(new Point(275, 5), new Point(50, 400), new Point(500, 400), DepthOfRecursion);
        }
        /// <summary>
        /// Переопределенный метод, с помощью которого рекурсивно отрисовывается фрактал.
        /// </summary>
        /// <param name="leftPoint">Первая точка, необходимая для отрисовки.</param>
        /// <param name="rightPoint">Вторая точка, необходимая для отрисовки.</param>
        /// <param name="upperPoint">Третья точка, необходимая для отрисовки.</param>
        /// <param name="iterations">Количество шагов рекурсии.</param>
        protected override void DrawFracral(Point leftPoint, Point rightPoint, Point upperPoint, int iterations)
        {
            // Если глубина рекурсии равна 0, то отрисовка заканчивается.
            if (iterations != 0)
            {
                Point[] points = GetPoints(leftPoint, rightPoint, upperPoint);
                // Отрисовка внутренних треугольников.
                DrawTriangle(points[0], points[1], points[2], new SolidColorBrush(Colors.White));
                // Рекурсивная отрисовка последующих итераций.
                DrawFracral(upperPoint, points[0], points[1], iterations - 1);
                DrawFracral(points[0], leftPoint, points[2], iterations - 1);
                DrawFracral(points[1], points[2], rightPoint, iterations - 1);
            }
        }
        /// <summary>
        /// Отрисовка внутренних треугольников.
        /// </summary>
        /// <param name="firstPoint">Первая точка треугольника.</param>
        /// <param name="secondPoint">Вторая точка треугольника.</param>
        /// <param name="thirdPoint">Третья точка треугольника.</param>
        /// <param name="fillColor">Цвет, которым заливается треугольник.</param>
        private void DrawTriangle(Point firstPoint, Point secondPoint, Point thirdPoint, SolidColorBrush fillColor)
        {
            triangle = new();
            triangle.Fill = fillColor;
            triangle.Points.Add(firstPoint);
            triangle.Points.Add(secondPoint);
            triangle.Points.Add(thirdPoint);
            drawCanvas.Children.Add(triangle);
        }
        /// <summary>
        /// Переопределенный метод возвращаюий массив точек, необходимых для последующих шагов отрисовки.
        /// </summary>
        /// <param name="leftPoint">Первая точка, необходимая для отрисовки.</param>
        /// <param name="rightPoint">Вторая точка, необходимая для отрисовки.</param>
        /// <param name="upperPoint">Третья точка, необходимая для отрисовки.</param>
        /// <returns>Возвращает массив точек типа Point.</returns>
        protected override Point[] GetPoints(Point leftPoint, Point rightPoint, Point upperPoint)
        {
            Point firstPoint = new((leftPoint.X + upperPoint.X) / 2, (leftPoint.Y + upperPoint.Y) / 2);
            Point secondPoint = new Point((rightPoint.X + upperPoint.X) / 2, (rightPoint.Y + upperPoint.Y) / 2);
            Point thirdPoint = new Point((leftPoint.X + rightPoint.X) / 2, (leftPoint.Y + rightPoint.Y) / 2);
            Point[] points = { firstPoint, secondPoint, thirdPoint };
            return points;
        }
    }
}
