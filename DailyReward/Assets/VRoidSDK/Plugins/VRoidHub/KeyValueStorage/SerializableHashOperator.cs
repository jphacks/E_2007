using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRoidSDK
{
    [Serializable]
    public class SerializableHashOperator<T, U> : ISerializableHash<T> where T : class where U : SerializablePair<T>, new()
    {
        private List<U> _data;

        public SerializableHashOperator(List<U> data)
        {
            _data = data;
        }

        private T GetValue(string key)
        {
            var result = _data.Find((item) => item.Key == key);
            if (result != null)
            {
                return result.Value;
            }

            return null;
        }

        private void AddValue(string key, T value)
        {
            var result = _data.Find((item) => item.Key == key);
            if (result != null)
            {
                result.Value = value;
                return;
            }

            result = new U()
            {
                Key = key,
                Value = value
            };

            _data.Add(result);
        }

        /// <summary>
        /// 指定されたキーに関連付けられている値を取得または設定する
        /// </summary>
        /// <param name="key">キー</param>
        /// <typeparam name="T">保存するデータの型</typeparam>
        public T this[string key]
        {
            get { return GetValue(key); }
            set { AddValue(key, value); }
        }

        /// <summary>
        /// 指定したkeyのデータを削除する
        /// </summary>
        /// <param name="key">削除するキー</param>
        public bool Remove(string key)
        {
            var result = _data.Find((item) => item.Key == key);
            if (result != null)
            {
                _data.Remove(result);
                return true;
            }

            return false;
        }

        /// <summary>
        /// keyとvalueのペアの配列を取得する
        /// </summary>
        public SerializablePair<T>[] ToArray()
        {
            return _data.Cast<SerializablePair<T>>().ToArray();
        }
    }
}
