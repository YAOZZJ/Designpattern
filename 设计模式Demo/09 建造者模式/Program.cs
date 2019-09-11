using System;
using System.Collections;
using System.Collections.Generic;

namespace _09_建造者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        static void Run()
        {
            Director director = new Director();
            Builder builder1 = new ConcreteBuilder1();
            Builder builder2 = new ConcreteBuilder2();

            director.Construct(builder1);
            Product product1 = builder1.GetResult();
            product1.show();

            director.Construct(builder2);
            Product product2 = builder2.GetResult();
            product2.show();


        }
    }
    /// <summary>
    /// 产品类;
    /// 产品集合,由多个部件组成;
    /// show所有产品方法
    /// </summary>
    class Product
    {
        IList<string> parts = new List<string>();
        public void Add(string part)
        {
            parts.Add(part);
        }
        public void show()
        {
            Console.WriteLine("\n产品创建 -----");
            foreach(string part in parts)
            {
                Console.WriteLine(part);
            }
        }
    }
    /// <summary>
    /// 抽象建造者类
    /// 确定产品构成
    /// 返回产品建造结果
    /// </summary>
    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }
    /// <summary>
    /// 具体建造者类A
    /// </summary>
    class ConcreteBuilder1 : Builder
    {
        private Product product = new Product();
        public override void BuildPartA()
        {
            product.Add("部件A");
        }
        public override void BuildPartB()
        {
            product.Add("部件B");
        }
        public override Product GetResult()
        {
            return product;
        }
    }
    class ConcreteBuilder2 : Builder
    {
        private Product product = new Product();
        public override void BuildPartA()
        {
            product.Add("部件X");
        }
        public override void BuildPartB()
        {
            product.Add("部件Y");
        }
        public override Product GetResult()
        {
            return product;
        }
    }
    /// <summary>
    /// 指挥者
    /// 指挥对象建造(执行相应方法)
    /// </summary>
    class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }
}
