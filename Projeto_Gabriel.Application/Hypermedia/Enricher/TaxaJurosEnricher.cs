using Microsoft.AspNetCore.Mvc;
using Projeto_Gabriel.Application.Hypermedia.Constants;
using Projeto_Gabriel.Application.Dto;
using System.Text;

namespace Projeto_Gabriel.Application.Hypermedia.Enricher
{
    public class TaxaJurosEnricher : ContentResponseEnricher<TaxaJurosDboRetorno>
    {
        protected override Task EnrichModel(TaxaJurosDboRetorno content, IUrlHelper urlHelper)
        {
            var path = "api/TaxaJuros";
            string link = GetLink(urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PATCH,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPatch
            });

            return Task.CompletedTask;
        }

        private string GetLink(IUrlHelper urlHelper, string path)
        {
            lock (this)
            {
                var url = new { controller = path };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            }
        }
    }
}