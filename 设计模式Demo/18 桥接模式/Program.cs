using System;

namespace _18_桥接模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new IPhone();
            phone.SetSoft(new Game());
            phone.Run();
            phone.SetSoft(new AddressList());
            phone.Run();

            phone = new Nokia();
            phone.SetSoft(new Game());
            phone.Run();
            phone.SetSoft(new AddressList());
            phone.Run();
        }
    }
    #region "软件类"
    abstract class Soft
    {
        public abstract void Run();
    }
    class Game : Soft
    {
        public override void Run()
        {
            Console.WriteLine("运行手机游戏");
        }
    }
    class AddressList : Soft
    {
        public override void Run()
        {
            Console.WriteLine("运行手机通讯录");
        }
    }
    #endregion
    #region "手机品牌类"
    abstract class Phone
    {
        protected Soft soft;
        public void SetSoft( Soft soft)
        {
            this.soft = soft;
        }
        public abstract void Run();
    }
    class IPhone : Phone
    {
        public override void Run()
        {
            soft.Run();
        }
    }class Nokia : Phone
    {
        public override void Run()
        {
            soft.Run();
        }
    }
    #endregion
}
