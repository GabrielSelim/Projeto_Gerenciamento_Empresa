﻿using System.Text;

namespace Projeto_Gabriel.Application.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; }
        private string href;
        public string Href
        {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(href);
                    return sb.Replace("%2F", "/").ToString();
                }
            }
            set {
                href = value; 
            }
        }
        public string Type { get; set; }
        public string Action { get; set; }
    }
}
