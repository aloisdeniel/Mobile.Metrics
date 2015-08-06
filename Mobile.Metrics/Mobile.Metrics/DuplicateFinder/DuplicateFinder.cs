//-----------------------------------------------------------------------
// <copyright file="DuplicateFinder.cs" company="Anthony Steele">
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
    using System.IO;

    /// <summary>
    /// The algorithm - the engine for finding duplicates
    /// It works on any text streams
    /// </summary>
    public class DuplicateFinderEngine
    {
        #region events

        #endregion

        #region constants
        
        /// <summary>
        /// By default, look for duplicates 5 or more lines long
        /// </summary>
        public const int DefaultDuplicateThreshold = 5;

        /// <summary>
        /// By default, the first line must contain at least 2 chars
        /// </summary>
        public const int DefaultFirstLineMinWidth = 2;

        #endregion

        #region data

        /// <summary>
        /// Data on all lines read in from all files
        /// Key is the (trimmed) line text
        /// </summary>
        private readonly Dictionary<string, LineItemCollection> lineData = new Dictionary<string, LineItemCollection>();

        /// <summary>
        /// only consider duplicates with this many lines or more in them
        /// </summary>
        private int duplicateThreshold = DefaultDuplicateThreshold;

        /// <summary>
        /// First line must have this many chars in it
        /// </summary>
        private int firstLineMinWidth = DefaultFirstLineMinWidth;

        /// <summary>
        /// Number of duplicates found
        /// </summary>
        private int duplicateCount;
        
        /// <summary>
        /// Lat item found
        /// </summary>
        private LineItem lastItem;

        /// <summary>
        /// The first lines of each text stream that has been read in
        /// </summary>
        private readonly List<LineItem> firstLines = new List<LineItem>();

        /// <summary>
        /// ignore lines that start with these strings
        /// </summary>
        private readonly List<string> ignoredLinePrefixes = new List<string>();

        #endregion

        #region constructors

        /// <summary>
        /// Create the engine
        /// </summary>
        public DuplicateFinderEngine()
        {
        }

        /// <summary>
        /// create the engine with a theshhold
        /// </summary>
        /// <param name="threshold">the duplicate threshold</param>
        public DuplicateFinderEngine(int threshold)
        {
            this.DuplicateThreshold = threshold;
        }

        #endregion

        /// <summary>
        /// To notify listeners of duplicates found
        /// </summary>
        public event EventHandler<DuplicateEventArgs> OnDuplicate;

        #region public properties

        /// <summary>
        /// Gets or sets how many lines must be the same 
        /// before it is considered a duplicate
        /// </summary>
        public int DuplicateThreshold
        {
            get { return this.duplicateThreshold; }
            set { this.duplicateThreshold = value; }
        }

        /// <summary>
        /// Gets or sets the number of non-whitespace chars 
        /// that first line must have 
        /// </summary>
        public int FirstLineMinWidth
        {
            get { return this.firstLineMinWidth; }
            set { this.firstLineMinWidth = value; }
        }

        /// <summary>
        /// Gets the number of duplicates found
        /// </summary>
        public int DuplicateCount
        {
            get { return this.duplicateCount; }
        }

        #endregion

        #region public interface

        /// <summary>
        /// Reset the state
        /// </summary>
        public void Clear()
        {
            this.lineData.Clear();
            this.duplicateCount = 0;
            this.ignoredLinePrefixes.Clear();
        }

        /// <summary>
        /// Ignore lines that start with this prefix
        /// </summary>
        /// <param name="prefix">the string prefix to ignore</param>
        public void AddIgnoredLinePrefix(string prefix)
        {
            if (!String.IsNullOrEmpty(prefix))
            {
                prefix = prefix.Trim();
            }

            if (!String.IsNullOrEmpty(prefix))
            {
                this.ignoredLinePrefixes.Add(prefix);
            }
        }

        /// <summary>
        /// Read in the text stream
        /// </summary>
        /// <param name="reader">the text source</param>
        /// <param name="sourceName">the display name of the source</param>
        public void ProcessText(TextReader reader, string sourceName)
        {
            this.lastItem = null;

            int lineNumber = 1;
            string line = ReadTrimmedLine(reader);
            while (line != null)
            {
                this.ProcessLine(line, sourceName, lineNumber);

                line = ReadTrimmedLine(reader);
                lineNumber++;
            }
        }

        /// <summary>
        /// find duplicates in data that has been read in
        /// compare all files to each other
        /// </summary>
        /// <returns>the number of files inspected</returns>
        public int FindDuplicates()
        {
            int count = 0;

            // look through each file
            foreach (LineItem firstLine in this.firstLines)
            {
                this.FindDuplicatesInFile(firstLine);
                count++;
            }

            return count;
        }

        /// <summary>
        /// Find duplicates - compare one file to all others
        /// </summary>
        /// <param name="fileName">the name of the file to focus on</param>
        /// <returns>the number of files inspected</returns>
        public int FindDuplicates(string fileName)
        {
            int count = 0;

            // look through each file
            foreach (LineItem firstLine in this.firstLines)
            {
                string itemFileName = Path.GetFileName(firstLine.FileName);
                if (String.Equals(fileName, itemFileName, StringComparison.CurrentCultureIgnoreCase))
                {
                    this.FindDuplicatesInFile(firstLine);
                    count++;
                }
            }

            return count;
        }

        #endregion

        #region private procs for reading in data 

        /// <summary>
        /// Read a line and trim it
        /// </summary>
        /// <param name="reader">the test source</param>
        /// <returns>the trimmed line of text</returns>
        private static string ReadTrimmedLine(TextReader reader)
        {
            string result = reader.ReadLine();
            if (!String.IsNullOrEmpty(result))
            {
                result = result.Trim();
            }

            return result;
        }

        /// <summary>
        /// Process a line of text from the file
        /// </summary>
        /// <param name="line">the text of the lineData</param>
        /// <param name="fileName">the name of the file</param>
        /// <param name="lineNumber">the index of the line in the file</param>
        private void ProcessLine(string line, string fileName, int lineNumber)
        {
            LineItemCollection itemList;

            if (! this.lineData.ContainsKey(line))
            {
                // this lines text has not been encountered before
                // Add a line item for it
                itemList = new LineItemCollection(line.Length);
                this.lineData.Add(line, itemList);

                if (this.IsExcluded(line))
                {
                    itemList.Exclude();
                }
            }
            else
            {
                itemList = this.lineData[line];
            }

            // a new line item for the occurence of this text
            LineItem newItem = new LineItem(itemList, fileName, lineNumber, line);

            if (this.lastItem == null)
            {
                // first line in the file
                this.firstLines.Add(newItem);
            }
            else
            {
                // the previous line has a next line
                this.lastItem.NextLine = newItem;
            }

            itemList.Add(newItem);
            this.lastItem = newItem;
        }

        /// <summary>
        /// Does the line start with an ignored prefix
        /// </summary>
        /// <param name="line">the line to inspect</param>
        /// <returns>True if the line is excluded</returns>
        private bool IsExcluded(string line)
        {
            foreach (string linePrefix in this.ignoredLinePrefixes)
            {
                if (line.StartsWith(linePrefix, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region private procs to find duplicates

        /// <summary>
        /// find duplicates in the file
        /// </summary>
        /// <param name="firstLine">Data on the first line of the file</param>
        private void FindDuplicatesInFile(LineItem firstLine)
        {
            int duplicateLineCount = 0;
            LineItemCollection duplicateLines = null;

            // true when were tracking through a potential duplicate
            bool duplicateTrackingMode = false;
            bool duplicateEnd = false;

            // look through all lines, starting at the beginning
            LineItem currentLine = firstLine;
            LineItem prevLine = null;
            LineItemCollection currentParent;
            while (currentLine != null)
            {
                currentParent = currentLine.Parent;

                if (! duplicateTrackingMode)
                {
                    // does this line have duplicates?
                    // i.e. same text elsewhere 
                    // check for "processed" markers - don't repeat.
                    if (this.IsDuplicateStart(currentLine, currentParent))
                    {
                        duplicateTrackingMode = true;
                        duplicateLines = currentParent.Copy();
                        duplicateLineCount = 0;
                    }
                }

                if (duplicateTrackingMode)
                {
                    if ((prevLine != null) && (duplicateLineCount > 0))
                    {
                        // see how far the duplicates stay in sync
                        // find lines that: 1) are the same as the current line's cohort
                        // 2) follow on from the prev line
                        LineItemCollection currentCohort = currentParent.Intersection(prevLine.Parent.Following());

                        if (currentCohort.Count < 2)
                        {
                            duplicateEnd = true;
                        }
                        else
                        {
                            // if the cohort has been reduced,
                            // remove thier predecessor from the start lines list
                            duplicateLines = duplicateLines.FilterToFollowing(currentCohort, duplicateLineCount);
                        }
                    }

                    if (duplicateEnd)
                    {
                        if (duplicateLineCount >= this.DuplicateThreshold)
                        {
                            // report it
                            this.ReportDuplicate(duplicateLineCount, duplicateLines);

                            // mark start lines as processed:
                            // if BlockB is a duplicate of BlockA, 
                            // don't later report BlockA as a duplicate of BlockB
                            duplicateLines.SetProcessed(duplicateLineCount);
                        }

                        // drop out of duplicates
                        duplicateTrackingMode = false;
                        duplicateLineCount = 0;
                        duplicateEnd = false;
                    }
                    else
                    {
                        duplicateLineCount++;
                    }
                }

                // on to the next line
                prevLine = currentLine;
                currentLine = currentLine.NextLine;
            }

            // reached the end of the file in the duplicate?
            if (duplicateTrackingMode)
            {
                if (duplicateLineCount >= this.DuplicateThreshold)
                {
                    // report it
                    this.ReportDuplicate(duplicateLineCount, duplicateLines);

                    // mark start lines as processed:
                    // if BlockB is a duplicate of BlockA, 
                    // don't later report BlockA as a duplicate of BlockB
                    duplicateLines.SetProcessed(duplicateLineCount);
                }

                // drop out of duplicates
                duplicateLineCount = 0;
                duplicateEnd = false;
            }
        }

        /// <summary>
        /// Check if this line starts a run of lines that occur in more than one place
        /// </summary>
        /// <param name="currentLine">data on the current line</param>
        /// <param name="currentParent">places where the current line is found</param>
        /// <returns>True if this line looks like the start of a duplicate</returns>
        private bool IsDuplicateStart(LineItem currentLine, LineItemCollection currentParent)
        {
            return
                (!currentLine.Processed) &&
                currentParent.Included && 
                (currentLine.Length >= this.FirstLineMinWidth) &&
                (currentParent.Count > 1); 
        }

        /// <summary>
        /// Notify listeners that a duplicate has been found
        /// </summary>
        /// <param name="length">the number of lines in the duplicate</param>
        /// <param name="items">places where the duplicate was found</param>
        private void ReportDuplicate(int length, LineItemCollection items)
        {
            if (items.Count > 1)
            {
                this.duplicateCount++;

                if (this.OnDuplicate != null)
                {
                    DuplicateEventArgs args = new DuplicateEventArgs(length, items);
                    this.OnDuplicate(this, args);
                }
            }
        }

        #endregion
    }
}
