//-----------------------------------------------------------------------
// <copyright file="DuplicateEventArgs.cs" company="Anthony Steele">
// This source forms part of the DuplicateFinder utility
// Hosted at http://www.codeplex.com/DuplicateFinder
//
// This source is available under the terms of the Microsoft Public License (Ms-PL)
// See http://duplicatefinder.codeplex.com/license
// All other rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DuplicateFinderLib
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The data given when a duplicate is found
    /// </summary>
    public class DuplicateEventArgs : EventArgs
    {
        #region data

        /// <summary>
        /// Number of line sin the duplicate
        /// </summary>
        private readonly int length;

        /// <summary>
        /// Places where the duplicate occurs
        /// </summary>
        private readonly LineItemCollection items;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the DuplicateEventArgs class with all the data
        /// </summary>
        /// <param name="length">number of lines in the duplicate</param>
        /// <param name="items">number of times that the duplicate occurs</param>
        public DuplicateEventArgs(int length, LineItemCollection items)
        {
            this.length = length;
            this.items = items;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the number of lines in the duplicate
        /// </summary>
        public int Length
        {
            get 
            { 
                return this.length; 
            }
        }

        /// <summary>
        /// Gets the places in which the duplicate text is found
        /// </summary>
        public IList<LineItem> Items
        {
            get 
            { 
                return this.items.AsReadOnly(); 
            }
        }

        #endregion
    }
}
