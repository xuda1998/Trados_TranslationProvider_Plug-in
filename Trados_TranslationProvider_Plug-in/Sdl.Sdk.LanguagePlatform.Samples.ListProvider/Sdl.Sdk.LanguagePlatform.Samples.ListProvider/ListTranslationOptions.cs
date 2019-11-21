using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using System.Windows.Forms;

namespace Sdl.Sdk.LanguagePlatform.Samples.ListProvider
{
    public class ListTranslationOptions
    {
        public static readonly TranslationMethod ProviderTranslationMethod = TranslationMethod.Other;
        TranslationProviderUriBuilder _uriBuilder;

        public ListTranslationOptions()
        {
            _uriBuilder = new TranslationProviderUriBuilder(ListTranslationProvider.ListTranslationProviderScheme);
        }
        public ListTranslationOptions(Uri uri)
        {
            _uriBuilder = new TranslationProviderUriBuilder(uri);
        }
        public Uri Uri
        {
            get
            {
                return _uriBuilder.Uri;
            }
        }

        public string ListFileName
        {
            get { return GetStringParameter("listfile"); }
            set { SetStringParameter("listfile", value); }
        }
        public string Delimiter
        {
            get { return GetStringParameter("delimiter"); }
            set { SetStringParameter("delimiter", value); }
        }
        private void SetStringParameter(string p, string value)
        {
            _uriBuilder[p] = value;
        }
        private string GetStringParameter(string p)
        {
            string paramString = _uriBuilder[p];
            return paramString;
        }
    }
}
