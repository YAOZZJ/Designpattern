using System;

namespace 策略模式
{
    class Program
    {
        static void Main(string[] args)
        {
            RunFactory();
        }
        /// <summary>
        /// 工厂模式运行
        /// </summary>
        static void RunFactory()
        {
            CashSuper cash = CashFactory.CreateCashAccept("打折收费");
            Console.WriteLine(cash.AcceptCash(800) ); 
        }
        #region "策略模式"
        /// <summary>
        /// 策略模式与工厂模式结合
        /// </summary>
        class CashContext
        {
            CashSuper cashSuper = null;
            public CashContext(string type)
            {
                switch (type)
                {
                    case "正常收费": cashSuper = new CashNormal(); break;
                    case "打折收费": cashSuper = new CashRebate(0.8); break;
                    case "满减收费": cashSuper = new CashReturn(300, 100); break;
                }
            }
            /// <summary>
            /// 与工厂模式比多了对象的实现
            /// </summary>
            /// <param name="moneny"></param>
            /// <returns></returns>
                public double GetResult(double moneny)
                {
                    return cashSuper.AcceptCash(moneny);
                }
        }
        #endregion
        #region "工厂类"
        class CashFactory
        {
            public static CashSuper CreateCashAccept(string type)
            {
                CashSuper cashSuper = null;
                switch (type)
                {
                    case "正常收费": cashSuper = new CashNormal(); break;
                    case "打折收费": cashSuper = new CashRebate(0.8); break;
                    case "满减收费": cashSuper = new CashReturn(300,100); break;
                }
                return cashSuper;
            }
        }
        #endregion
        #region "基本类"
        /// <summary>
        /// 收费抽象类
        /// </summary>
        abstract class CashSuper
        {
            public abstract double AcceptCash(double money);
        }
        /// <summary>
        /// 正常收费
        /// </summary>
        class CashNormal : CashSuper
        {
            public override double AcceptCash(double money)
            {
                return money;
            }
        }
        /// <summary>
        /// 打折收费
        /// </summary>
        class CashRebate : CashSuper
        {
            private double _moneyRebate = 1d;
            public CashRebate(double moneyRebate)
            {
                this._moneyRebate = moneyRebate;
            }
            public override double AcceptCash(double money)
            {
                return money*_moneyRebate;
            }
        }
        /// <summary>
        /// 返利收费
        /// </summary>
        class CashReturn : CashSuper
        {
            private double _moneyCondition = 0.00d;//满moneyCondition 减 moneyReturn
            private double _moneyReturn = 0.00d;//满moneyCondition 减 moneyReturn
            public CashReturn(double moneyCondition, double moneyReturn)
            {
                _moneyCondition = moneyCondition;
                _moneyReturn = moneyReturn;
            }
            public override double AcceptCash(double money)
            {
                if (money < _moneyCondition)
                return money;
                return (money - Math.Floor(money/ _moneyReturn) *_moneyReturn);
            }
        }
        #endregion
    }
}
