using System.Reflection;
using UnityEngine;
using VRoidSDK;

namespace VRoidSDK.Editor
{
    public class AuthenticateMetaDataValidator : IValidator
    {
        private SDKConfiguration _configuration;

        public AuthenticateMetaDataValidator(SDKConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Validate()
        {
            var appIdField = _configuration.GetType().GetField("_applicationId", BindingFlags.Instance | BindingFlags.NonPublic);
            var secretIdField = _configuration.GetType().GetField("_secret", BindingFlags.Instance | BindingFlags.NonPublic);

            var appId = (string)appIdField.GetValue(_configuration);
            var secret = (string)secretIdField.GetValue(_configuration);

            if (string.IsNullOrEmpty(appId) || string.IsNullOrEmpty(secret))
            {
                return false;
            }

            return true;
        }
    }
}
