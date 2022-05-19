
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Fractals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор, отвечающий за построение пользовательского интерфейса.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод, активирующий поле для ввода глубины рекурсии.
        /// </summary>
        /// <param name="sender">Объекты класса RadioButton.</param>
        /// <param name="e">Событие, активирующее поле для ввода после нажатия на RadioButton.</param>
        private void ActivateInput(object sender, RoutedEventArgs e)
        {
            iterations.Text = string.Empty;
            iterations.IsEnabled = true;
        }
        /// <summary>
        /// Метод вызывающий подсказку для пользователя по нажатию 
        /// кнопки.
        /// </summary>
        /// <param name="sender">Объектом является кнпока.</param>
        /// <param name="e">Событие, срабатаывающее по нажатию кнопки.</param>
        private void ShowInfo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Чтобы нарисовать фрактал, выберите тип фрактала и введите глубину рекурсии\n" +
                "Глубина рекурсии устанавливается (включая границы):\nдля кривой Коха от 1 до 7 \n" +
                "для ковра Серпинского от 1 до 5\nдля треугольника Серпинского от 1 до 8",
                "Информация для пользователя", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Метод, получающий на вход массив типа RadioButton,
        /// возвращающий индекс активной кнопки.
        /// </summary>
        /// <returns>Индекс активной кнопки.</returns>
        private int GetNumberOfButton()
        {
            RadioButton[] radioButtons = { curve, carpet, triangle };
            int number = -1;
            for (int i = 0; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].IsChecked == true)
                {
                    number = i;
                    break;
                }
            }
            return number;
        }
        /// <summary>
        /// Метод, проверяющий изменение текста в поле для ввода глубины
        /// рекурсии.
        /// </summary>
        /// <param name="sender">Объектом является TextBox.</param>
        /// <param name="e">Событие, вызываемое при изменении текста.</param>
        private void ValueChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (iterations.Text == string.Empty)
                {
                    return;
                }
                // Проверка на корректный ввод.
                if (!int.TryParse(iterations.Text, out int number) || iterations.Text.Contains('-'))
                {
                    throw new ArgumentException("Вы ввели недопустимое значение!");
                }
                // Проверка на корректный ввод.
                if (iterations.Text.Length >= 2)
                {
                    throw new ArgumentException("Глубина рекурсии некорректна для данного фрактала!");
                }
                // Создание фрактала после ввода корректного значения.
                switch (GetNumberOfButton())
                {
                    case 0:
                        KochCurve kochCurve = new(int.Parse(iterations.Text), drawCanvas);
                        break;
                    case 1:
                        SierpinskiCarpet serpinskiCarpet = new(int.Parse(iterations.Text), drawCanvas);
                        break;
                    case 2:
                        SierpinskiTriangle serpinskiTriange = new(int.Parse(iterations.Text), drawCanvas);
                        break;
                }
            }
            catch (ArgumentException exception)
            {
                // Сообщение, которое получит пользователь при некорректном вводе.
                MessageBox.Show(exception.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                iterations.Text = string.Empty;
            }
        }
    }
}
