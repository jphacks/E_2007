#import <Foundation/Foundation.h>
#include "IAuthenticateSession.h"

#if __IPHONE_OS_VERSION_MAX_ALLOWED >= 120000

AuthenticateiOS12::AuthenticateiOS12(NSURL* url, NSString* urlSchema)
{
    session = [[ASWebAuthenticationSession alloc] initWithURL:url callbackURLScheme:urlSchema completionHandler:^(NSURL * _Nullable callbackURL, NSError * _Nullable error) {
        if(!error) {
            NSString* message = [callbackURL absoluteString];
            UnitySendMessage("BrowserAuthorize", "OnOpenUrl", [message UTF8String]);
        }
        else {
            UnitySendMessage("BrowserAuthorize", "OnCancelAuthorize", "Authorize Error");
        }
    }];
}

AuthenticateiOS12::~AuthenticateiOS12()
{
    session = nil;
}

void AuthenticateiOS12::start()
{
    [session start];
}

#endif
