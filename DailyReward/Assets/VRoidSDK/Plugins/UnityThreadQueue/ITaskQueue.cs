using System;

namespace VRoidSDK
{
    /// <summary>
    /// タスクをキューとして別スレッドで処理する機能を提供するインターフェース
    /// </summary>
    public interface ITaskQueue
    {
        /// <summary>
        /// 実行するキューがまだ残っているかを判定する
        /// </summary>
        bool ExistQueueEvent { get; }

        /// <summary>
        /// 実行するタスクをキューに保存する
        /// </summary>
        /// <param name="task">実行するタスク</param>
        void Enqueue(Action task);
    }
}
