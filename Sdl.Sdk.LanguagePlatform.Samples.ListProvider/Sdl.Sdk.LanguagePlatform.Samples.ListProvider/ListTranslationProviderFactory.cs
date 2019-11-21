using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sdl.LanguagePlatform.Core;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using Sdl.Sdk.LanguagePlatform.Samples.ListProvider;

namespace Sdl.Sdk.LanguagePlatform.Samples.ListProvider
{
    [TranslationProviderFactory(Id = "Translation_Provider_Plug_inFactory",
                                Name = "Translation_Provider_Plug_inFactory",
                                Description = "Translation_Provider_Plug_inFactory")]
    class ListTranslationProviderFactory : ITranslationProviderFactory
    {
        #region ITranslationProviderFactory Members

        public ITranslationProvider CreateTranslationProvider(Uri translationProviderUri, string translationProviderState, ITranslationProviderCredentialStore credentialStore)
        {
            var loadOptions = new ListTranslationOptions(translationProviderUri);

            if (!SupportsTranslationProviderUri(translationProviderUri)) //是否支持uri格式
            {
                throw new Exception("Cannot handle URI.");
            }

            var tp = new ListTranslationProvider(loadOptions);

            return tp;
        }

        public TranslationProviderInfo GetTranslationProviderInfo(Uri translationProviderUri, string translationProviderState)
        {
            TranslationProviderInfo info = new TranslationProviderInfo();

            info.TranslationMethod = ListTranslationOptions.ProviderTranslationMethod;

            info.Name = PluginResources.Plugin_NiceName;

            return info;
        }

        public bool SupportsTranslationProviderUri(Uri translationProviderUri)
        {
            if (translationProviderUri == null)
            {
                throw new ArgumentNullException("Translation provider URI not supported.");
            }
            return String.Equals(translationProviderUri.Scheme, ListTranslationProvider.ListTranslationProviderScheme, StringComparison.OrdinalIgnoreCase);
        }

        #endregion
    }
}
