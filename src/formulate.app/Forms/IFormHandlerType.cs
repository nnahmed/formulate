﻿namespace formulate.app.Forms
{

    // Namespaces.
    using System;

    using Umbraco.Core.Composing;

    /// <summary>
    /// A contract for implementing a form submission handler.
    /// </summary>
    public interface IFormHandlerType : IDiscoverable
    {
        #region Properties

        /// <summary>
        /// Gets the AngularJS directive to render in the back office (e.g., "formulate-email-handler").
        /// </summary>
        string Directive { get; }

        /// <summary>
        /// Gets the label to display in the back office (e.g., "Email").
        /// </summary>
        string TypeLabel { get; }

        /// <summary>
        /// Gets the icon to display in the back office (e.g., "icon-formulate-email").
        /// </summary>
        string Icon { get; }

        /// <summary>
        /// Gets the GUID that uniquely identifies the form submission handler.
        /// </summary>
        /// <remarks>
        /// Used for serialization/deserialization.
        /// </remarks>
        Guid TypeId { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Deserializes the string configuration.
        /// </summary>
        /// <param name="configuration">
        /// The string configuration.
        /// </param>
        /// <returns>
        /// The deserialized configuration.
        /// </returns>
        object DeserializeConfiguration(string configuration);

        /// <summary>
        /// Preparation to handle the form submission.
        /// </summary>
        /// <param name="context">
        /// The submission context.
        /// </param>
        /// <param name="configuration">
        /// The form submission handler configuration.
        /// </param>
        /// <remarks>
        /// This is guaranteed to occur in the same thread as the form submission.
        /// </remarks>
        void PrepareHandleForm(FormSubmissionContext context, object configuration);

        /// <summary>
        /// Handles the form submission.
        /// </summary>
        /// <param name="context">
        /// The submission context.
        /// </param>
        /// <param name="configuration">
        /// The form submission handler configuration.
        /// </param>
        /// <remarks>
        /// This may or may not be called in a different thread than the form submission.
        /// </remarks>
        void HandleForm(FormSubmissionContext context, object configuration);

        #endregion
    }
}
