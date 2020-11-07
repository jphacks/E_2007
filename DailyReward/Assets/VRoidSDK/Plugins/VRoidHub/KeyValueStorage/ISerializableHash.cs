
namespace VRoidSDK
{
    public interface ISerializableHash<T> where T : class
    {
        /// <summary>
        /// 指定されたキーに関連付けられている値を取得または設定する
        /// </summary>
        /// <param name="key">キー</param>
        /// <typeparam name="T">保存するデータの型</typeparam>
        T this[string key] { get; set; }

        /// <summary>
        /// 指定したkeyのデータを削除する
        /// </summary>
        /// <param name="key">削除するキー</param>
        bool Remove(string key);

        /// <summary>
        /// keyとvalueのペアの配列を取得する
        /// </summary>
        SerializablePair<T>[] ToArray();
    }
}
