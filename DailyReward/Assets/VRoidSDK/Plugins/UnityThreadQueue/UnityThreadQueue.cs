using System;
using System.Collections.Generic;
using System.Threading;

namespace VRoidSDK
{
    /// <summary>
    /// タスクをキューに入れて、別スレッドで実行するクラス
    ///
    /// reference: [UnityThreadQueue](https://github.com/TakuKobayashi/UnityThreadQueue)
    /// </summary>
    public class UnityThreadQueue : IDisposable, ITaskQueue
    {
        private static UnityThreadQueue s_instance;

        public static UnityThreadQueue Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new UnityThreadQueue();
                }
                return s_instance;
            }
        }

        private UnityThreadQueue()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Execute));
        }

        private Queue<Action> _taskQueue = new Queue<Action>();
        private volatile bool _isExistQueueEvent = false;
        private volatile bool _running = true;
        private ManualResetEvent _queueEvent = new ManualResetEvent(false);

        private void Execute(object o)
        {
            while (_queueEvent.WaitOne())
            {
                if (!_running) { break; }

                Action actor = null;
                lock (_taskQueue)
                {
                    if (_taskQueue.Count > 0)
                    {
                        actor = _taskQueue.Dequeue();
                    }
                    else
                    {
                        _isExistQueueEvent = false;
                        _queueEvent.Reset();
                    }
                }
                if (actor != null)
                {
                    try
                    {
                        actor();
                    }
                    catch (Exception)
                    {
                        lock (_taskQueue)
                        {
                            _running = false;
                            _taskQueue.Clear();
                        }
                    }
                }
            }
        }

        public bool ExistQueueEvent
        {
            get
            {
                return _isExistQueueEvent;
            }
        }

        public void Enqueue(Action task)
        {
            lock (_taskQueue)
            {
                _taskQueue.Enqueue(task);
                _queueEvent.Set();
                _isExistQueueEvent = true;
            }
        }

        public void Dispose()
        {
            _running = false;
            _isExistQueueEvent = false;
            _queueEvent.Set();
        }
    }
}
