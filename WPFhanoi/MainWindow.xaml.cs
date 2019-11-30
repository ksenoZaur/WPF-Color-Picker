using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFhanoi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            InitOne();
        }

        private void InitOne()
        {
            int[] redGrenBlue  =  new int[]{ 255, 0 , 0};
            SolidColorBrush scd = new SolidColorBrush();
            
            int step = 1;        // Изменяем величину цвета с таким шагом
            int direction = 1;   // Направление изменения + или -
            int colorIndex = 1;  // Индекс компоненты, которую изменяем

            int counter = 0;
            do
            {

                do
                {
                    scd.Color = new Color()
                    {
                        R = (byte)redGrenBlue[0],
                        G = (byte)redGrenBlue[1],
                        B = (byte)redGrenBlue[2]
                    };

                    switch (direction)
                    {
                        case 1: 
                            redGrenBlue[colorIndex] = redGrenBlue[colorIndex] + (byte) (step);
                            break;
                        case -1:
                            redGrenBlue[colorIndex] = redGrenBlue[colorIndex] - (byte) (step);
                            break;
                    }
                    
                    
                    Debug.WriteLine(string.Format("{0},{1},{2}", redGrenBlue[0], redGrenBlue[1], redGrenBlue[2]));
                    
                } while (direction > 0 && redGrenBlue[colorIndex] < 256
                         || direction < 0 && redGrenBlue[colorIndex] > -1);

                // Меняем напрвление
                direction *= -1;
                
                // Ищем первый наибольший столбец, который будем уменьшать
                switch (direction)
                {
                    case  1 :
                        for(int i = 0; i < 3; i++)
                        {
                            if (redGrenBlue[i] == 0)
                            {
                                colorIndex = i;
                                break;
                            }
                        }
                        break;
                    case -1 : 
                        for(int i = 0; i < 3; i++)
                        {
                            if (redGrenBlue[i] == 255)
                            {
                                colorIndex = i;
                                break;
                            }
                        }
                        break;
                }
                
                // Нормируем
                for(int i = 0; i < 3; i++)
                {
                    if (redGrenBlue[i] < 0)
                    {
                        redGrenBlue[i] = 0;
                    } else if (redGrenBlue[i] > 255)
                    {
                        redGrenBlue[i] = 255;
                    }
                }

                counter++;
            } while (counter <= 5);
        }

        public void cmd_Exit(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void cmd_CanExit(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
}
}