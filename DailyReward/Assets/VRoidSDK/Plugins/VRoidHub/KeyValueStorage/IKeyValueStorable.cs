
namespace VRoidSDK
{
    /// <summary>
    /// key-valueストレージのインターフェース
    /// </summary>
    public interface IKeyValueStorable<T> where T : class
    {
        /// <summary>
        /// 指定したkeyに該当するデータを取得する
        /// </summary>
        /// <param name="key">取得するキー</param>
        /// <returns>取得したオブジェクト</returns>
        /// <typeparam name="T">取得するオブジェクトの型</typeparam>
        T GetObject(string key);

        /// <summary>
        /// 指定したkeyにデータをセットする
        /// </summary>
        /// <param name="key">取得するキー</param>
        /// <param name="value">セットするオブジェクト</param>
        /// <typeparam name="T">セットするオブジェクトの型</typeparam>
        void SetValue(string key, T value);

        /// <summary>
        /// 指定したkeyのデータを削除する
        /// </summary>
        /// <param name="key">削除するキー</param>
        bool RemoveKey(string key);

        /// <summary>
        /// keyとvalueのペアの配列を取得する
        /// </summary>
        SerializablePair<T>[] ToArray();

        /// <summary>
        /// <para>メモリにのっているデータをストレージに保存する</para>
        /// </summary>
        void Save();
    }
}
