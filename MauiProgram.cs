using Elephonkey.Services;
using Elephonkey.ViewViewModels.Appcontents;
using Elephonkey.ViewViewModels.AppContents;

namespace Elephonkey;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.RegisterAppServices()
            	.RegisterViewModels()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("NotoSerif-Bold.ttf", "NotoSerifBold");
				fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemibold");
                fonts.AddFont("Poppins-Regular.ttf", "Poppins");
				fonts.AddFont("MaterialIconsOutlined-Regular.otf", "Material");
            });

		return builder.Build();
	}

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<INewsService, MockNewsService>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<HomePageViewModel>();
        mauiAppBuilder.Services.AddTransient<SurveyPageViewModel>();
        mauiAppBuilder.Services.AddTransient<ArticlesPageViewModel>();
        mauiAppBuilder.Services.AddTransient<ResultsPageViewModel>();
	mauiAppBuilder.Services.AddTransient<SettingsPageViewModel>();

        mauiAppBuilder.Services.AddTransient<HomePageView>();
        mauiAppBuilder.Services.AddTransient<SurveyPageView>();
        mauiAppBuilder.Services.AddTransient<ArticlesPageView>();
        mauiAppBuilder.Services.AddTransient<ResultsPageView>();
	mauiAppBuilder.Services.AddTransient<SettingsPageView>();

        return mauiAppBuilder;
    }
}
