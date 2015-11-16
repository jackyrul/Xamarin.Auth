/*
	http://cakebuild.net/docs
*/
#addin "Cake.Xamarin"
#addin "Cake.XCode"

#load "../common.cake"
//#load "../../common.moljac.cake"

CakeSpec.Libs = new ISolutionBuilder []
{
	new DefaultSolutionBuilder {
		IsWindowsCompatible = true,
		IsMacCompatible = false,
		SolutionPath = "./source/Xamarin.Auth-Library.Windows.VisualStudio-wo.Xamarin.Forms.sln",
		OutputFiles = new [] {
			new OutputFileCopy
			{
				FromFile = "./source/Xamarin.Auth.WindowsPhone8/Bin/Release/Xamarin.Auth.dll",
				ToDirectory= "./output/wp80/"
			},
	      /*
	      NOTE: postpone these until windows build cake works to build x86 and ARM

				NOTE: xamarin-component has no library tag for WinRT

				https://developer.xamarin.com/guides/cross-platform/advanced/submitting_components/component_submission_guide/#Compulsory_tags

				new OutputFileCopy
				{
					FromFile = "./source/Xamarin.Auth.WindowsPhone81/Bin/ARM/Release/Xamarin.Auth.dll",
					ToDirectory= "./output/wpa81/"
				},
				new OutputFileCopy
				{
					FromFile = "./source/Xamarin.Auth.WindowsStore81WinRT/Bin/ARM/Release/Xamarin.Auth.dll",
					ToDirectory= "./output/win8/"
				},
	      */			
		}

	},
	new IOSSolutionBuilder
	{
		// everything on MacOSX with Xamarin.Studio
		SolutionPath = "./source/Xamarin.Auth-Library-MacOSX-Xamarin.Studio-wo-Xamarin.Forms.sln",
		OutputFiles = new []
		{
			/*
			Xamarin Component
			https://developer.xamarin.com/guides/cross-platform/advanced/submitting_components/component_submission_guide/#Appendix_1_-_Component.Yaml_tags
					pcl:
					android:
					ios-unified:
					ios:
					winphone-8.0:
					winphone-8.1:
					mac-unified:
					mac:
					winphone-7.0:
					winphone-7.1:

			Nuget
				https://docs.nuget.org/create/enforced-package-conventions
				http://blog.nuget.org/20150729/Introducing-nuget-uwp.html
				http://blogs.msdn.com/b/mim/archive/2013/08/27/packaging-a-windows-store-apps-component-with-nuget-part-1.aspx
				http://blogs.msdn.com/b/mim/archive/2013/09/02/packaging-a-windows-store-apps-component-with-nuget-part-2.aspx
				http://blogs.msdn.com/b/lucian/archive/2015/09/15/writing-a-nuget-package-for-vs2015-rtm-repost.aspx

					Framework Name											Abbreviations
					.NET Framework											net
					Silverlight													sl
					.NETMicroFramework									netmf
					Windows Store												win
					Windows Phone (Silverlight-based)		wp
					Windows Phone App (WinRT-based)			wpa



					Description	Base Code	Available versions
					Managed framework applications (WinForms, Console Applications, WPF, ASP.NET)
						net	net11, net20, net35, net35-client, net35-full, net4, net40, net40-client, net40-full, net403, net45, net451, net452, net46
					ASP.NET 5
						dnxcore	dnxcore50
					Windows Store	netcore	win8 = netcore45, win81 = netcore451, uap10.0
					Windows Phone (appx model)	wpa	wpa81
					Windows Phone (Silverlight)	wp	wp7 = sl3-wp, wp71 = sl4-wp71, sl4-wp, wp8 = wp8-, wp81
					Silverlight	sl	sl2, sl3 = sl30, sl4 = sl40, sl5 = sl50
					Xamarin		mono, MonoMac, Xamarin.Mac, MonoAndroid10, MonoTouch10, Xamarin.iOS10
					Compact Framework	net-cf	net20-cf, net35-cf = cf35, net40-cf
					Micro Framework	netmf	netmf41, netmf42, netmf43

			*/
			new OutputFileCopy
			{
				FromFile = "./source/Xamarin.Auth.Portable/bin/Release/Xamarin.Auth.dll",
				ToDirectory= "./output/pcl/"
			},
			new OutputFileCopy
			{
				FromFile = "./source/Xamarin.Auth.XamarinAndroid/bin/Release/Xamarin.Auth.dll",
				ToDirectory= "./output/android/"
			},
			new OutputFileCopy
			{
				FromFile = "./source/Xamarin.Auth.XamarinIOS/bin/Release/Xamarin.Auth.dll",
				ToDirectory= "./output/ios-unified/"
			},
			new OutputFileCopy
			{
				FromFile = "./source/Xamarin.Auth.XamarinIOS-Classic/bin/Release/Xamarin.Auth.dll",
				ToDirectory= "./output/ios/"
			},
		}
	},
};

CakeSpec.Samples = new ISolutionBuilder []
{
	new IOSSolutionBuilder
	{
			SolutionPath = "./samples/Traditional.Standard/references01projects/Xamarin.Auth.Samples.TraditionalStandard-MacOSX-Xamarin.Studio.sln"
	},
	new DefaultSolutionBuilder
	{
			SolutionPath = "./samples/Traditional.Standard/references01projects/old-for-backward-compatiblity/Xamarin.Auth.Sample.Android/Xamarin.Auth.Sample.Android.sln",			
	},
	new IOSSolutionBuilder
	{
			SolutionPath = "./samples/Traditional.Standard/references01projects/old-for-backward-compatiblity/Xamarin.Auth.Sample.iOS/Xamarin.Auth.Sample.iOS.sln"
	},
	/*
	./samples/Traditional.Standard/references02nuget/Xamarin.Auth.Sample.Android/Xamarin.Auth.Sample.Android.sln
	./samples/Traditional.Standard/references02nuget/Xamarin.Auth.Sample.iOS/Xamarin.Auth.Sample.iOS.sln
	./samples/Traditional.Standard/references02nuget/Xamarin.Auth.Sample.WinPhone8/Xamarin.Auth.Sample.WinPhone.sln
	./samples/Traditional.Standard/references02nuget/Xamarin.Auth.Samples.TraditionalStandard.sln
	./samples/Traditional.Standard/references03component/Xamarin.Auth.Sample.Android/Xamarin.Auth.Sample.Android.sln
	./samples/Traditional.Standard/references03component/Xamarin.Auth.Sample.iOS/Xamarin.Auth.Sample.iOS.sln
	./samples/Traditional.Standard/references03component/Xamarin.Auth.Sample.WinPhone8/Xamarin.Auth.Sample.WinPhone.sln
	./samples/Traditional.Standard/references03component/Xamarin.Auth.Samples.TraditionalStandard.sln
	./samples/Xamarin.Auth.Samples.sln
	./samples/Xamarin.Forms/references01project/XamarinAuth.XamarinForms.sln
	new DefaultSolutionBuilder
	{
			SolutionPath = ""
	},
	*/
};

CakeSpec.NuSpecs = new []
{
	"./nuget/Xamarin.Auth.nuspec"
};

DefineDefaultTasks ();

RunTarget (TARGET);

