using System;
using Foundation;
using MXParallaxHeader;
using ObjCRuntime;
using UIKit;

// @interface MXParallaxHeader : NSObject
[BaseType (typeof(NSObject))]
interface MXParallaxHeader
{
	// @property (readonly, nonatomic) UIView * _Nonnull contentView;
	[Export ("contentView")]
	UIView ContentView { get; }

	[Wrap ("WeakDelegate")]
	[NullAllowed]
	MXParallaxHeaderDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<MXParallaxHeaderDelegate> _Nullable delegate __attribute__((iboutlet));
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (nonatomic, strong) UIView * _Nullable view __attribute__((iboutlet));
	[NullAllowed, Export ("view", ArgumentSemantic.Strong)]
	UIView View { get; set; }

	// @property (nonatomic) CGFloat height;
	[Export ("height")]
	nfloat Height { get; set; }

	// @property (nonatomic) CGFloat minimumHeight;
	[Export ("minimumHeight")]
	nfloat MinimumHeight { get; set; }

	// @property (nonatomic) MXParallaxHeaderMode mode;
	[Export ("mode", ArgumentSemantic.Assign)]
	MXParallaxHeaderMode Mode { get; set; }

	// @property (readonly, nonatomic) CGFloat progress;
	[Export ("progress")]
	nfloat Progress { get; }
}

// @protocol MXParallaxHeaderDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface MXParallaxHeaderDelegate
{
	// @optional -(void)parallaxHeaderDidScroll:(MXParallaxHeader * _Nonnull)parallaxHeader;
	[Export ("parallaxHeaderDidScroll:")]
	void ParallaxHeaderDidScroll (MXParallaxHeader parallaxHeader);
}

// @protocol MXParallaxHeader <MXParallaxHeaderDelegate>
[Protocol, Model]
interface MXParallaxHeader : IMXParallaxHeaderDelegate
{
}

// @interface MXParallaxHeader (UIScrollView)
[Category]
[BaseType (typeof(UIScrollView))]
interface UIScrollView_MXParallaxHeader
{
	// @property (nonatomic, strong) MXParallaxHeader * _Nonnull parallaxHeader __attribute__((iboutlet));
	[Export ("parallaxHeader", ArgumentSemantic.Strong)]
	MXParallaxHeader ParallaxHeader { get; set; }
}

// @protocol MXScrollViewDelegate <UIScrollViewDelegate>
[Protocol, Model]
interface MXScrollViewDelegate : IUIScrollViewDelegate
{
	// @optional -(BOOL)scrollView:(MXScrollView * _Nonnull)scrollView shouldScrollWithSubView:(UIScrollView * _Nonnull)subView;
	[Export ("scrollView:shouldScrollWithSubView:")]
	bool ShouldScrollWithSubView (MXScrollView scrollView, UIScrollView subView);
}

// @interface MXScrollView : UIScrollView
[BaseType (typeof(UIScrollView))]
interface MXScrollView
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	MXScrollViewDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<MXScrollViewDelegate> _Nullable delegate __attribute__((iboutlet));
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }
}

// @interface MXScrollViewController : UIViewController
[BaseType (typeof(UIViewController))]
interface MXScrollViewController
{
	// @property (readonly, nonatomic) MXScrollView * _Nonnull scrollView;
	[Export ("scrollView")]
	MXScrollView ScrollView { get; }

	// @property (nonatomic, strong) UIViewController * _Nullable headerViewController;
	[NullAllowed, Export ("headerViewController", ArgumentSemantic.Strong)]
	UIViewController HeaderViewController { get; set; }

	// @property (nonatomic, strong) UIViewController * _Nullable childViewController;
	[NullAllowed, Export ("childViewController", ArgumentSemantic.Strong)]
	UIViewController ChildViewController { get; set; }
}

// @interface MXParallaxHeader (UIViewController)
[Category]
[BaseType (typeof(UIViewController))]
interface UIViewController_MXParallaxHeader
{
	// @property (readonly, nonatomic) MXParallaxHeader * _Nullable parallaxHeader;
	[NullAllowed, Export ("parallaxHeader")]
	MXParallaxHeader ParallaxHeader { get; }
}

// @interface MXParallaxHeaderSegue : UIStoryboardSegue
[BaseType (typeof(UIStoryboardSegue))]
interface MXParallaxHeaderSegue
{
}

// @interface MXScrollViewControllerSegue : UIStoryboardSegue
[BaseType (typeof(UIStoryboardSegue))]
interface MXScrollViewControllerSegue
{
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern double MXParallaxHeaderVersionNumber;
	[Field ("MXParallaxHeaderVersionNumber", "__Internal")]
	double MXParallaxHeaderVersionNumber { get; }

	// extern const unsigned char [] MXParallaxHeaderVersionString;
	[Field ("MXParallaxHeaderVersionString", "__Internal")]
	byte[] MXParallaxHeaderVersionString { get; }
}
