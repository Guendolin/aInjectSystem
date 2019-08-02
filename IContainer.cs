using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aSystem.aInjectionSystem
{
    public interface IContainer
    {
		bool ShouldDestoryOnLoad();
		bool Contains<T>();
		void Bind<T>(T o);
		void Unbind<T>();
		void Unbind<T>(T o);
		T Resolve<T>();
		object Resolve(Type T);
		void Destory();
    }
}
