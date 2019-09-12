using System;

namespace _21_中介者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitedNationsSecurity UNSC = new UnitedNationsSecurity();
            USA c1 = new USA(UNSC);
            Iraq c2 = new Iraq(UNSC);

            UNSC.Colleague1 = c1;
            UNSC.Colleague2 = c2;

            c1.DeclareX("不准研发核武器,否则发动战争! ");
            c2.DeclareX("我们没有核武器,也不怕侵略! ");
        }
    }
    abstract class UintedNations
    {
        public abstract void Declare(string message, Country colleague);
    }
    abstract class Country
    {
        protected UintedNations mediator;
        public Country(UintedNations mediator) => this.mediator = mediator;
    }
    class UnitedNationsSecurity : UintedNations
    {
        private USA _colleague1;
        private Iraq _colleague2;
        /// <summary>
        /// 美国
        /// </summary>
        internal USA Colleague1 {  set => _colleague1 = value; }
        /// <summary>
        /// 伊拉克
        /// </summary>
        internal Iraq Colleague2 {  set => _colleague2 = value; }
        public override void Declare(string message, Country colleague)
        {
            if (colleague == _colleague1) _colleague2.GetMessage(message);
            else _colleague1.GetMessage(message);
        }
    }
    #region "具体国家类
    class USA : Country
    {
        public USA(UintedNations mediator) : base(mediator) { }
        /// <summary>
        /// 声明
        /// </summary>
        /// <param name="message"></param>
        public void DeclareX(string message)
        {
            //通过中介发送消息,发送到哪里本身不知道,由中介者判断
            mediator.Declare(message, this);
        }
        /// <summary>
        /// 获得消息
        /// </summary>
        /// <param name="message"></param>
        public void GetMessage(string message)
        {
            Console.WriteLine("美国获得对方信息: "+ message);
        }
    }
    class Iraq : Country
    {
        public Iraq(UintedNations mediator) : base(mediator) { }
        /// <summary>
        /// 声明
        /// </summary>
        /// <param name="message"></param>
        public void DeclareX(string message)
        {
            mediator.Declare(message, this);
        }
        /// <summary>
        /// 获得消息
        /// </summary>
        /// <param name="message"></param>
        public void GetMessage(string message)
        {
            Console.WriteLine("伊拉克获得对方信息: "+ message);
        }
    }
    #endregion"
}
