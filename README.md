# How to Navigate Through a Xamarin.Forms App - Sample Implementation

Navigation in the MVVM architectural pattern seems a pretty [tough task](http://stackoverflow.com/questions/9290269/how-to-navigate-through-windows-with-mvvm-light-for-wpf) and most commonly found solutions don't really satisfy me.
They are overly complex, involve lots of code or don't seem elegant at all. Some solutions just statically specify the target page as a `string` (in Windows/Windows Phone/UWP apps):

```csharp
this.NavigationService.Navigate("MainPage");
```

In Xamarin.Forms, navigation requires you to specify an instance of `Page` to navigate to. Usually, you would write code like this:

```csharp
this.Navigation.Navigate(new SubPage());
```

This is bad for a couple of reasons:

1. `Navigation` is a property of the `Page` type - you'll have to somehow pass this to your ViewModel *or* have some kind of glue in your code behind.
2. Since we're calling the constructor of `SubPage` here, we're coupling these classes tightly. This means we cannot comfortable test the navigation portion in our ViewModel.
3. Navigation without Pages is not possible - that means that unit tests would rely on the Xamarin.Forms framework, which they should not need to.

This repository contains a sample implementation of a pattern that solves these problems while still allowing easy configurability and short, elegant code.
If you want to know more, read my [blog post](https://blog.henrik-ilgen.de/index.php/2017/01/16/how-to-navigate-through-a-xamarin-forms-app/) where I discuss the code in more detail.