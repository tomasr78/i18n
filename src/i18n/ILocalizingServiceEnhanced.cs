﻿namespace i18n
{
    /// <summary>
    /// Defines a service for retrieving localized text from a data source using the
    /// DefaultSettings.LanguageMatching.Enhanced algorithm.
    /// </summary>
    public interface ILocalizingServiceEnhanced
    {
        /// <summary>
        /// Looks up and returns localized text for a resource id using the
        /// DefaultSettings.LanguageMatching.Enhanced algorithm.
        /// </summary>
        /// <param name="key">
        /// Idenfities the msgid of the subject resource.
        /// Null if we are not interested in a particular resource but wish to know
        /// the best matching language for which ANY resources are available (one or more).
        /// </param>
        /// <param name="languages">
        /// A list of language preferences, sorted in order or preference (most preferred first).
        /// </param>
        /// <param name="o_langtag">
        /// On success, outputs a description of the language from which the resource was selected.
        /// </param>
        /// <param name="maxPasses">
        /// 0 - allow exact match only
        /// 1 - allow exact match or default-region match only
        /// 2 - allow exact match or default-region match or script match only
        /// 3 - allow exact match or default-region match or script match or language match only
        /// 4 - allow exact match or default-region match or script or language match only, or failing return the default language.
        /// -1 to set to most tolerant (i.e. 4).
        /// </param>
        /// <returns>
        /// When key is set to non-null, returns either the sucessully-looked up localized string, or 
        /// null if the lookup failed.
        /// When key is set to null, returns "" to indicate a match to a PO-valid language was made
        /// (PO-valid meaning that one or more messages/resources are defined for that language),
        /// or null if no match was made.
        /// </returns>
        string GetText(
            string key, 
            LanguageItem[] languages, 
            out LanguageTag o_langtag,
            int maxPasses = -1);
    }
}
