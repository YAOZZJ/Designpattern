using System;

namespace _06_原型模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        static void Run()
        {
            Resume resume1 = new Resume("大鸟");//简历1
            resume1.SetPersonalInfo("男","29");
            resume1.SetWorkExperience("1998-2000","XX公司");

            Resume resume2 = (Resume)resume1.Clone();
            resume2.SetWorkExperience("1998-2006","YY企业");

            Resume resume3 = (Resume)resume1.Clone();
            resume3.SetPersonalInfo("男", "24");

            resume1.Display();
            resume2.Display();
            resume3.Display();
        }
        /// <summary>
        /// 原型抽象类,有ICloneable可替代
        /// </summary>
        abstract class Prototype
        {
            private string _id;

            public string Id { get => _id; }
            public Prototype(string id)
            {
                this._id = id;
            }
            public abstract Prototype Clone();
        }
        class ConcretePrototype1 : Prototype
        {
            //指定创建派生类实例时应调用的基类构造函数
            public ConcretePrototype1(string id) : base(id)
            { }
            public override Prototype Clone()
            {
                return (Prototype)this.MemberwiseClone();
            }
        }
        class Resume : ICloneable
        {
            private string _name;
            private string _sex;
            private string _age;
            private string _timeArea;
            private string _company;
            public Resume(string name)
            {
                _name = name;
            }
            /// <summary>
            /// 设置个人信息
            /// </summary>
            /// <param name="sex">性别</param>
            /// <param name="age">年龄</param>
            public void SetPersonalInfo(string sex,string age)
            {
                this._sex = sex;
                this._age = age;
            }
            /// <summary>
            /// 设置工作经历
            /// </summary>
            /// <param name="timeArea"></param>
            /// <param name="company"></param>
            public void SetWorkExperience(string timeArea,string company)
            {
                this._timeArea = timeArea;
                this._company = company;
            }
            public void Display()
            {
                Console.WriteLine($"{_name} {_sex} {_age}");
                Console.WriteLine($"工作经历: {_timeArea} {_company}");
            }
            public object Clone()
            {
                return (Object)this.MemberwiseClone();
            }
        }
    }
}
