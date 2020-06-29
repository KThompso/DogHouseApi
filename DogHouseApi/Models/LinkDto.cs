namespace DogHouseApi.Models
{
    public class LinkDto
    {

        public string Href { get; private set; }

        public string Rel { get; private set; }

        public string Method { get; private set; }

        public LinkDto(string url, string rel, string method)
        {
            Href = url;
            Rel = rel;
            Method = method;
        }

        public override string ToString() => $"<{Href}>; rel=\"{Rel}\"";

    }
}
