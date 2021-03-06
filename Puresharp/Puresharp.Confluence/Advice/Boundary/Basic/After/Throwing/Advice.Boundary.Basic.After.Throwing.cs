﻿using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Puresharp.Confluence
{
    public sealed partial class Advice
    {
        public partial class Boundary
        {
            static internal partial class Basic
            {
                public partial class After
                {
                    public partial class Throwing : Advice.IBoundary
                    {
                        private Action m_Action;

                        public Throwing(Action action)
                        {
                            this.m_Action = action;
                        }

                        void Advice.IBoundary.Instance<T>(T instance)
                        {
                        }

                        void Advice.IBoundary.Argument<T>(ParameterInfo parameter, ref T value)
                        {
                        }

                        void Advice.IBoundary.Begin()
                        {
                        }

                        void Advice.IBoundary.Await(MethodInfo method, ref Task task)
                        {
                        }

                        void Advice.IBoundary.Await<T>(MethodInfo method, ref Task<T> task)
                        {
                        }

                        void Advice.IBoundary.Continue()
                        {
                        }

                        void Advice.IBoundary.Return()
                        {
                        }

                        void Advice.IBoundary.Throw(ref Exception exception)
                        {
                            this.m_Action();
                        }

                        void Advice.IBoundary.Return<T>(ref T value)
                        {
                        }

                        void Advice.IBoundary.Throw<T>(ref Exception exception, ref T value)
                        {
                            this.m_Action();
                        }

                        void IDisposable.Dispose()
                        {
                        }
                    }
                }
            }
        }
    }
}