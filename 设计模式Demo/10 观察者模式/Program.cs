using System;
using System.Collections;
using System.Collections.Generic;
using System.Reactive;

namespace _10_观察者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        static void Run()
        {
            Secretary secretary = new Secretary();//定义通知者
            StockObserver stockObserver = new StockObserver("张三", secretary);//观察者1
            NBAObserver nBAObserver = new NBAObserver("李四", secretary);//观察者2
            //增加观察者
            secretary.Attach(stockObserver);
            secretary.Attach(nBAObserver);
            secretary.SubjectState = "老板回来了";
            Console.ReadLine();
            secretary.Notify();
        }
    }
    #region "通知者"
    /// <summary>
    /// 定义通知者接口
    /// </summary>
    interface ISubject
    {
        void Attach(Observer observer);
        void Detach(Observer observer);
        void Notify();
        string SubjectState
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 通知者1
    /// </summary>
    class Secretary : ISubject
    {
        //同事列表
        private IList<Observer> observers = new List<Observer>();
        private string action;
        //增加
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }
        //减少
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }
        //通知
        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
        //前台状态
        public string SubjectState
        {
            get { return action; }
            set { action = value; }
        }
    }
    #endregion
    #region "观察者"
    /// <summary>
    /// 观察者
    /// </summary>
    abstract class Observer
    {
        protected string name;
        protected ISubject sub;
        public Observer(string name, ISubject sub)
        {
            this.name = name;
            this.sub = sub;
        }
        public abstract void Update();
    }
    /// <summary>
    /// 具体观察者1
    /// </summary>
    class StockObserver : Observer
    {
        public StockObserver(string name, ISubject sub)
            : base(name, sub)
        {
        }
        public override void Update()
        {
            Console.WriteLine("{0} {1} 关闭股票行情，继续工作！", sub.SubjectState, name);
        }
    }
    /// <summary>
    /// 具体观察者2
    /// </summary>
    class NBAObserver : Observer
    {
        public NBAObserver(string name, ISubject sub)
            : base(name, sub)
        {
        }
        public override void Update()
        {
            Console.WriteLine("{0} {1} 关闭NBA直播，继续工作！", sub.SubjectState, name);
        }
    }
    #endregion
}
