using System;
using System.Collections.Generic;
using System.Drawing;

namespace Visitor
{
    public interface IVisitor
    {
        void Visit(Rectangle rectangle);
        void Visit(Triangle triangle);
        void Visit(Circle circle);
    }

    public class DrawVisitor : IVisitor
    {
        public readonly Dictionary<GeometricShape, List<Point>> Points = new Dictionary<GeometricShape,  List<Point>>();
        private Point StartPoint { get; }
        public DrawVisitor(int x, int y) => StartPoint = new Point(x, y);
        public void Visit(Rectangle rectangle) =>
            Points.Add(rectangle, new List<Point>
            {
                StartPoint,
                new Point(StartPoint.X + rectangle.Width, StartPoint.Y),
                new Point(StartPoint.X + rectangle.Width, StartPoint.Y - rectangle.Height),
                new Point(StartPoint.X, StartPoint.Y - rectangle.Height),
            });

        public void Visit(Triangle triangle)
        {
            var startVectorLength = Math.Sqrt(StartPoint.X * StartPoint.X + StartPoint.Y * StartPoint.Y);
            Points.Add(triangle, new List<Point>
            {
                StartPoint,
                new Point(
                    (int) (Math.Cos(triangle.Angle) * (startVectorLength + triangle.Side)),
                    (int) (Math.Sin(triangle.Angle) * (startVectorLength + triangle.Side))),
                new Point(StartPoint.X + triangle.Base, StartPoint.Y)
            });
        }

        public void Visit(Circle circle) =>
            Points.Add(circle, new List<Point>
            {
                new Point(StartPoint.X + circle.Radius, StartPoint.Y),
                new Point(StartPoint.X - circle.Radius, StartPoint.Y),
                new Point(StartPoint.X, StartPoint.Y - circle.Radius)
            });
    }

    public class GetAreaVisitor : IVisitor
    {
        public readonly Dictionary<GeometricShape, double> Areas = new Dictionary<GeometricShape, double>();

        public void Visit(Rectangle rectangle) => Areas.Add(rectangle, rectangle.Width * rectangle.Height);

        public void Visit(Triangle triangle) => Areas.Add(triangle, 0.5 * triangle.Side * triangle.Base * Math.Sin(triangle.Angle));

        public void Visit(Circle circle) => Areas.Add(circle, Math.PI * circle.Radius * circle.Radius);
    }

    public class GetPerimeterVisitor : IVisitor
    {
        public readonly Dictionary<GeometricShape, double> Parameters = new Dictionary<GeometricShape, double>();

        public void Visit(Rectangle rectangle) => Parameters.Add(rectangle, 2 * (rectangle.Height + rectangle.Width));

        public void Visit(Triangle triangle)
        {
            Parameters.Add(triangle,
                Math.Sqrt(Math.Pow(triangle.Side, 2) + Math.Pow(triangle.Base, 2) -
                          2 * triangle.Side * triangle.Base * Math.Cos(triangle.Angle)));
        }

        public void Visit(Circle circle) => Parameters.Add(circle, 2 * Math.PI * circle.Radius);
    }
}