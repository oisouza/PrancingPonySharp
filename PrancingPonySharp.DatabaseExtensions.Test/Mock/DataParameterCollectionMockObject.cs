using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace PrancingPonySharp.DatabaseExtensions.Test.Mock
{
    public class DataParameterCollectionMockObject : IDataParameterCollection
    {
        public Dictionary<string, object> Parameters { get; } = new Dictionary<string, object>();

        public object this[string parameterName]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public object this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public int Add(object value)
        {
            var parameter = (IDbDataParameter) value;
            if (parameter?.ParameterName != null)
                Parameters.Add(parameter.ParameterName, parameter.Value);
            return 0;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(string parameterName)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(string parameterName)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(string parameterName)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
