using System.Collections.Generic;
using System.Linq;

namespace Unf.Core.Duo.Models
{
    internal class QueryStringBuilder
    {
        private readonly IDictionary<string, string> values = new Dictionary<string, string>();

        internal QueryStringBuilder Add<T>(string key, T? value) where T : struct
        {
            if (value.HasValue)
            {
                values.Add(key, value.Value.ToString());
            }
            return this;
        }

        internal QueryStringBuilder AddLimit(int? limit)
        {
            if (limit.HasValue)
            {
                values.Add("limit", limit.ToString());
            }
            return this;
        }

        internal QueryStringBuilder AddOffset(int? offset)
        {
            if (offset.HasValue)
            {
                values.Add("offset", offset.ToString());
            }
            return this;
        }

        internal QueryStringBuilder Add(string key, object value)
        {
            if (value != null)
            {
                values.Add(key, value.ToString());
            }
            return this;
        }

        public override string ToString()
        {
            IEnumerable<string> pairs = values.Select(x => $"{x.Key}={x.Value}");
            return string.Join("&", pairs);
        }
    }
}
