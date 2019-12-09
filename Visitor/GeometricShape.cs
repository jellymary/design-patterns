using System;

namespace Visitor
{
    public abstract class GeometricShape
    {
        public abstract string Name { get; }
        public abstract void Accept(IVisitor visitor);
    }

    public class Rectangle : GeometricShape
    {
        public override string Name => "Rectangle";
        public int Width { get; }
        public int Height { get; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);
    }

    public class Triangle : GeometricShape
    {
        public override string Name => "Triangle";
        public int Side { get; }
        public int Base { get; }
        public double Angle { get; }

        public Triangle(int side, int @base, double degrees)
        {
            Side = side;
            Base = @base;
            Angle = Math.PI * degrees / 180.0;
        }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);
    }

    public class Circle : GeometricShape
    {
        public override string Name => "Circle";
        public int Radius { get; }

        public Circle(int radius) => Radius = radius;

        public override void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}