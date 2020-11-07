#import <Foundation/Foundation.h>
#include "IAuthenticateSession.h"

#if __IPHONE_OS_VERSION_MAX_ALLOWED >= 130000

@implementation WebAuthenticationPresentationContextProvider

- (ASPresentationAnchor)presentationAnchorForWebAuthenticationSession:(ASWebAuthenticationSession *)session {
    return UIApplication.sharedApplication.keyWindow;
}

@end

AuthenticateiOS13::AuthenticateiOS13(NSURL* url, NSString* urlSchema)
{
    provider = [[WebAuthenticationPresentationContextProvider alloc] init];
    session = [[ASWebAuthenticationSession alloc] initWithURL:url callbackURLScheme:urlSchema completionHandler:^(NSURL * _Nullable callbackURL, NSError * _Nullable error) {
        if(!error) {
            NSString* message = [callbackURL absoluteString];
            UnitySendMessage("BrowserAuthorize", "OnOpenUrl", [message UTF8String]);
        }
        else {
            UnitySendMessage("BrowserAuthorize", "OnCancelAuthorize", "Authorize Error");
        }
    }];

    session.presentationContextProvider = provider;
}

AuthenticateiOS13::~AuthenticateiOS13()
{
    session = nil;
    provider = nil;
}

void AuthenticateiOS13::start()
{
    [session start];
}

#endif
