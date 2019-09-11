using System;

namespace _19_命令模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();
            invoker.SetCommand(command);
            invoker.ExecuteCOmmand();
        }
    }
    /// <summary>
    /// 命令操作接口
    /// </summary>
    abstract class Command
    {
        protected Receiver receiver;
        public Command(Receiver receiver) => this.receiver = receiver;
        abstract public void Execute();
    }
    /// <summary>
    /// 执行请求
    /// </summary>
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("执行请求! ");
        }
    }
    /// <summary>
    /// 将一个接收者绑定到一个对象,调用接收者相应的操作
    /// </summary>
    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) :base (receiver)
        {

        }
        public override void Execute()
        {
            receiver.Action();
        }
    }
    class Invoker
    {
        private Command command;
        public void SetCommand(Command command) => this.command = command;
        public void ExecuteCOmmand()
        {
            command.Execute();
        }
    }
}
