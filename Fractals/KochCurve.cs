using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractals
{
    /// <summary>
    /// Класс, содержащий функционал для создания кривой Коха.
    /// </summary>
    internal class KochCurve : BaseParameters
    {
        private Line segment;
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
                if (value > 7 || value < 1)
                {
                    throw new ArgumentException("Значение для кривой Коха не должно превышать 7 и быть меньше 1.");
                }
                else
                    depthOfRecursion = value;
            }
        }
        /// <summary>
        /// Конструктор, отвечающий за первый шаг отрисовки треугольника Серпинского.
        /// </summary>
        /// <param name="iterations">Глубина рекурсии.</param>
        /// <param name="drawCanvas">Полотно, на котором будет отрисован фрактал.</param>
        public KochCurve(int iterations, Canvas drawCanvas)
        {
            DepthOfRecursion = iterations;
            this.drawCanvas = drawCanvas;
            this.drawCanvas.Children.Clear();
            DrawFracral(new Point(10, 250), new Point(530, 250), new Point(250, 640), DepthOfRecursion);
        }
        /// <summary>
        /// Переопределенный метод, с помощью которого рекурсивно отрисовывается фрактал.
        /// </summary>
        /// <param name="leftPoint">Первая точка, необходимая для отрисовки.</param>
        /// <param name="rightPoint">Вторая точка, необходимая для отрисовки.</param>
        /// <param name="dividePoint">Третья точка, необходимая для отрисовки.</param>
        /// <param name="iterations">Количество шагов рекурсии.</param>
        protected override void DrawFracral(Point leftPoint, Point rightPoint, Point dividePoint, int iterations)
        {
            Point[] points = GetPoints(leftPoint, rightPoint, dividePoint);
            if (iterations == DepthOfRecursion)
            {
                // Отрисовка отрезков.
                DrawSegment(leftPoint, points[0], new SolidColorBrush(Colors.Black), 1);
                DrawSegment(points[0], points[2], new SolidColorBrush(Colors.Black), 1);
                DrawSegment(points[1], points[2], new SolidColorBrush(Colors.Black), 1);
                DrawSegment(rightPoint, points[1], new SolidColorBrush(Colors.Black), 1);
            }
            else if (iterations > 0)
            {
                // Отрисовка отрезков.
                DrawSegment(points[0], points[2], new SolidColorBrush(Colors.Black), 1);
                DrawSegment(points[1], points[2], new SolidColorBrush(Colors.Black), 1);
                DrawSegment(points[1], points[0], new SolidColorBrush(Colors.White), 3);
            }
            if (iterations == 1)
            {
                return;
            }
            // Рекурсивная отрисовка.
            DrawFracral(points[0], points[2], points[1], iterations - 1);
            DrawFracral(points[2], points[1], points[0], iterations - 1);
            DrawFracral(leftPoint, points[0], points[3], iterations - 1);
            DrawFracral(points[1], rightPoint, points[4], iterations - 1);
        }
        /// <summary>
        /// Методм, отрисовывающий отрезки.
        /// </summary>
        /// <param name="leftPoint">Первая точка отрезка.</param>
        /// <param name="rightPoint">Вторая точка отрезка.</param>
        /// <param name="strokeColor">Цвет отрезка.</param>
        /// <param name="thickness">Толщина отрезка.</param>
        private void DrawSegment(Point leftPoint, Point rightPoint, SolidColorBrush strokeColor, int thickness)
        {
            segment = new();
            segment.X1 = leftPoint.X;
            segment.Y1 = leftPoint.Y;
            segment.X2 = rightPoint.X;
            segment.Y2 = rightPoint.Y;
            segment.Stroke = strokeColor;
            segment.StrokeThickness = thickness;
            drawCanvas.Children.Add(segment);
        }
        /// <summary>
        /// Метод возвращаюий массив точек, необходимых для последующих шагов отрисовки.
        /// </summary>
        /// <param name="leftPoint">Первая точка, необходимая для отрисовки.</param>
        /// <param name="rightPoint">Вторая точка, необходимая для отрисовки.</param>
        /// <param name="dividePoint">Третья точка, необходимая для отрисовки.</param>
        /// <returns>Возвращает массив точек типа Point.</returns>
        protected override Point[] GetPoints(Point leftPoint, Point rightPoint, Point dividePoint)
        {
            Point firstPoint = new((rightPoint.X + 2 * leftPoint.X) / 3,
                (rightPoint.Y + 2 * leftPoint.Y) / 3);
            Point secondPoint = new((2 * rightPoint.X + leftPoint.X) / 3,
                (leftPoint.Y + 2 * rightPoint.Y) / 3);
            Point helpPoint = new((rightPoint.X + leftPoint.X) / 2, (rightPoint.Y + leftPoint.Y) / 2);
            Point thirdPoint = new((4 * helpPoint.X - dividePoint.X) / 3,
                (4 * helpPoint.Y - dividePoint.Y) / 3);
            Point fourthPoint = new((2 * leftPoint.X + dividePoint.X) / 3,
                (2 * leftPoint.Y + dividePoint.Y) / 3);
            Point fifthPoint = new((2 * rightPoint.X + dividePoint.X) / 3,
                (2 * rightPoint.Y + dividePoint.Y) / 3);
            Point[] points = { firstPoint, secondPoint, thirdPoint, fourthPoint, fifthPoint };
            return points;
        }
    }
}
