using System;

namespace _12_状态模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
            static void Run()
            {
                Context context = new Context(new ConcreteStateA());
                context.Rquest();
                context.Rquest();
                context.Rquest();
                context.Rquest();
            }
    }
        /// <summary>
        /// 定义与Context特定状态相关的行为
        /// </summary>
        abstract class State
        {
            public abstract void Handle(Context context);
        }
        class Context
        {
            private State state;
            /// <summary>
            /// 初始化Context
            /// </summary>
            /// <param name="state"></param>
            public Context(State state)
            {
                this.State = state;
            }
            /// <summary>
            /// 读取当前/设置新状态
            /// </summary>
            public State State { get => state; set { state = value; Console.WriteLine($"当前状态 {state.GetType().Name}"); } }
            /// <summary>
            /// 执行请求;
            /// 请求的子类共同方法是Handle;
            /// 子类执行Handle方法;
            /// 子类判断条件,是否进入下一状态
            /// </summary>
            public void Rquest()
            {
                state.Handle(this);
            }
        }
        class ConcreteStateA : State
        {
            public override void Handle(Context context)
            {
                context.State = new ConcreteStateB();
            }
        }
        class ConcreteStateB : State
        {
            public override void Handle(Context context)
            {
                context.State = new ConcreteStateA();
            }
        }
    }
