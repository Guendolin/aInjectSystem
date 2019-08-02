using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace aSystem.aInjectionSystem
{
    public class Container : IContainer
    {
        private Dictionary<Type, object> _container;

        private bool _shouldDestoryOnLoad;
        public bool ShouldDestoryOnLoad()
        {
            return _shouldDestoryOnLoad;
        }

        public Container(bool shouldDestoryOnLoad)
        {
            _container = new Dictionary<Type, object>();
            _shouldDestoryOnLoad = shouldDestoryOnLoad;
        }

        public void Bind<T>(T o)
        {
            _container.Add(typeof(T), o);
        }

        public bool Contains<T>()
        {
            return _container.ContainsKey(typeof(T));
        }

        public T Resolve<T>()
        {
            Type type = typeof(T);
            if (_container.ContainsKey(type))
            {
                return (T)_container[type];
            }
            return default;
        }

        public object Resolve(Type type)
        {
            if (_container.ContainsKey(type))
            {
                return _container[type];
            }
            return null;
        }

        public void Unbind<T>()
        {
            Type type = typeof(T);
            if (_container.ContainsKey(type))
            {
                _container.Remove(type);
            }
        }

        public void Unbind<T>(T o)
        {
            Type type = typeof(T);
            if (_container.ContainsKey(type))
            {
                T content = (T)_container[type];
                if (!content.Equals(null) && content.Equals(o))
                {
                    _container.Remove(type);
                }
            }
        }

        public void Destory()
        {
            _container = null;
        }
    }
}


