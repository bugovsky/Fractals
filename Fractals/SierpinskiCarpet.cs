using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractals
{
    /// <summary>
    /// Класс, содержащий функционал для создания ковра Серпинского.
    /// </summary>
    internal class SierpinskiCarpet : BaseParameters
    {
        private Polygon rectangle;
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
                if (value > 5 || value < 1)
                {
                    throw new ArgumentException("Значение для ковра Серпинского не должно превышать 5 и быть меньше 1.");
                }
                depthOfRecursion = value;
            }
        }
        /// <summary>
        /// Конструктор, отвечающий за первый шаг отрисовки ковра Серпинского.
        /// </summary>
        /// <param name="iterations">Глубина рекурсии.</param>
        /// <param name="drawCanvas">Полотно, на котором будет отрисован фрактал.</param>
        public SierpinskiCarpet(int iterations, Canvas drawCanvas)
        {
            DepthOfRecursion = iterations;
            this.drawCanvas = drawCanvas;
            this.drawCanvas.Children.Clear();
            DrawRectangle(80, 0, 405, new SolidColorBrush(Colors.Blue));
            DrawFracral(new Point(80, 0), new Point(0, 0), new Point(0, 405), DepthOfRecursion);
        }
        /// <summary>
        /// Переопределенный метод, с помощью которого рекурсивно отрисовывается фрактал.
        /// </summary>
        /// <param name="firstPoint">Первая точка, необходимая для отрисовки.</param>
        /// <param name="secondPoint">Вторая точка, необходимая для отрисовки.</param>
        /// <param name="thirdPoint">Третья точка, необходимая для отрисовки.</param>
        /// <param name="iterations">Количество шагов рекурсии.</param>
        protected override void DrawFracral(Point firstPoint, Point secondPoint, Point thirdPoint, int iterations)
        {
            // Если глубина рекурсии равна 0, то отрисовка заканчивается.
            if (iterations != 0)
            {
                Point[] points = GetPoints(firstPoint, secondPoint, thirdPoint);
                // Отрисовка внутренних квадратов.
                DrawRectangle((float)points[1].X, (float)points[4].Y, (float)points[6].Y, new SolidColorBrush(Colors.White));
                // Рекурсивная отрисовка последующих итераций.
                DrawFracral(points[0], points[3], points[6], iterations - 1);
                DrawFracral(points[1], points[3], points[6], iterations - 1);
                DrawFracral(points[2], points[3], points[6], iterations - 1);
                DrawFracral(points[0], points[4], points[6], iterations - 1);
                DrawFracral(points[2], points[4], points[6], iterations - 1);
                DrawFracral(points[0], points[5], points[6], iterations - 1);
                DrawFracral(points[1], points[5], points[6], iterations - 1);
                DrawFracral(points[2], points[5], points[6], iterations - 1);
            }
        }
        /// <summary>
        /// Метод, отрисовывающий внутренние квадраты.
        /// </summary>
        /// <param name="xCoordinate">Координата по оси Х.</param>
        /// <param name="yCoordinate">Координата по оси Y.</param>
        /// <param name="sideLength">Длина стороны квадрата.</param>
        /// <param name="fillColor">Цвет, которым заливается квадрат.</param>
        private void DrawRectangle(float xCoordinate, float yCoordinate, float sideLength, SolidColorBrush fillColor)
        {
            rectangle = new();
            rectangle.Fill = fillColor;
            rectangle.Points.Add(new Point(xCoordinate, yCoordinate));
            rectangle.Points.Add(new Point(xCoordinate + sideLength, yCoordinate));
            rectangle.Points.Add(new Point(xCoordinate + sideLength, yCoordinate + sideLength));
            rectangle.Points.Add(new Point(xCoordinate, yCoordinate + sideLength));
            // Нанесение полученного квадрата на полотно.
            drawCanvas.Children.Add(rectangle);
        }
        /// <summary>
        /// Переопределенный метод возвращаюий массив точек, необходимых для последующих шагов отрисовки.
        /// </summary>
        /// <param name="firstPoint">Первая точка, необходимая для отрисовки.</param>
        /// <param name="secondPoint">Вторая точка, необходимая для отрисовки.</param>
        /// <param name="thirdPoint">Третья точка, необходимая для отрисовки.</param>
        /// <returns>Возвращает массив точек типа Point.</returns>
        protected override Point[] GetPoints(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            Point widthPoint = new(0, (float)thirdPoint.Y / 3);
            Point firstPointWithX = new((float)firstPoint.X, 0);
            Point secondPointWithX = new(widthPoint.Y + firstPointWithX.X, 0);
            Point thirdPointWithX = new(widthPoint.Y * 2 + firstPointWithX.X, 0);
            Point firstPointWithY = new(0, secondPoint.Y);
            Point secondPointWithY = new(0, secondPoint.Y + widthPoint.Y);
            Point thirdPointWithY = new(0, secondPoint.Y + widthPoint.Y * 2);
            Point[] points = { firstPointWithX,secondPointWithX,thirdPointWithX,firstPointWithY,
                secondPointWithY,thirdPointWithY,widthPoint };
            return points;
        }
    }
}
