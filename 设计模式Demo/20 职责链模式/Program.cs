using System;

namespace _20_职责链模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();

            //设置职责链
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            int[] requests = {2,5,14,22,18,3,27,20 };
            foreach(int request in requests)
            {
                h1.HandleRequest(request);
            }
        }
    }
    /// <summary>
    /// 处理请求接口
    /// </summary>
    abstract class Handler
    {
        protected Handler handler;
        /// <summary>
        /// 设置继任者
        /// </summary>
        /// <param name="handler"></param>
        public void SetSuccessor(Handler handler)
        {
            this.handler = handler;
        }
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="request"></param>
        public abstract void HandleRequest(int request);
    }
    #region "具体处理/继任者"
    class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
                Console.WriteLine($"{this.GetType().Name} 处理请求 : {request}");
            else if (handler != null)
                //把参数request转移到SetSuccessor设置的继任者
                handler.HandleRequest(request);
        }
    }
    class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
                Console.WriteLine($"{this.GetType().Name} 处理请求 : {request}");
            else if (handler != null)
                //把参数request转移到SetSuccessor设置的继任者
                handler.HandleRequest(request);
        }
    }
    class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
                Console.WriteLine($"{this.GetType().Name} 处理请求 : {request}");
            else if (handler != null)
                //把参数request转移到SetSuccessor设置的继任者
                handler.HandleRequest(request);
        }
    }
    #endregion
}
