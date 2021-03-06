﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AdoManager;
using Dapper;

namespace Xomorod.Shared
{
    public static class CultureHelper
    {
        #region Vilad Cultures

        // Valid cultures
        private static readonly List<string> ValidCultures = new List<string>
        {
            "af",
            "af-ZA",
            "sq",
            "sq-AL",
            "gsw-FR",
            "am-ET",
            "ar",
            "ar-DZ",
            "ar-BH",
            "ar-EG",
            "ar-IQ",
            "ar-JO",
            "ar-KW",
            "ar-LB",
            "ar-LY",
            "ar-MA",
            "ar-OM",
            "ar-QA",
            "ar-SA",
            "ar-SY",
            "ar-TN",
            "ar-AE",
            "ar-YE",
            "hy",
            "hy-AM",
            "as-IN",
            "az",
            "az-Cyrl-AZ",
            "az-Latn-AZ",
            "ba-RU",
            "eu",
            "eu-ES",
            "be",
            "be-BY",
            "bn-BD",
            "bn-IN",
            "bs-Cyrl-BA",
            "bs-Latn-BA",
            "br-FR",
            "bg",
            "bg-BG",
            "ca",
            "ca-ES",
            "zh-HK",
            "zh-MO",
            "zh-CN",
            "zh-Hans",
            "zh-SG",
            "zh-TW",
            "zh-Hant",
            "co-FR",
            "hr",
            "hr-HR",
            "hr-BA",
            "cs",
            "cs-CZ",
            "da",
            "da-DK",
            "prs-AF",
            "div",
            "div-MV",
            "nl",
            "nl-BE",
            "nl-NL",
            "en",
            "en-AU",
            "en-BZ",
            "en-CA",
            "en-029",
            "en-IN",
            "en-IE",
            "en-JM",
            "en-MY",
            "en-NZ",
            "en-PH",
            "en-SG",
            "en-ZA",
            "en-TT",
            "en-GB",
            "en-US",
            "en-ZW",
            "et",
            "et-EE",
            "fo",
            "fo-FO",
            "fil-PH",
            "fi",
            "fi-FI",
            "fr",
            "fr-BE",
            "fr-CA",
            "fr-FR",
            "fr-LU",
            "fr-MC",
            "fr-CH",
            "fy-NL",
            "gl",
            "gl-ES",
            "ka",
            "ka-GE",
            "de",
            "de-AT",
            "de-DE",
            "de-LI",
            "de-LU",
            "de-CH",
            "el",
            "el-GR",
            "kl-GL",
            "gu",
            "gu-IN",
            "ha-Latn-NG",
            "he",
            "he-IL",
            "hi",
            "hi-IN",
            "hu",
            "hu-HU",
            "is",
            "is-IS",
            "ig-NG",
            "id",
            "id-ID",
            "iu-Latn-CA",
            "iu-Cans-CA",
            "ga-IE",
            "xh-ZA",
            "zu-ZA",
            "it",
            "it-IT",
            "it-CH",
            "ja",
            "ja-JP",
            "kn",
            "kn-IN",
            "kk",
            "kk-KZ",
            "km-KH",
            "qut-GT",
            "rw-RW",
            "sw",
            "sw-KE",
            "kok",
            "kok-IN",
            "ko",
            "ko-KR",
            "ky",
            "ky-KG",
            "lo-LA",
            "lv",
            "lv-LV",
            "lt",
            "lt-LT",
            "wee-DE",
            "lb-LU",
            "mk",
            "mk-MK",
            "ms",
            "ms-BN",
            "ms-MY",
            "ml-IN",
            "mt-MT",
            "mi-NZ",
            "arn-CL",
            "mr",
            "mr-IN",
            "moh-CA",
            "mn",
            "mn-MN",
            "mn-Mong-CN",
            "ne-NP",
            "no",
            "nb-NO",
            "nn-NO",
            "oc-FR",
            "or-IN",
            "ps-AF",
            "fa",
            "fa-IR",
            "pl",
            "pl-PL",
            "pt",
            "pt-BR",
            "pt-PT",
            "pa",
            "pa-IN",
            "quz-BO",
            "quz-EC",
            "quz-PE",
            "ro",
            "ro-RO",
            "rm-CH",
            "ru",
            "ru-RU",
            "smn-FI",
            "smj-NO",
            "smj-SE",
            "se-FI",
            "se-NO",
            "se-SE",
            "sms-FI",
            "sma-NO",
            "sma-SE",
            "sa",
            "sa-IN",
            "sr",
            "sr-Cyrl-BA",
            "sr-Cyrl-SP",
            "sr-Latn-BA",
            "sr-Latn-SP",
            "nso-ZA",
            "tn-ZA",
            "si-LK",
            "sk",
            "sk-SK",
            "sl",
            "sl-SI",
            "es",
            "es-AR",
            "es-BO",
            "es-CL",
            "es-CO",
            "es-CR",
            "es-DO",
            "es-EC",
            "es-SV",
            "es-GT",
            "es-HN",
            "es-MX",
            "es-NI",
            "es-PA",
            "es-PY",
            "es-PE",
            "es-PR",
            "es-ES",
            "es-US",
            "es-UY",
            "es-VE",
            "sv",
            "sv-FI",
            "sv-SE",
            "syr",
            "syr-SY",
            "tg-Cyrl-TJ",
            "tzm-Latn-DZ",
            "ta",
            "ta-IN",
            "tt",
            "tt-RU",
            "te",
            "te-IN",
            "th",
            "th-TH",
            "bo-CN",
            "tr",
            "tr-TR",
            "tk-TM",
            "ug-CN",
            "uk",
            "uk-UA",
            "wen-DE",
            "ur",
            "ur-PK",
            "uz",
            "uz-Cyrl-UZ",
            "uz-Latn-UZ",
            "vi",
            "vi-VN",
            "cy-GB",
            "wo-SN",
            "sah-RU",
            "ii-CN",
            "yo-NG"
        };

