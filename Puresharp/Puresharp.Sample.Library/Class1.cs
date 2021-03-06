﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puresharp.Sample.Library
{
    public delegate T AddDelegate<T>(T x, T y);

    public class Calculator
    {
        private AddDelegate<int> add = new AddDelegate<int>((x, y) => x + y);

        public int Add(int a, int b)
        {
            return add(a, b);
        }

        virtual public int AddEx(int a, int b)
        {
            return a + b;
        }

        public IEnumerable<string> Test(IEnumerable<string> p)
        {
            return p.Select(u => u);
        }

        public async Task Hello()
        {
        }

        public async Task World()
        {
        }

        public async Task<int> TestAsync(int a, int b)
        {
            await this.Hello();
            await this.World();
            return a + b;
        }
    }

    public class SuperCalculator : Calculator
    {
        public override int AddEx(int a, int b)
        {
            Console.WriteLine("AddEx");
            return base.AddEx(a, b);
        }
    }
}
