using static Microsoft.Maui.ApplicationModel.Permissions;

namespace _15.Visualizer
{
    // All the code in this file is included in all platforms.
    public class SensorGridRenderer
        : IDrawable
    {
        private readonly int _sampleLine;

        public SensorGridRenderer(SensorGrid sensorGrid, int sampleLine)
        {
            SensorGrid = sensorGrid;
            _sampleLine = sampleLine;
            var window = new Window
            {
                Page = new ContentPage
                {
                    Content = new GraphicsView
                    {
                        Drawable = this
                    }
                }
            };

            Application.Current.OpenWindow(window);
        }

        public SensorGrid SensorGrid { get; }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            var scaleFactor = 1080 / (float)Math.Abs(SensorGrid.MaxY - SensorGrid.MinY);
            var xOffset = 10 + (float)Math.Abs(SensorGrid.MinX * scaleFactor);
            var yOffset = 10 + (float)Math.Abs(SensorGrid.MinY * scaleFactor);

            if (_sampleLine < 100)
            {
                canvas.StrokeSize = 1;
                canvas.StrokeDashPattern = new float[] { 2, 2 };

                var lightBlue = new Color(0, 128, 255, 128);
                var darkBlue = new Color(0, 0, 255, 128);

                for (int i = -10; i < 40; i++)
                {
                    canvas.StrokeColor = i % 5 == 0 ? darkBlue : lightBlue;

                    var position = i * scaleFactor;

                    canvas.DrawLine(xOffset + position, 0, xOffset + position, 1080);
                    canvas.DrawLine(0, yOffset + position, 1920, yOffset + position);
                }
            }

            foreach (var sensor in SensorGrid.Sensors)
            {
                DrawSensor(canvas, sensor, scaleFactor, xOffset, yOffset);
            }

            canvas.StrokeColor = new Color(255, 0, 0, 128);
            canvas.StrokeSize = 4;
            canvas.StrokeDashPattern = new float[] { 2, 2 };
            canvas.DrawLine(0, yOffset + _sampleLine * scaleFactor, 1920, yOffset + _sampleLine * scaleFactor);
        }

        public void DrawSensor(ICanvas canvas, Sensor sensor, float scaleFactor, float xOffset, float yOffset)
        {
            var polygon = new PathF();
            bool first = true;
            foreach (var line in sensor.Polygon)
            {
                if (first)
                {
                    polygon.MoveTo(xOffset + (float)line.Start.X * scaleFactor, yOffset + (float)line.Start.Y * scaleFactor);
                    first = false;
                }

                polygon.LineTo(xOffset + (float)line.End.X * scaleFactor, yOffset + (float)line.End.Y * scaleFactor);
            }

            polygon.Close();
            canvas.StrokeColor = canvas.FillColor = new Color(Random.Shared.Next(255), Random.Shared.Next(255), Random.Shared.Next(255), 128);
            canvas.FillPath(polygon);
        }
    }
}