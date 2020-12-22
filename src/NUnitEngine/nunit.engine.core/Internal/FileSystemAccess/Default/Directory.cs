﻿//-----------------------------------------------------------------------
// <copyright file="Directory.cs" company="TillW">
//   Copyright 2020 TillW. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace NUnit.Engine.Internal.FileSystemAccess.Default
{
    using System;
    using System.Collections.Generic;
    using SIO = System.IO;

    /// <summary>
    /// Default implementation of <see cref="IDirectory"/> that relies on <see cref="System.IO"/>.
    /// </summary>
    internal sealed class Directory : IDirectory
    {
        private readonly SIO.DirectoryInfo directory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Directory"/> class.
        /// </summary>
        /// <param name="path">Path of the directory.</param>
        /// <exception cref="System.Security.SecurityException">The caller does not have the required permission to access <paramref name="path"/>.</exception>
        /// <exception cref="System.ArgumentNullException"><paramref name="path"/> is <see langword="null"/>.</exception>
        /// <exception cref="System.ArgumentException"><paramref name="path"/> contains invalid characters (see <see cref="SIO.Path.GetInvalidPathChars"/> for details).</exception>
        /// <exception cref="SIO.PathTooLongException"><paramref name="path"/> exceeds the system-defined maximum length.</exception>
        public Directory(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (path.IndexOfAny(SIO.Path.GetInvalidPathChars()) > -1)
            {
                throw new ArgumentException("Path contains invalid characters.", nameof(path));
            }

            this.directory = new SIO.DirectoryInfo(path);

            this.Parent = this.directory.Parent == null ? null : new Directory(directory.Parent.FullName);
        }

        /// <inheritdoc/>
        public IDirectory Parent { get; private set; }

        /// <inheritdoc/>
        public string FullName => this.directory.FullName;

        /// <inheritdoc/>
        public IEnumerable<IFile> GetFiles(string searchPattern)
        {
            List<IFile> files = new List<IFile>();
            foreach (var fileInfo in this.directory.GetFiles(searchPattern))
            {
                files.Add(new File(fileInfo.FullName));
            }

            return files;
        }
    }
}
