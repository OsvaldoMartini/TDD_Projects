using System;
using System.Collections.Generic;

namespace Container.IoCTests
{

    //<Summary>
    //A generic inversion control of container that facilitates depency injection

    public class IoCContainer
    {
        //initiate a new instance of the IoCContainer class
        public IoCContainer()
        {
            RegisteredTypes = new Dictionary<Type, Type>();
        }

        //Get a dictionary of registered types
        public IDictionary<Type, Type> RegisteredTypes
        {
            get;
            private set;
        }

        //Registers a type in the container
        //T1 The type to register
        //T2 The type that will be resolved based on the registered type
        public void Register<T1, T2>()
        {
            Type type = typeof(T2);
            if (type.IsAbstract)
                throw new InvalidOperationException(String.Format("Cannot register type {0} because is abstract.", type));

            RegisteredTypes.Add(typeof(T1), type);
        }

        //Resolves the specified type
        //"T" The type to resolve
        //"Return"  Returns a new instance of the type that the specified type was originally registered to
        public T Resolve<T>()
        {
            //By Reflection this get error "...Can't create Obj of interface
            //T instance = (T)Activator.CreateInstance(typeof(T));
            //By Reflection this is correct
            T instance = (T)Activator.CreateInstance(RegisteredTypes[typeof(T)]);
            return instance;
        }
    }
}
