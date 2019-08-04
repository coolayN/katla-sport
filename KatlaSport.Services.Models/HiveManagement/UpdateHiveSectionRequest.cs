﻿namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a request for creating and updating a hiveSection.
    /// </summary>
    public class UpdateHiveSectionRequest
    {
        /// <summary>
        /// Gets or sets a store hiveSection name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a store hiveSection code.
        /// </summary>
        public string Code { get; set; }
    }
}
