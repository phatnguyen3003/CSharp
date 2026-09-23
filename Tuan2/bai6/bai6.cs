using SharedLibs;
using System;
using System.Collections;

namespace Tuan2
{
    public class ArrayPoint
    {
        private ArrayList points;   //field

        public ArrayPoint() //constructor
        {
            points = new ArrayList();
        }

        public void Add(Point p)
        {
            points.Add(p);
        }

        public int count
        {
            get
            {
                return points.Count;
            }
        }


        public Point this[int i]    //indexer
        {
            get
            {
                if (i < 0 || i >= points.Count)
                {
                    throw new IndexOutOfRangeException("Chi so vuot qua gioi han cua ArrayList");
                }
                return (Point)points[i];
            }
            set
            {
                if (i < 0 || i >= points.Count)
                {
                    throw new IndexOutOfRangeException("Chi so vuot qua gioi han cua ArrayList");
                }
                points[i] = value;
            }
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            ArrayPoint arrayPoint = new ArrayPoint();

            arrayPoint.Add(new Point(1, 2));
            arrayPoint.Add(new Point(3, 4));

            Point p1 = arrayPoint[0];
            Console.WriteLine($"Point tại vị trí 0: X = {p1.X}, Y = {p1.Y}");

            arrayPoint[1] = new Point(10, 20);
            Console.WriteLine($"Point tại vị trí 1 sau khi sửa: X = {arrayPoint[1].X}, Y = {arrayPoint[1].Y}");
        }
    }
}