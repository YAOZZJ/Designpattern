using System;

namespace _13_适配器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Target target = new Target();
            target.Request();
        }
    }
    /// <summary>
    /// 客户端接口
    /// </summary>
    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("普通请求! ");
        }
    }
    /// <summary>
    /// 需要适配的类
    /// </summary>
    class Adapted
    {
        public void SpecificRequest()
        {
            Console.WriteLine("特殊请求! ");
        }
    }
    /// <summary>
    /// 内部包装一个需要适配的对象,把源接口转化成目标接口
    /// </summary>
    class Adapeter : Target
    {
        private Adapted adapted = new Adapted();
        public override void Request()
        {
            adapted.SpecificRequest();
        }
    }
}
