using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicalForFun
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Five1();
            Five2();
        }

        public void Five1() 
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Jesper\source\repos\AdventOfCode2021\AdventOfCode2021\Inputs\Five.txt");
            foreach (string line in lines)
            {
                Line d_line = new Line() { Stroke = Brushes.LightSteelBlue, StrokeThickness = 1, X1 = int.Parse(line.Split(",")[0]), Y1 = int.Parse(line.Split(" -> ")[0].Split(",")[1]), X2 = int.Parse(line.Split(" -> ")[1].Split(",")[0]), Y2 = int.Parse(line.Split(" -> ")[1].Split(",")[1]) };
                if (d_line.X1 == d_line.X2 || d_line.Y1 == d_line.Y2)
                    D5Canvas.Children.Add(d_line);
            }
        }
        public void Five2()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Jesper\source\repos\AdventOfCode2021\AdventOfCode2021\Inputs\Five.txt");
            foreach (string line in lines)
            {
                Line d_line = new Line() { Stroke = Brushes.LightSteelBlue, StrokeThickness = 1, X1 = int.Parse(line.Split(",")[0]), Y1 = int.Parse(line.Split(" -> ")[0].Split(",")[1]), X2 = int.Parse(line.Split(" -> ")[1].Split(",")[0]), Y2 = int.Parse(line.Split(" -> ")[1].Split(",")[1]) };
                D5Canvas.Children.Add(d_line);
            }
        }
    }
}
