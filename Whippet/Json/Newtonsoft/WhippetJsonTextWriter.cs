using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Athi.Whippet.Json.Newtonsoft
{
    /// <summary>
    /// Represents a writer that provides a fast, non-cached, forward-only way of generating JSON data.
    /// </summary>
    public class WhippetJsonTextWriter : JsonTextWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetJsonTextWriter"/> class with no arguments.
        /// </summary>
        private WhippetJsonTextWriter()
            : this(TextWriter.Null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetJsonTextWriter"/> class using the specified <see cref="TextWriter"/>.
        /// </summary>
        /// <param name="textWriter">The <see cref="TextWriter"/> to write to.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetJsonTextWriter(TextWriter textWriter)
            : base(textWriter)
        { }

        /// <summary>
        /// Writes the specified <see cref="Enum"/> value of type <typeparamref name="T"/> to the stream.
        /// </summary>
        /// <typeparam name="T"><see cref="Enum"/> type to emit to the writer.</typeparam>
        /// <param name="value"><see cref="Enum"/> value of type <typeparamref name="T"/> to write.</param>
        public virtual void WriteEnum<T>(T value) where T : Enum
        {
            WriteValue(value?.ToString());
        }
    }
}

