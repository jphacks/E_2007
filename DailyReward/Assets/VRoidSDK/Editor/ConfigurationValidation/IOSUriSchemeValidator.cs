using System.Collections.Generic;
using System;
using VRoidSDK;

namespace VRoidSDK.Editor
{
    public class IOSUriSchemeValidator : IValidator
    {
        private UriSchemeValidator _validator;

        public IOSUriSchemeValidator(SDKConfiguration configuration)
        {
            _validator = new UriSchemeValidator(configuration.IOSUrlScheme);
        }

        public bool Validate()
        {
            return _validator.Validate();
        }
    }
}
