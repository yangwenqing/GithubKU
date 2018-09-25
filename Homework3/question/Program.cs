using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question
{
    public abstract class Shape
    {
        private string myData;
        public Shape(string s)
        {
            Id = s;
        }
        public string Id//类型
        {
            get
            {
                return myData;
            }
            set
            {
                myData = value;
            }
        }
        public abstract double Area//面积，抽象属性
        {
            get;
        }
        public virtual void Draw()//绘制，虚方法
        {
            Console.WriteLine("Draw Shape");
        }
        public override string ToString()//覆盖object的虚方法
        {
            return Id + "Area =" + string.Format("{0:F2}", Area);
        }
    }
    //正方形类
    public class Square:Shape
    {
        private int mySide;
        public Square(int side,string id):base(id)//边长
        {
            mySide = side;
        }
        public override double Area//实现面积
        {
            get
            {
                return mySide * mySide;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw 4 Side:" + mySide);
        }
    }

    //圆类
    public class Circle : Shape
    {
        private int myRadius;//半径
        public Circle(int radius,string id):base(id)
        {
            myRadius = radius;
        }
        public override double Area//实现面积
        {
            get
            {
                return myRadius * myRadius * System.Math.PI;
            }
        }
        public override void Draw()//覆盖绘制方法
        {
            Console.WriteLine("Draw Circle:" + myRadius);
        }
    }
    //长方形类
    public class Rectangle : Shape
    {
        private int myWidth;
        private int myHeight;
        public Rectangle(int width,int height,string id):base(id)  
        {
            myWidth = width;
            myHeight = height;
        }
        public override double Area
        {
            get
            {
                return myHeight * myWidth;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw Rectangle:width({0}),height({1})", myWidth, myHeight);
        }
    }
    //三角形类
    public class Triangle : Shape
    {
        private int mySide1;
        private int mySide2;
        private int mySide3;

        public Triangle(int side1,int side2,int side3,string id):base(id)
        {
            mySide1 = side1;
            mySide2 = side2;
            mySide3 = side3;
        }
        public double Halen
        {
            get
            {
                if ((mySide1 + mySide2) > mySide3 && (mySide2 + mySide3) > mySide1 && (mySide1 + mySide3) > mySide2)
                {
                    return (mySide1 + mySide2 + mySide3) / 2;
                }
                else
                {
                    return 0;
                }
            }
        }
        public override double Area
        {
            get
            {
                return System.Math.Sqrt((Halen * (Halen - mySide1) * (Halen - mySide2) * (Halen - mySide3)));
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw Triangle:{0},{1},{2}", mySide1, mySide2, mySide3);
        }
    }
    //测试
    public class TestClass
    {
        public static void Main()
        {
            Shape[] shapes =
            {
                new Square(8,"Square#1"),
                new Circle(10,"Circle#1"),
                new Rectangle(8,10,"Rectangle#1"),
                new Triangle(7,8,9,"Triangle#1")
            };
            System.Console.WriteLine("Shapes Collection");
            foreach(Shape s in shapes)
            {
                System.Console.WriteLine(s);
            }
        }
    }


}
