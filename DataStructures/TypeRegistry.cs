using System;
using System.Collections;
using System.Collections.Generic;

namespace PboneLib.DataStructures
{
    public class TypeRegistry<T> : IEnumerable<KeyValuePair<Type, T>>
    {
        public Dictionary<Type, T> RegistryObjects;

        public TypeRegistry()
        {
            RegistryObjects = new Dictionary<Type, T>();
        }

        public void Add<TType>() where TType : T, new() => Add(new TType());
        public void Add(T instance) => RegistryObjects.Add(instance.GetType(), instance);
        public TType Get<TType>() where TType : T => (TType)RegistryObjects[typeof(T)];

        public bool TryGet<TType>(out T instance) where TType : T
        {
            if (RegistryObjects.ContainsKey(typeof(T)))
            {
                instance = default;
                return false;
            }

            instance = Get<TType>();
            return true;
        }

        public IEnumerator<KeyValuePair<Type, T>> GetEnumerator() => RegistryObjects.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => RegistryObjects.GetEnumerator();
    }
}
