﻿using System;
using System.Collections.Generic;

namespace _15_组合模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Component root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Component comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));
            root.Add(comp);

            Component comp2 = new Composite("Composite XY");
            comp2.Add(new Leaf("Leaf XYA"));
            comp2.Add(new Leaf("Leaf XYB"));
            comp.Add(comp2);

            root.Add(new Leaf("Leaf C"));
            Leaf leafD = new Leaf("Leaf B");
            root.Add(leafD);
            root.Remove(leafD);
            root.Display(1);
        }
    }
    abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract void Display(int depth);
    }
    /// <summary>
    /// 节点对象,无子节点
    /// </summary>
    class Leaf : Component
    {
        public Leaf(string name) :base(name)
        {

        }
        public override void Add(Component component)
        {
            Console.WriteLine("Cannot add to a leaf");
        }
        public override void Remove(Component component)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-',depth) + name) ;
        }
    }
    /// <summary>
    /// 存储子部件
    /// </summary>
    class Composite : Component
    {
        private List<Component> children = new List<Component>();
        public Composite(string name) : base(name)
        {

        }
        public override void Add(Component component)
        {
            children.Add(component);
        }
        public override void Remove(Component component)
        {
            children.Remove(component);

        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
            foreach(Component component in children)
            {
                component.Display(depth + 2);
            }
        }

    }
}
