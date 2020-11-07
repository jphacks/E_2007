#import <Foundation/Foundation.h>
#import "AppDelegateListener.h"
#include "IAuthenticateSession.h"
#include <functional>

@implementation SafariViewControllerDelegate

- (void) safariViewControllerDidFinish:(SFSafariViewController *)controller
{
    self.OnSafariClosed();
}

@end

@implementation VRoidSDKOnOpenURLListener

- (id)init {
    self = [super init];
    if (self) {
        UnityRegisterAppDelegateListener(self);
    }
    return self;
}

- (void)onOpenURL:(NSNotification *)notification {
    NSURL *url = notification.userInfo[@"url"];
    NSString* message = [url absoluteString];
    UnitySendMessage("BrowserAuthorize", "OnOpenUrl", [message UTF8String]);
    self.OnSafariAuthorized();
}

- (void)unregister
{
    UnityUnregisterAppDelegateListener(self);
}

@end

AuthenticateiOS10::AuthenticateiOS10(NSURL* url)
{
    delegator = [[SafariViewControllerDelegate alloc] init];
    delegator.OnSafariClosed = [] {
        UnitySendMessage("BrowserAuthorize", "OnCancelAuthorize", "Authorize Error");
    };
    onOpenURLListener = [[VRoidSDKOnOpenURLListener alloc] init];
    onOpenURLListener.OnSafariAuthorized = [this] {
        [safariVC dismissViewControllerAnimated:YES completion:^{
            [[NSNotificationCenter defaultCenter] removeObserver:delegator];
        }];
    };
    safariVC = [[SFSafariViewController alloc] initWithURL:url];
    safariVC.delegate = delegator;
}

AuthenticateiOS10::~AuthenticateiOS10()
{
    [onOpenURLListener unregister];
    onOpenURLListener = nil;
    delegator = nil;
    safariVC = nil;
}

void AuthenticateiOS10::start()
{
    UIViewController* uvc = UnityGetGLViewController();
    [uvc presentViewController:safariVC animated:YES completion:nil];
}