        #endregion

        // Include ONLY cultures we are implementing
        public static readonly List<string> Cultures;

        // Include ONLY languages we are implementing
        public static Dictionary<string, Language> Languages { get; }

        static CultureHelper()
        {
            var langs = Connections.Xomorod.SqlConn.Query<Language>("Select * From udfv_LanguagesView()").ToList();

            Languages = langs.ToDictionary(l => l.Culture, l => l);
            Cultures = langs.Select(l => l.Culture).ToList();
        }

        /// <summary>
        /// Returns true if the language is a right-to-left language. Otherwise, false.
        /// </summary>
        public static bool IsRighToLeft()
        {
            return CultureInfo.DefaultThreadCurrentCulture?.TextInfo?.IsRightToLeft ?? Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft;
        }

        /// <summary>
        /// Returns right if the language is a right-to-left language. Otherwise, left.
        /// </summary>
        public static string GetTextAlign()
        {
            return (CultureInfo.DefaultThreadCurrentCulture?.TextInfo?.IsRightToLeft ??
                Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft) ? "right" : "left";
        }

        /// <summary>
        /// Returns right if the language is a right-to-left language. Otherwise, left.
        /// </summary>
        public static string GetDirection()
        {
            return
                (CultureInfo.DefaultThreadCurrentCulture?.TextInfo?.IsRightToLeft ??
                Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft) ? "rtl" : "ltr";
        }

        /// <summary>
        /// Returns a valid culture name based on "name" parameter. If "name" is not valid, it returns the default culture "en-US"
        /// </summary>
        /// <param name="name">Culture's name (e.g. en-US)</param>
        public static string GetImplementedCulture(string name)
        {
            // make sure it's not null
            if (string.IsNullOrEmpty(name))
                return GetDefaultCulture(); // return Default culture
            // make sure it is a valid culture first
            if (!ValidCultures.Any(c => c.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
                return GetDefaultCulture(); // return Default culture if it is invalid
            // if it is implemented, accept it
            if (Cultures.Any(c => c.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
                return name; // accept it
            // Find a close match. For example, if you have "en-US" defined and the user requests "en-GB", 
            // the function will return closes match that is "en-US" because at least the language is the same (ie English) 

            var n = GetNeutralCulture(name);
            foreach (var c in Cultures)
                if (c.StartsWith(n))
                    return c;
            // else 
            // It is not implemented
            return GetDefaultCulture(); // return Default culture as no match found
        }

        public static string GetReferrerUrlByCulture(this HttpRequestBase request, string culture)
        {
            // Split the url to url + query string
            var fullUrl = request.UrlReferrer?.ToString();
            var questionMarkIndex = fullUrl?.IndexOf('?');
            string queryString = null;
            string url = fullUrl ?? "";
            if (questionMarkIndex != -1 && questionMarkIndex != null) // There is a QueryString
            {
                url = fullUrl.Substring(0, (int)questionMarkIndex);
                queryString = fullUrl.Substring((int)questionMarkIndex + 1);
            }

            // Arranges
            var req = new HttpRequest(null, url, queryString);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(req, response);

            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

            // Extract the data    
            if (routeData != null)
            {
                var values = routeData.Values;
                var controllerName = values["controller"] + "/";
                var actionName = values["action"].ToString().ToLower().Equals("index") ? "" : values["action"] + "/";
                var routValues = request.UrlReferrer?.Query;
                culture += string.IsNullOrEmpty(culture) ? "" : "/";
                //var areaName = values["area"];

                var newRout = $"/{culture}{controllerName}{actionName}{routValues}";
                return newRout;
            }

            return "/";
        }


        public static string GetUrlCulture(this HttpRequestBase request, bool getDefultCultureIfNotExist = true)
        {
            var path = request.Path;
            if (path.IndexOf("/", StringComparison.Ordinal) != 0 || path.Length < 3)
                return getDefultCultureIfNotExist ? GetDefaultCulture() : null;

            return path.Substring(1, 2);
        }

        /// <summary>
        /// Returns default culture name which is the first name decalared (e.g. en-US)
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultCulture()
        {
            return "en"; // return Default culture
        }

        public static string GetCurrentCulture()
        {
            return CultureInfo.DefaultThreadCurrentCulture?.Name ??
                Thread.CurrentThread.CurrentCulture.Name;
        }

        public static string GetCurrentCultureTwoLetter()
        {
            return CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName.ToLower()
                ?? Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower();
        }

        public static string GetCurrentNeutralCulture()
        {
            return GetNeutralCulture(CultureInfo.DefaultThreadCurrentCulture?.Name ?? Thread.CurrentThread.CurrentCulture.Name);
        }

        public static string GetNeutralCulture(string name)
        {
            if (!name.Contains("-")) return name;

            return name.Split('-')[0]; // Read first part only. E.g. "en", "es"
        }


        public static List<SelectListItem> LanguageSelectListItems()
        {
            var currentCulture = GetCurrentCultureTwoLetter();

            //var lstGroup = new SelectListGroup()
            //{
            //    Name = Localization.SelectLang
            //};

            var res = Languages.Select(lang => new SelectListItem()
            {
                Text = lang.Value.LangFullName,
                Value = lang.Key,
                //Group = lstGroup,
                Selected = string.Equals(currentCulture, lang.Key, StringComparison.CurrentCultureIgnoreCase)
            }).ToList();

            return res;
        }
    }
}