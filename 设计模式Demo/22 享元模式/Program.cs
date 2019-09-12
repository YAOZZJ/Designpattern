using System;
using System.Collections;

namespace _22_享元模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Run1();
        }
        static void Run1()
        {
            WebSiteFactory webSiteFactory = new WebSiteFactory();
            WebSite webSite1 = webSiteFactory.GetWebSiteCategory("产品展示"); webSite1.Use();
            WebSite webSite2 = webSiteFactory.GetWebSiteCategory("产品展示"); webSite2.Use();
            WebSite webSite3 = webSiteFactory.GetWebSiteCategory("产品展示"); webSite3.Use();
            WebSite webSite4 = webSiteFactory.GetWebSiteCategory("博客"); webSite4.Use();
            WebSite webSite5 = webSiteFactory.GetWebSiteCategory("博客"); webSite5.Use();
            WebSite webSite6 = webSiteFactory.GetWebSiteCategory("黄页"); webSite6.Use();
            Console.WriteLine($"网站总数:{webSiteFactory.GetWebSiteCount()}");
        }
    }
    #region "简单示例"
    /// <summary>
    /// 网站抽象类
    /// </summary>
    abstract class WebSite
    {
        /// <summary>
        /// 传递用户对象
        /// </summary>
        public abstract void Use();
    }
    /// <summary>
    /// 具体网站
    /// </summary>
    class ConcreteWebSite : WebSite
    {
        private string name = "";
        /// <summary>
        /// 获取name参数
        /// </summary>
        /// <param name="name"></param>
        public ConcreteWebSite(string name) => this.name = name;
        public override void Use()
        {
            Console.WriteLine($"网站分类 : {name}");
        }
    }
    class WebSiteFactory
    {
        private Hashtable flyweights = new Hashtable();
        /// <summary>
        /// 获取实际网站
        /// 如果不含有key则新建一个改类的实际网站对象ConcreteWebSite
        /// </summary>
        /// <param name="key"></param>
        /// <returns>获取实际网站</returns>
        public WebSite GetWebSiteCategory(string key)
        {
            //如果不含有key则新建一个改类的实际网站对象ConcreteWebSite
            if (!flyweights.ContainsKey(key)) flyweights.Add(key, new ConcreteWebSite(key));
            return ((WebSite)flyweights[key]);
        }
        public int GetWebSiteCount() => flyweights.Count;
    }
    #endregion
}
