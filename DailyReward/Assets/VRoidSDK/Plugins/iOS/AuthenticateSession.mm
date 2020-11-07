#import <Foundation/Foundation.h>
#import <AuthenticationServices/AuthenticationServices.h>
#import <SafariServices/SafariServices.h>
#import "UnityAppController.h"

#include <memory>
#include "IAuthenticateSession.h"

std::unique_ptr<IAuthenticateSession> vroidAuthenticateSession;

void SessionStart(NSURL* url, NSString* urlScheme)
{
#if __IPHONE_OS_VERSION_MAX_ALLOWED >= 130000
    if(@available(iOS 13, *)) {
        vroidAuthenticateSession = std::unique_ptr<IAuthenticateSession>(new AuthenticateiOS13(url, urlScheme));
    } else
#endif
#if __IPHONE_OS_VERSION_MAX_ALLOWED >= 120000
    if(@available(iOS 12, *)) {
        vroidAuthenticateSession = std::unique_ptr<IAuthenticateSession>(new AuthenticateiOS12(url, urlScheme));
    } else
#endif
    if (@available(iOS 11.0, *)) {
        // iOS 11での処理
        vroidAuthenticateSession = std::unique_ptr<IAuthenticateSession>(new AuthenticateiOS11(url, urlScheme));
    } else {
        // iOS 9 and iOS 10
        vroidAuthenticateSession = std::unique_ptr<IAuthenticateSession>(new AuthenticateiOS10(url));
    }

    if(vroidAuthenticateSession != nullptr)
    {
        vroidAuthenticateSession->start();
    }
}

extern "C" {
    void OpenBrowserWindow(const char* url, const char* urlScheme)
    {
        NSString* nsUrlString = [[NSString alloc] initWithUTF8String:url];
        NSString* nsUrlScheme = [[NSString alloc] initWithUTF8String:urlScheme];
        NSURL* oauthUrl = [[NSURL alloc] initWithString:nsUrlString];
        SessionStart(oauthUrl, nsUrlScheme);
    }

    void ReleaseSession()
    {
        vroidAuthenticateSession = nullptr;
    }
}
