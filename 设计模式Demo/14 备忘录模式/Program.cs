using System;

namespace _14_备忘录模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator();
            originator.State = "On";
            originator.Show();

            Caretaker caretaker = new Caretaker();
            //用管理者类保存发起者类创建的备忘录
            caretaker.Memento = originator.CreateMemento();
            originator.State = "Off";
            originator.Show();

            //恢复状态
            originator.SetMemento(caretaker.Memento);
            originator.Show();
        }
    }
    /// <summary>
    /// 发起者类;
    /// 创建备忘录Memento;
    /// 根据需要存储那些内容
    /// </summary>
    class Originator
    {
        private string _state;
        /// <summary>
        /// 需要保存的属性
        /// </summary>
        public string State { get => _state; set => _state = value; }
        /// <summary>
        /// 创建备忘录,将需保存信息导入并实例化备忘录对象
        /// </summary>
        /// <returns></returns>
        public Memento CreateMemento()
        { return (new Memento(_state)); }
        /// <summary>
        /// 导入备忘录恢复数据
        /// </summary>
        /// <param name="memento"></param>
        public void SetMemento(Memento memento)
        {
            _state = memento.State;
        }
        public void Show()
        {
            Console.WriteLine($"State = {_state}");
        }
    }
    /// <summary>
    /// 备忘录类;
    /// 存储Originator内部状态
    /// 两个接口
    /// </summary>
    class Memento
    {
        private string _state;
        public Memento(string state)
        {
            this._state = state;
        }

        public string State { get => _state; }
    }
    /// <summary>
    /// 管理者类;
    /// 负责保存Memento
    /// </summary>
    class Caretaker
    {
        private Memento _memento;

        internal Memento Memento { get => _memento; set => _memento = value; }
    }
}
