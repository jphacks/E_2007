#ifndef IAuthenticateSession_h
#define IAuthenticateSession_h

#import <AuthenticationServices/AuthenticationServices.h>
#import <SafariServices/SafariServices.h>
#import "AppDelegateListener.h"
#include <functional>

#if __IPHONE_OS_VERSION_MIN_REQUIRED < 90000
#error VRoidSDK is only available on iOS 9.0 or newer
#endif

class IAuthenticateSession
{
public:
    virtual ~IAuthenticateSession()
    {

    }
    virtual void start() = 0;
};

@interface SafariViewControllerDelegate : NSObject <SFSafariViewControllerDelegate>
@property (nonatomic) std::function<void()> OnSafariClosed;
@end

@interface VRoidSDKOnOpenURLListener : NSObject<AppDelegateListener>
@property (nonatomic) std::function<void()> OnSafariAuthorized;
@end

class AuthenticateiOS10 : public IAuthenticateSession
{
public:
    AuthenticateiOS10(NSURL* url);
    virtual ~AuthenticateiOS10();
    virtual void start();
private:
    SafariViewControllerDelegate* delegator;
    SFSafariViewController* safariVC;
    VRoidSDKOnOpenURLListener* onOpenURLListener;
};

class AuthenticateiOS11 : public IAuthenticateSession
{
public:
    API_AVAILABLE(ios(11.0))
    AuthenticateiOS11(NSURL* url, NSString* urlSchema);

    API_AVAILABLE(ios(11.0))
    virtual ~AuthenticateiOS11();

    API_AVAILABLE(ios(11.0))
    virtual void start();
private:
    API_AVAILABLE(ios(11.0)) SFAuthenticationSession* session;
};

#if __IPHONE_OS_VERSION_MAX_ALLOWED >= 120000

class AuthenticateiOS12 : public IAuthenticateSession
{
public:
    API_AVAILABLE(ios(12.0))
    AuthenticateiOS12(NSURL* url, NSString* urlScheme);

    API_AVAILABLE(ios(12.0))
    virtual ~AuthenticateiOS12();

    API_AVAILABLE(ios(12.0))
    virtual void start();
private:
    API_AVAILABLE(ios(12.0)) ASWebAuthenticationSession* session;
};

#endif

#if __IPHONE_OS_VERSION_MAX_ALLOWED >= 130000

API_AVAILABLE(ios(13.0))
@interface WebAuthenticationPresentationContextProvider : NSObject<ASWebAuthenticationPresentationContextProviding>
@end

class AuthenticateiOS13 : public IAuthenticateSession
{
public:
    API_AVAILABLE(ios(13.0))
    AuthenticateiOS13(NSURL* url, NSString* urlScheme);

    API_AVAILABLE(ios(13.0))
    virtual ~AuthenticateiOS13();

    API_AVAILABLE(ios(13.0))
    virtual void start();
private:
    API_AVAILABLE(ios(13.0)) ASWebAuthenticationSession* session;
    API_AVAILABLE(ios(13.0)) WebAuthenticationPresentationContextProvider* provider;
};

#endif


#endif
