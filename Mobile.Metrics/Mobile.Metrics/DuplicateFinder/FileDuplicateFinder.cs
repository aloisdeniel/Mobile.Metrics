//-----------------------------------------------------------------------
// <copyright file="FileDuplicateFinder.cs" company="Anthony Steele">
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
    /// Find duplicates in files
    /// A file-oriented wrapper for the DuplicateFinder 
    /// </summary>
    public class FileDuplicateFinder
    {
        #region data 

        /// <summary>
        /// The engine
        /// </summary>
        private readonly DuplicateFinderEngine processor = new DuplicateFinderEngine();

        /// <summary>
        /// Names of files to ignore
        /// </summary>
        private readonly List<string> excludedFilesNames;

        /// <summary>
        /// how many files have been read
        /// </summary>
        private int readCount;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the FileDuplicateFinder class
        /// </summary>
        public FileDuplicateFinder()
        {
            this.excludedFilesNames = new List<string>();

            // bubble events up to the owner
            this.processor.OnDuplicate += this.OnDuplicateHandler;
        }

        #endregion

        #region events

        /// <summary>
        /// Notify listeners of a duplicate found
        /// </summary>
        public event EventHandler<DuplicateEventArgs> OnDuplicate;

        #endregion

        #region properties

        /// <summary>
        /// Gets how many files have been read
        /// </summary>
        public int ReadCount
        {
            get { return this.readCount; }
        }

        /// <summary>
        /// Gets how many duplicates were found
        /// </summary>
        public int DuplicateCount
        {
            get { return this.processor.DuplicateCount; }
        }

        /// <summary>
        /// Gets or sets how many lines the same before it is considered a duplicate
        /// </summary>
        public int DuplicateThreshold
        {
            get { return this.processor.DuplicateThreshold; }
            set { this.processor.DuplicateThreshold = value; }
        }

        /// <summary>
        /// Gets or sets the count of non-whitespace chars that the first line must have
        /// </summary>
        public int FirstLineMinWidth
        {
            get { return this.processor.FirstLineMinWidth; }
            set { this.processor.FirstLineMinWidth = value; }
        }

        #endregion

        /// <summary>
        /// Reset the state
        /// </summary>
        public void Clear()
        {
            this.processor.Clear();
            this.readCount = 0;
            this.excludedFilesNames.Clear();
        }

        /// <summary>
        /// Add a file name to ignore
        /// </summary>
        /// <param name="fileName">a file name</param>
        public void AddExcludedFileName(string fileName)
        {
            this.excludedFilesNames.Add(fileName);
        }

        /// <summary>
        /// Ignore lines that start with this prefix
        /// </summary>
        /// <param name="prefix">the string prefix to ignore</param>
        public void AddIgnoredLinePrefix(string prefix)
        {
            this.processor.AddIgnoredLinePrefix(prefix);
        }

        /// <summary>
        /// Add file names to ignore
        /// </summary>
        /// <param name="fileNames">a collection of file names</param>
        public void AddExcludedFileName(IEnumerable<string> fileNames)
        {
            this.excludedFilesNames.AddRange(fileNames);
        }

        #region file processing

        /// <summary>
        /// Read in files
        /// </summary>
        /// <param name="fileNames">a collection of file names</param>
        public void ReadFile(IEnumerable<string> fileNames)
        {
            if (fileNames == null)
            {
                return;
            }

            foreach (string fileName in fileNames)
            {
                this.ReadFile(fileName);
            }
        }

        /// <summary>
        /// read in a file
        /// </summary>
        /// <param name="fileName">a file name</param>
        public void ReadFile(string fileName)
        {
            string bareFileName = Path.GetFileName(fileName);
 
            // ignore files the exclude list
            if (this.excludedFilesNames.Contains(bareFileName))
            {
                return;
            }

            if (File.Exists(fileName))
            {
                TextReader reader = FileReader(fileName);

                this.processor.ProcessText(reader, fileName);
                this.readCount++;
            }
        }

        /// <summary>
        /// Read in some files
        /// </summary>
        /// <param name="directory">a directory</param>
        /// <param name="fileMask">a file mask</param>
        /// <param name="recurse">process subdirectories as well</param>
        public void ReadFile(string directory, string fileMask, bool recurse)
        {
            // read all files that match the spec
            string[] files = Directory.GetFiles(directory, fileMask);
            this.ReadFile(files);

            if (recurse)
            {
                string[] subDirs = Directory.GetDirectories(directory);
                foreach (string subDir in subDirs)
                {
                    this.ReadFile(subDir, fileMask, true);
                }
            }
        }

        /// <summary>
        /// Process the files
        /// </summary>
        /// <returns>the number of files inspected</returns>
        public int FindDuplicates()
        {
            return this.processor.FindDuplicates();
        }

        /// <summary>
        /// Process the file 
        /// </summary>
        /// <param name="fileName">the name of the file to focus on</param>
        /// <returns>the number of files inspected</returns>
        public int FindDuplicates(string fileName)
        {
            return this.processor.FindDuplicates(fileName);
        }

        #endregion

        #region helper procs

        /// <summary>
        /// read the file into a TextReader
        /// </summary>
        /// <param name="fileName">the name of the fileReader</param>
        /// <returns>the TextReader</returns>
        private static TextReader FileReader(string fileName)
        {
            FileStream stream = File.OpenRead(fileName);
            return new StreamReader(stream);
        }

        /// <summary>
        /// Fire the event handler
        /// </summary>
        /// <param name="sender">the event sender</param>
        /// <param name="e">the event args</param>
        private void OnDuplicateHandler(object sender, DuplicateEventArgs e)
        {
            if (this.OnDuplicate != null)
            {
                this.OnDuplicate(this, e);
            }
        }

        #endregion
    }
}
