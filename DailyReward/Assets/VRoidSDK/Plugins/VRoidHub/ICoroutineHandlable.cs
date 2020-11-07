using System.Collections;

namespace VRoidSDK
{
    /// <summary>
    /// コルーチンを実行できる機能を提供するインターフェース
    /// </summary>
    public interface ICoroutineHandlable
    {
        /// <summary>
        /// コルーチン処理を実行する
        /// </summary>
        /// <param name="routine">処理するコルーチン</param>
        void RunMonoCoroutine(IEnumerator routine);
    }
}
