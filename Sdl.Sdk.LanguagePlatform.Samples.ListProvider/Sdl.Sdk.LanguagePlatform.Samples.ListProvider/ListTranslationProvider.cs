using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sdl.LanguagePlatform.Core;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using System.IO;

namespace Sdl.Sdk.LanguagePlatform.Samples.ListProvider
{
    class ListTranslationProvider : ITranslationProvider
    {
        #region ITranslationProvider Members

        public static readonly string ListTranslationProviderScheme = "listprovider";
        public ListTranslationOptions Options
        {
            get;
            set;
        }

        public ListTranslationProvider(ListTranslationOptions options)  //构造函数
        {
            Options = options;
        }
        public ITranslationProviderLanguageDirection GetLanguageDirection(LanguagePair languageDirection)
        {
            return new ListTranslationProviderLanguageDirection(this, languageDirection);
        }

        public bool IsReadOnly => true;
        public void LoadState(string translationProviderState)
        {
        }

        public string Name  //provider的名称
        {
            get
            {
                return PluginResources.Plugin_Name;
            }
        }

        public void RefreshStatusInfo()
        {
            
        }

        public string SerializeState()
        {
            // Save settings
            return null;
        }

        public ProviderStatusInfo StatusInfo => new ProviderStatusInfo(true, PluginResources.Plugin_NiceName);

        public bool SupportsConcordanceSearch { get; } = false;

        public bool SupportsDocumentSearches { get; } = false;

        public bool SupportsFilters { get; } = false;
        public bool SupportsFuzzySearch
        {
            get { return false; }
        }

        public bool SupportsLanguageDirection(LanguagePair languageDirection)
        {
            return true;
        }

        
        public bool SupportsMultipleResults => false;

    
        public bool SupportsPenalties => true;


        public bool SupportsPlaceables => false;

        public bool SupportsScoring => false;

        public bool SupportsSearchForTranslationUnits => true;

        public bool SupportsSourceConcordanceSearch => false;

        public bool SupportsTargetConcordanceSearch => false;

        public bool SupportsStructureContext { get; } = false;

        public bool SupportsTaggedInput => true;



        public bool SupportsTranslation => true;

        public bool SupportsUpdate => false;


        public bool SupportsWordCounts => false;

        public TranslationMethod TranslationMethod => ListTranslationOptions.ProviderTranslationMethod;

        public Uri Uri => Options.Uri;

        #endregion
    }
}

