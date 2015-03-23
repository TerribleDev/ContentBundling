## What is this?

This is simply a framework to provide attributes around content bundling.

Instead of declaring your bundles directly in your content bundling provider, you can declare them in your view models.


## ContentBundling

Decorate your classes with attributes for content bundling


## Getting Started

### Decorating classes

To declare content to get bundled you simply need to decorate your classes with the appropriate attribute.

You also need to specify the name of the bundle, the output url, and the files to be bundled.

```csharp

    [CssBundle("bootstrap", "/assets/css/bootstrap", "/Content/bootstrap.css")]
    [JavaScriptBundleAttribute("require", "/assets/js/require", AsyncLoading.Defer, "/Scripts/require.js, "/Scripts/requireConfig.js")]
    public class MyViewModel
    {

    }

```

### Implementing IBundlesFactory

If you are using squishit we provide a [nuget](https://www.nuget.org/packages/tparnell.ContentBundling.Squishit/) package that contains a factory for squishit.

You need to implement an IBundlesFactory. This will be loaded from your assembly, unless you flag it not to in the constructor.

The IBundlesFactory implementation should do the actual processing of content minification. 



### Bundling Content


new Bundler(); 

When the bundler is constructed with no arguments it will find a suitable type that inherits from IBundleFactory to use with reflection.

You can also pass an object that inherits from the interface.


When you call `new Bundler().Bundle();` it will find the attributes and pass them to the bundlesfactory
