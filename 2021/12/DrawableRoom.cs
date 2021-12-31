using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _12
{
    public class DrawableRoom
    {
        private const int padding = 20;
        private const int width = 50;
        private const int height = 20;

        private Room _room;
        private Ellipse _ellipse;
        private TextBlock _text;

        public DrawableRoom(Room room, Canvas canvas)
        {
            _room = room;

            _ellipse = new Ellipse
            {
                Stroke = new SolidColorBrush(room.Large ? Colors.Black : Colors.Gray),
                Fill = new SolidColorBrush(Colors.LightGray),
                Width = width,
                Height = height
            };

            _text = new TextBlock
            {
                Width = width,
                Height = height,
                Text = room.Id,
                FontWeight = room.Large ? FontWeights.Bold : FontWeights.Normal,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            UpdatePosition(0, 0);

            canvas.Children.Add(_ellipse);
            canvas.Children.Add(_text);
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public void UpdatePosition(int x, int y)
        {
            X = x;
            Y = y;

            Canvas.SetLeft(_ellipse, X * (width + padding));
            Canvas.SetTop(_ellipse, Y * (height + padding));

            Canvas.SetLeft(_text, X * (width + padding));
            Canvas.SetTop(_text, Y * (height + padding));
        }
    }
}
