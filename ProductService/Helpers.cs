﻿using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Routing;
using Microsoft.OData;
//using Microsoft.OData.Core;
//using Microsoft.OData.Core.UriParser;
using Microsoft.OData.UriParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Routing;
//using System.Web.OData.Extensions;
//using System.Web.OData.Routing;

namespace ProductService
{
    public static class Helpers
    {
        public static TKey GetKeyFromUri<TKey>(HttpRequestMessage request, Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            var urlHelper = request.GetUrlHelper() ?? new UrlHelper(request);

            var pathHandler = (IODataPathHandler)request.GetRequestContainer().GetService(typeof(IODataPathHandler));

            string serviceRoot = urlHelper.CreateODataLink(
                request.ODataProperties().RouteName,
                pathHandler, new List<ODataPathSegment>());
            var odataPath = pathHandler.Parse(serviceRoot, uri.LocalPath, request.GetRequestContainer());

            var keySegment = odataPath.Segments.OfType<KeySegment>().FirstOrDefault();
            if (keySegment == null)
            {
                throw new InvalidOperationException("The link does not contain a key.");
            }

            var value = keySegment.Keys.FirstOrDefault().Value;
            return (TKey)value;
        }

    }
}