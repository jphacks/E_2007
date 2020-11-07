using System.Collections.Generic;
using System;

namespace VRoidSDK.Editor
{
    public class UriSchemeValidator : IValidator
    {
        private string _uriString;
        private List<string> _excludeUriScheme;

        public UriSchemeValidator(string uri)
        {
            _uriString = uri;
            _excludeUriScheme = new List<string>()
            {
                "my-vroidsdk-app"
            };
        }

        public bool Validate()
        {
            // 空文字の場合は設定不要なのでチェックしない
            if (string.IsNullOrEmpty(_uriString))
            {
                return true;
            }

            try
            {
                var uri = new Uri(_uriString);
                if (_excludeUriScheme.Contains(uri.Scheme))
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
