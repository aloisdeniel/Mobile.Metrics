//-----------------------------------------------------------------------
// <copyright file="LineItem.cs" company="Anthony Steele">
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
    using System.Globalization;

    /// <summary>
    /// Data about a line of text in a file
    /// </summary>
    public class LineItem
    {
        #region data

        /// <summary>
        /// display name of the containing file
        /// </summary>
        private readonly string fileName;
        
        /// <summary>
        /// where it is in the text stream
        /// </summary>
        private readonly int lineNumber;

        /// <summary>
        /// other lines in other streams with the same text
        /// </summary>
        private readonly LineItemCollection parent;

        /// <summary>
        /// the line that follows it in the text stream
        /// </summary>
        private LineItem nextLine;

        /// <summary>
        /// has this line been repoarted as a duplicate yet
        /// </summary>
        private bool processed;

        private readonly string content;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the LineItem class
        /// </summary>
        /// <param name="parent">List to contain this item</param>
        /// <param name="fileName">name of the file</param>
        /// <param name="lineNumber">index of this line within the file</param>
        public LineItem(LineItemCollection parent, string fileName, int lineNumber, string content)
        {
            this.parent = parent;
            this.fileName = fileName;
            this.lineNumber = lineNumber;
            this.content = content;
        }
        #endregion

        #region public properties 

        public string Content
        {
            get
            {
                return this.content;
            }
        }

        /// <summary>
        /// Gets the name of the stream containing this line
        /// </summary>
        public string FileName
        {
            get 
            { 
                return this.fileName; 
            }
        }

        /// <summary>
        /// Gets the line number at which this item is found
        /// </summary>
        public int LineNumber
        {
            get 
            { 
                return this.lineNumber; 
            }
        }

        /// <summary>
        /// Gets the containing list of lines the same as this one
        /// </summary>
        public LineItemCollection Parent
        {
            get 
            { 
                return this.parent; 
            }
        }

        /// <summary>
        /// Gets or sets the line that follows this one in its text stream/file
        /// </summary>
        public LineItem NextLine
        {
            get { return this.nextLine; }
            set { this.nextLine = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this item has been reported as a duplicate already
        /// </summary>
        public bool Processed
        {
            get { return this.processed; }
            set { this.processed = value; }
        }

        /// <summary>
        /// Gets the number of (non-whitespace) chars
        /// </summary>
        public int Length
        {
            get 
            {
                if (this.Parent == null)
                {
                    return 0;
                }
                
                return this.Parent.LineLength;
            }
        }

        #endregion

        #region public

        /// <summary>
        /// Convert to a string for display
        /// </summary>
        /// <returns>Text showing this objects state</returns>
        public override string ToString()
        {
            return String.Format(
                CultureInfo.CurrentCulture, 
                "{0} line {1} len {2}", 
                this.FileName, 
                this.LineNumber, 
                this.Length);
        }

        /// <summary>
        /// Set this line processed
        /// </summary>
        public void SetProcessed()
        {
            this.SetProcessed(1);
        }

        /// <summary>
        /// Set this line and following lines to processed
        /// ie reported as a duplicate
        /// </summary>
        /// <param name="count">number of lines to set to processed</param>
        public void SetProcessed(int count)
        {
            this.Processed = true;

            if ((count > 1) && (this.NextLine != null))
            {
                this.NextLine.SetProcessed(count - 1);
            }
        }

        /// <summary>
        /// Get a line that follows this one
        /// </summary>
        /// <param name="depth">Number of lines to go on</param>
        /// <returns>the following line</returns>
        public LineItem FollowingLine(int depth)
        {
            if (depth <= 0)
            {
                return this;
            }

            if (this.NextLine == null)
            {
                return null;
            }

            return this.NextLine.FollowingLine(depth - 1);
        }

        /// <summary>
        /// Does the following list contain this item
        /// </summary>
        /// <param name="following">The list of following items</param>
        /// <param name="depth">how far to look</param>
        /// <returns>true if the following list contains this item</returns>
        public bool HasFollowing(LineItemCollection following, int depth)
        {
            if (following == null)
            {
                return false;
            }

            if (depth >= 0)
            {
                if (following.Contains(this))
                {
                    return true;
                }

                if (this.NextLine != null)
                {
                    return this.NextLine.HasFollowing(following, depth - 1);
                }
            }

            return false;
        }

        #endregion
    }
}
