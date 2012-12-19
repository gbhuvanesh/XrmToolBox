﻿// PROJECT : MsCrmTools.WebResourcesManager
// This project was developed by Tanguy Touzard
// CODEPLEX: http://xrmtoolbox.codeplex.com
// BLOG: http://mscrmtools.blogspot.com

using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using MsCrmTools.WebResourcesManager.Forms;

namespace MsCrmTools.WebResourcesManager
{
    class WebResource
    {
        private static readonly Regex InValidWrNameRegex = new Regex("[^a-z0-9A-Z_\\./]|[/]{2,}", (RegexOptions.Compiled | RegexOptions.CultureInvariant));

        public string FilePath { get; set; }
        public Entity WebResourceEntity { get; set; }

        public WebResource(Entity webResource, string filePath)
        {
            FilePath = filePath;
            WebResourceEntity = webResource;
        }

        public WebResource(Entity webresource)
            : this(webresource, string.Empty)
        {}

        public static int GetTypeFromExtension(string ext)
        {
            switch (ext)
            {
                case "htm":
                case "html":
                    return 1;
                case "css":
                    return 2;
                case "js":
                    return 3;
                case "xml":
                    return 4;
                case "png":
                    return 5;
                case "jpg":
                case "jpeg":
                    return 6;
                case "gif":
                    return 7;
                case "xap":
                    return 8;
                case "xsl":
                    return 9;
                default:
                    return 10;
            }
        }

        public static int GetImageIndexFromExtension(string ext)
        {
            switch (ext)
            {
                case "htm":
                case "html":
                    return 2;
                case "css":
                    return 3;
                case "js":
                    return 4;
                case "xml":
                    return 5;
                case "png":
                    return 6;
                case "jpg":
                case "jpeg":
                    return 7;
                case "gif":
                    return 8;
                case "xap":
                    return 9;
                case "xsl":
                    return 10;
                default:
                    return 11;
            }
        }

        public static bool IsInvalidName(string name)
        {
            return InValidWrNameRegex.IsMatch(name);
        }

        public WebResource ShowProperties(IOrganizationService service, Control mainControl)
        {
            var form = new UpdateForm(this, service)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (form.ShowDialog(mainControl) == DialogResult.OK)
            {
                return form.WebRessource;
            }

            return this;
        }
    }
}