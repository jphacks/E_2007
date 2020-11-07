#import <Foundation/Foundation.h>
#include "IAuthenticateSession.h"

AuthenticateiOS11::AuthenticateiOS11(NSURL* url, NSString* urlSchema)
{
    session = [[SFAuthenticationSession alloc] initWithURL:url callbackURLScheme:urlSchema completionHandler:^(NSURL * _Nullable callbackURL, NSError * _Nullable error) {
        if(!error) {
            NSString* message = [callbackURL absoluteString];
            UnitySendMessage("BrowserAuthorize", "OnOpenUrl", [message UTF8String]);
        }
        else {
            UnitySendMessage("BrowserAuthorize", "OnCancelAuthorize", "Authorize Error");
        }
    }];
}

AuthenticateiOS11::~AuthenticateiOS11()
{
    session = nil;
}

void AuthenticateiOS11::start()
{
    [session start];
}
