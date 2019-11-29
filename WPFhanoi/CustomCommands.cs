using System.Windows.Input;

namespace WPFhanoi
{
    /// <summary>
    /// Содержит собственные комманды
    /// </summary>
    public static class CustomCommands
    {
        // Зыкрыть приложение
        public static RoutedUICommand Exit = new RoutedUICommand(
            "Exit",
            "Exit",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F4, ModifierKeys.Alt)
            }
            );
    }
}