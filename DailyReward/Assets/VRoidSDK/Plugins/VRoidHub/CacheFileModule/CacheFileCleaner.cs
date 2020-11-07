using System.Linq;
using VRoidSDK.IO;

namespace VRoidSDK
{
    /// <summary>
    /// キャッシュファイルを削除するクラス
    /// </summary>
    public class CacheFileCleaner
    {
        private IKeyValueStorable<CacheFileInfo> _storage;
        private IFileDelete _fileDeleter;

        public CacheFileCleaner(IKeyValueStorable<CacheFileInfo> storage, IFileDelete fileDeleter)
        {
            _storage = storage;
            _fileDeleter = fileDeleter;
        }

        /// <summary>
        /// 保存しているキャッシュファイルの情報とキャッシュファイルをmaxCacheCount件になるまで削除する
        /// 0を指定するとすべて削除する
        /// </summary>
        /// <param name="maxCacheCount">最大件数</param>
        public void Clean(uint maxCacheCount)
        {
            var infoArray = _storage.ToArray();
            infoArray = infoArray.OrderBy((x) => x.Value.LastAccessTime)
                                .Take((int)(infoArray.Count() - maxCacheCount)).ToArray();

            foreach (var infoPair in infoArray)
            {
                _fileDeleter.Delete(infoPair.Value.FilePath);
                _storage.RemoveKey(infoPair.Value.FilePath);
            }
            _storage.Save();
        }

        /// <summary>
        /// 期限切れのキャッシュファイルの情報とキャッシュファイルを削除する
        /// </summary>
        public void CleanExpiredCacheFile()
        {
            foreach (var infoPair in _storage.ToArray())
            {
                if (infoPair.Value.IsExpired())
                {
                    _fileDeleter.Delete(infoPair.Value.FilePath);
                    _storage.RemoveKey(infoPair.Value.FilePath);
                }
            }
            _storage.Save();
        }
    }
}
