﻿// Copyright (c) 2019 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Cinephile.Core.Rest.Dtos.ImageConfigurations
{
    /// <summary>
    /// Gets information about a image.
    /// </summary>
    [SuppressMessage("Design", "CA2227: Change to be read-only by removing the property setter.", Justification = "Used in DTO object.")]
    public class ImagesDto
    {
        /// <summary>
        /// Gets or sets the base url to the image.
        /// </summary>
        [JsonPropertyName("base_url")]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the url to the secure image location.
        /// </summary>
        [JsonPropertyName("secure_base_url")]
        public string SecureBaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the backdrop sizes.
        /// </summary>
        [JsonPropertyName("backdrop_sizes")]
        public IList<string> BackdropSizes { get; set; }

        /// <summary>
        /// Gets or sets the logo sizes.
        /// </summary>
        [JsonPropertyName("logo_sizes")]
        public IList<string> LogoSizes { get; set; }

        /// <summary>
        /// Gets or sets the poster sizes.
        /// </summary>
        [JsonPropertyName("poster_sizes")]
        public IList<string> PosterSizes { get; set; }

        /// <summary>
        /// Gets or sets the profile sizes.
        /// </summary>
        [JsonPropertyName("profile_sizes")]
        public IList<string> ProfileSizes { get; set; }

        /// <summary>
        /// Gets or sets the still sizes.
        /// </summary>
        [JsonPropertyName("still_sizes")]
        public IList<string> StillSizes { get; set; }
    }
}
