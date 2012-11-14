using System.Text.RegularExpressions;

namespace IntiCms.BusinessLogic
{
    public static class SlugUtil
    {
        static readonly Regex AlphaOnlyRe = new Regex("[^a-z0-9]+", RegexOptions.Compiled);

        public static string FixSlug(this string slug)
        {
            var result = slug.ToLower();

             result = AlphaOnlyRe.Replace(result, "-");

            result = result.TrimStart('-');

            return result;
        }
    }
}

