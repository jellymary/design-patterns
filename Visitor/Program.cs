using System;
using System.Linq;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new GeometricShape[] {
                new Rectangle(10, 5), 
                new Triangle(4, 6, 30), 
                new Circle(4)
            };

            var drawVisitor = new DrawVisitor(0, 0);
            var areaVisitor = new GetAreaVisitor();
            var parameterVisitor = new GetPerimeterVisitor();

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.Name);
                shape.Accept(drawVisitor);
                Console.WriteLine($"Points = {string.Join(", ", drawVisitor.Points[shape])}");
                shape.Accept(areaVisitor);
                Console.WriteLine($"Area = {areaVisitor.Areas[shape]}");
                shape.Accept(parameterVisitor);
                Console.WriteLine($"Parameter = {parameterVisitor.Parameters[shape]}");
                Console.WriteLine();
            }
            ;
            
        }
    }
}