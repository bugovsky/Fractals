using System.Windows;

namespace Fractals
{
    /// <summary>
    /// Класс с общими параметрами для всех фракталов.
    /// </summary>
    abstract class BaseParameters
    {
        /// <summary>
        /// Свойство, отвечающее за глубину рекурсии.
        /// </summary>
        protected abstract int DepthOfRecursion { get; set; }
        /// <summary>
        /// Метод, с помощью которого рекурсивно отрисовывается фрактал.
        /// </summary>
        /// <param name="firstPoint">Первая точка, необходимая для отрисовки.</param>
        /// <param name="secondPoint">Вторая точка, необходимая для отрисовки.</param>
        /// <param name="thirdPoint">Третья точка, необходимая для отрисовки.</param>
        /// <param name="iterations">Количество шагов рекурсии.</param>
        protected abstract void DrawFracral(Point firstPoint, Point secondPoint, Point thirdPoint, int iterations);
        /// <summary>
        /// Метод возвращаюий массив точек, необходимых для последующих шагов отрисовки.
        /// </summary>
        /// <param name="firstPoint">Первая точка, необходимая для отрисовки.</param>
        /// <param name="secondPoint">Вторая точка, необходимая для отрисовки.</param>
        /// <param name="thirdPoint">Третья точка, необходимая для отрисовки.</param>
        /// <returns>Возвращает массив точек типа Point.</returns>
        protected abstract Point[] GetPoints(Point firstPoint, Point secondPoint, Point thirdPoint);
    }
}
