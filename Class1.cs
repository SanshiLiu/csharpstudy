using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1 //命名空间ClassLibrary1
{
    public class Class1
    {
        static void Test(object o)
        {
            ClassA a;//声明类A的对象a
            ClassB b;//声明类B的对象b

            if (o is ClassA)//如果o是类A
            {
                Console.WriteLine("o 是类A");
                a = (ClassA)o;//可以把o转化为类A，而不出现异常
            }
            else if (o is ClassB)//如果o是类B
            {
                Console.WriteLine("o is 类B");
                b = (ClassB)o;//可以把o转化为类B，而不出现异常
            }
            else
            {
                Console.WriteLine("o 不是类A，也不是类B.");
                Console.WriteLine("o是{0}", o.GetType());//输出o的类型
            }
        }//定义静态方法Test,参数为任意类，功能是判断传进来的类 is class A/class B or not

            static void Main(string[] args)
        {
            int k = (int)DateTime.Now.DayOfWeek;//获取代表星期几的返回值
            switch (k)
            {
                case (int)Car.LimitedNumbers.Sun: Console.WriteLine("今天是星期日,双号限行"); break;
                case (int)Car.LimitedNumbers.Mon: Console.WriteLine("今天是星期一，双号限行"); break;
                case (int)Car.LimitedNumbers.Tue: Console.WriteLine("今天是星期二，单号限行"); break;
                case (int)Car.LimitedNumbers.Wed: Console.WriteLine("今天是星期三，双号限行"); break;
                case (int)Car.LimitedNumbers.Thi: Console.WriteLine("今天是星期四，单号限行"); break;
                case (int)Car.LimitedNumbers.Fri: Console.WriteLine("今天是星期五，双号限行"); break;
                case (int)Car.LimitedNumbers.Sat: Console.WriteLine("今天是星期六，单号限行"); break;
            }
            Console.ReadLine();
            int m;
            int.TryParse(Console.ReadLine(), out m);//获取代表汽车车型的返回值
            switch (m)
            {
                case (int)Car.TypeOfCar.Mini: Console.WriteLine("车型：微型轿车"); break;
                case (int)Car.TypeOfCar.Small: Console.WriteLine("车型：小型轿车"); break;
                case (int)Car.TypeOfCar.Middle: Console.WriteLine("车型：中级轿车"); break;
                case (int)Car.TypeOfCar.Intermediate: Console.WriteLine("车型：中高级轿车"); break;
                case (int)Car.TypeOfCar.Limousine: Console.WriteLine("车型：高级轿车"); break;
            }
            Console.ReadLine();
            Car car = new Car("BMW");
            //创建实例对象car，名字为“宝马”
            Car[] cartype = new Car[1];
            //创建一维数组，存放了两个对象
            cartype[0] = car;
            //第一个对象——宝马
            cartype[1] = new Car("BenZ");
            //第二个对象——奔驰
            string[] price = new string[] { "high", "medium", "low" };
            //一维数组——价格“高”“中”“低”
            int[] performence = new int[] { 1, 2, 3 };
            //一维数组——性能“1”“2”“3”
            char[] quality = new char[] { 'A', 'B', 'C' };
            //一维数组——质量“A”“B”“C”
            string[,] rank = new string[3, 3] { { "high", "1", "A" }, { "medium", "2", "B" }, { "low", "3", "C" } };
            //多维数组——价格、性能、质量三个一维数组组合成的数组

            //委托——显示转换
            Car.TypeOfCar car_1 = 0;
            Car.TypeOfCar car_2 = (Car.TypeOfCar)3;
            Console.WriteLine(car_1);
            Console.WriteLine(car_2);
            int car_1_value = (int)Car.TypeOfCar.Mini;
            Console.WriteLine(car_1_value);
            Console.ReadLine();


            //委托——隐式转换
            int a = 100;
            long b = a;


            //委托——引用类型之间的转换
            Minicar minicar_01 = new Minicar("Ferraria");
            minicar_01.Name = "法拉利";
            Car car_01 = minicar_01; //隐式转换
            Car car_02 = new Car("Audi");
            car_02.Name = "奥迪";
            Minicar minicar_02 = (Minicar)car_02;//显示转换
            Console.WriteLine(minicar_02.Name);
            //Minicar minicar_03 = (Minicar)car_02; // 错误：转换失败！

            Minicar[] MC1 = new Minicar[] { minicar_01, minicar_02 };
            Car[] CC1 = MC1;
            Minicar[] MC2 = (Minicar[])CC1;
            Console.ReadLine();


            //泛型类--stack<T>实例化
            MyList<int> list = new MyList<int>();//使用泛型类MyList<T>，来创建一个整数表
            for (int q = 0; q < 10; q++)//通过简单地改变参数的类型
                list.AddHead(q);//以创建字符串或其他自定义类型的表

            foreach (int p in list)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Done");
            
            
            //操作符
            bool[] x = new bool[5];
            Console.WriteLine("请依次输入5位考官的评分，1通过，0不通过: ");
            x[0] = (Console.ReadLine() == "1");
            x[1] = (Console.ReadLine() == "1");
            x[2] = (Console.ReadLine() == "1");
            x[3] = (Console.ReadLine() == "1");
            x[4] = (Console.ReadLine() == "1");
            int i = 0;
            bool result = (x[i++]) && (x[i++] || x[i]) && (x[++i] || x[++i]);
            Console.WriteLine("考核结果为: {0}", result);
            Console.WriteLine("判断次数为: {0}", i); 
            Console.ReadLine();

            //as操作符
            object[] objArray = new object[6];//定义数组，该数组的长度为6，包含的数据类型为object
            objArray[0] = new ClassA();//第1个元素被赋予类A的一个对象
            objArray[1] = new ClassB();//第2个元素被赋予类B的一个对象
            objArray[2] = "hello";//第3个元素被赋予字符串
            objArray[3] = 123;//第4个元素被赋予整型数据
            objArray[4] = 123.4;//第5个元素被赋予浮点数
            objArray[5] = null;//第6个元素被赋予空

            for (int j = 0; j < objArray.Length; ++j)//遍历数组objArray
            {
                string s = objArray[j] as string;//把数组元算转换为字符串
                Console.Write("{0}:", j);//输出该元算
                if (s != null)//如果转换结果不为空
                {
                    Console.WriteLine("'" + s + "'");//输出转换结果
                }
                else//否则
                {
                    Console.WriteLine("不是字符串");
                }
            }
            Console.ReadKey();



            //is操作符
            ClassA a1 = new ClassA();//声明类A的对象a1
            ClassB b2 = new ClassB();//声明类B的对象b1
            Test(a1);
            Test(b2);
            Test("a string");
            Console.ReadKey();
        }  //主函数
    }//测试类
    abstract class Travel    //定义抽象类，表示交通工具
    {
        protected string _name;//交通工具的名称
        public abstract string Name    //定义抽象属性，表示交通工具的名称
        {
            get;
            set;
        }
        public void Show()//定义一般方法，用来显示是何种交通工具
        {
            Console.WriteLine("这是{0}", _name);
        }
        public abstract void GetWheel();//获取轮子的数量
    }
    interface IProduction    //定义接口，表示生产行为
    {
        //注意这个方法同同抽象类中的方法GetWheel的区别
        //任何产品都需要生产行为，而只有交通工具才有轮子
        void Product();

        // public int year;
        // public int month;
        // public int date;
        // public int week;
        // public char place;
        // public char factory;

    }
    class Car : Travel, IProduction
    {
        public int Year, Price;                       //使用时间，车价
        public double Range;                         //车牌号码,车程
        public bool IfPassInspection, IfIsUsed;       //是否通过车检，是否二手车
        public string Brand, Licenceplates;           //汽车品牌名字，车牌号
        public enum LimitedNumbers
        {
            Sun = 0,
            Mon = 1,
            Tue = 2,
            Wed = 3,
            Thi = 4,
            Fri = 5,
            Sat = 6
        }                //枚举类型——限号（星期）
        public enum TypeOfCar
        {
            Mini = 0,
            Small = 1,
            Middle = 2,
            Intermediate = 3,
            Limousine = 4
        }                     //枚举类型——车型（按排量分类）
        public override string Name   //重写抽象类属性
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public Car(String name)
        {
            _name = name;
        }
        public void Product()//实现接口方法 
        {
            Console.WriteLine("这辆车的生产地为：");
            Console.WriteLine("生产商为：");
            Console.WriteLine("生产日期为：");
        }


        public override void GetWheel()//重写抽象类方法
        {
            Console.WriteLine("汽车有4个轮子");
        }
    }   //定义汽车类
    class Minicar : Car
    {

        public Minicar(string name) : base(name)
        {
            this._name = name;
        }
    }//定义继承Car类的Minicar类
    public class MyList<T>
    {
        private Node head;
        // The nested type is also generic on T.
        private class Node
        {
            private Node next;
            //T as private member data type:
            private T data;
            //T used in non-generic constructor:
            public Node(T t)
            {
                next = null;
                data = t;
            }
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            //T as return type of property:
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }
        public MyList()
        {
            head = null;
        }
        //T as method parameter type:
        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    } //定义泛型类MyList<T>
    class ClassA
    {
    }//定义类A
    class ClassB
    {
    }//定义类B

}









