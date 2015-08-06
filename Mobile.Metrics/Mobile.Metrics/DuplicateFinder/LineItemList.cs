//-----------------------------------------------------------------------
// <copyright file="LineItemList.cs" company="Anthony Steele">
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
    using System.Collections.Generic;

    /// <summary>
    /// A list of LineItems 
    /// </summary>
    /// <remarks>
    /// This list is used in several ways
    /// But mostly to group different instances of the same text
    /// i.e. the same line of text in multiple files
    /// </remarks>
    public class LineItemCollection : List<LineItem>
    {
        #region data
        
        /// <summary>
        /// number of characters in the lineLength
        /// </summary>
        private readonly int lineLength;

        /// <summary>
        /// Is this line included in reports?
        /// </summary>
        private bool included;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the LineItemCollection class
        /// </summary>
        public LineItemCollection()
        {
            this.lineLength = -1;
            this.included = true;
        }

        /// <summary>
        /// Initializes a new instance of the LineItemCollection class with a length
        /// </summary>
        /// <param name="lineLength">the line length</param>
        public LineItemCollection(int lineLength)
        {
            this.lineLength = lineLength;
            this.included = true;
        }

        #endregion

        #region properties

        /// <summary>
        ///  Gets the number of chars in the line
        /// </summary>
        public int LineLength
        {
            get { return this.lineLength; }
        }

        /// <summary>
        /// Gets a value indicating whether this line is reported upon?
        /// </summary>
        public bool Included
        {
            get { return this.included; }
        }

        #endregion

        #region operations

        /// <summary>
        /// Return following lines to all lines in the list
        /// </summary>
        /// <returns>a list of lines that follow this one</returns>
        public LineItemCollection Following()
        {
            LineItemCollection result = new LineItemCollection();
            foreach (LineItem item in this)
            {
                if (item.NextLine != null)
                {
                    result.Add(item.NextLine);
                }
            }

            return result;
        }

        /// <summary>
        /// Return a list containing items that are in both lists
        /// </summary>
        /// <param name="secondList">the other list</param>
        /// <returns>a list containing the items in the intersection</returns>
        public LineItemCollection Intersection(LineItemCollection secondList)
        {
            LineItemCollection result = new LineItemCollection(this.LineLength);

            foreach (LineItem item in this)
            {
                if (secondList.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        /// <summary>
        /// Make a copy of this list
        /// </summary>
        /// <returns>the new list</returns>
        public LineItemCollection Copy()
        {
            LineItemCollection result = new LineItemCollection(this.LineLength);
            result.AddRange(this);
            return result;
        }

        /// <summary>
        /// return a filtered list 
        /// containing only items that match the following list
        /// </summary>
        /// <param name="following">The following list</param>
        /// <param name="depth">Depth to look at</param>
        /// <returns>The filetered list</returns>
        public LineItemCollection FilterToFollowing(LineItemCollection following, int depth)
        {
            LineItemCollection result = new LineItemCollection(this.LineLength);

            foreach (LineItem item in this)
            {
                LineItem followingItem = item.FollowingLine(depth);

                if ((followingItem != null) && following.Contains(followingItem))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        /// <summary>
        /// Set all items processed
        /// </summary>
        /// <param name="count">number of lines to set processed</param>
        public void SetProcessed(int count)
        {
            foreach (LineItem item in this)
            {
                item.SetProcessed(count);
            }
        }

        /// <summary>
        /// Set this line not included
        /// </summary>
        public void Exclude()
        {
            this.included = false;
        }

        #endregion
    }
}
