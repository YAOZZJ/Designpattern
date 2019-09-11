using System;

namespace _03_装饰模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        static void Run()
        {
            //实例化实现类
            ConcreteComponent concrete = new ConcreteComponent();
            //实例化装饰类
            ConcreteDecoratorA decoratorA = new ConcreteDecoratorA();
            ConcreteDecoratorB decoratorB = new ConcreteDecoratorB();
            //用装饰类装饰实现类
            decoratorA.SetComponent(concrete);
            decoratorB.SetComponent(decoratorA);

            //
            decoratorB.Operation();
        }
    }
    /// <summary>
    /// 基类
    /// </summary>
    abstract class Component
    {
        public abstract void Operation();
    }
    /// <summary>
    /// 实现类
    /// </summary>
    class ConcreteComponent : Component
    {
        private string _name;

        public string Name { get => _name; set => _name = value; }
        public override void Operation()
        {
            Console.WriteLine("具体操作");
        }
    }
    /// <summary>
    /// 装饰类
    /// </summary>
    abstract class Decorator : Component
    {
        protected Component component;
        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (this.component != null) component.Operation();
        }
    }
    /// <summary>
    /// 装饰实现类
    /// </summary>
    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("装饰实现类A特有操作");
        }
    }
    /// <summary>
    /// 装饰实现类
    /// </summary>
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("装饰实现类B特有操作");
        }
    }
}
