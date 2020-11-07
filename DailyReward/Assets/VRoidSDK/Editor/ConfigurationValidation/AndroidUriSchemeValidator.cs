using System.Collections.Generic;
using System;
using VRoidSDK;

namespace VRoidSDK.Editor
{
    public class AndroidUriSchemeValidator : IValidator
    {
        private UriSchemeValidator _validator;

        public AndroidUriSchemeValidator(SDKConfiguration configuration)
        {
            _validator = new UriSchemeValidator(configuration.AndroidUrlScheme);
        }

        public bool Validate()
        {
            return _validator.Validate();
        }
    }
}
