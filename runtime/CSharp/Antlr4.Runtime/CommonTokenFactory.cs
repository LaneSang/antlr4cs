/*
 * [The "BSD license"]
 *  Copyright (c) 2013 Terence Parr
 *  Copyright (c) 2013 Sam Harwell
 *  All rights reserved.
 *
 *  Redistribution and use in source and binary forms, with or without
 *  modification, are permitted provided that the following conditions
 *  are met:
 *
 *  1. Redistributions of source code must retain the above copyright
 *     notice, this list of conditions and the following disclaimer.
 *  2. Redistributions in binary form must reproduce the above copyright
 *     notice, this list of conditions and the following disclaimer in the
 *     documentation and/or other materials provided with the distribution.
 *  3. The name of the author may not be used to endorse or promote products
 *     derived from this software without specific prior written permission.
 *
 *  THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 *  IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 *  OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 *  IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
 *  INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 *  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 *  DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 *  THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 *  (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 *  THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Sharpen;

namespace Antlr4.Runtime
{
    /// <summary>
    /// This default implementation of
    /// <see cref="ITokenFactory">ITokenFactory</see>
    /// creates
    /// <see cref="CommonToken">CommonToken</see>
    /// objects.
    /// </summary>
    public class CommonTokenFactory : ITokenFactory
    {
        /// <summary>
        /// The default
        /// <see cref="CommonTokenFactory">CommonTokenFactory</see>
        /// instance.
        /// <p>
        /// This token factory does not explicitly copy token text when constructing
        /// tokens.</p>
        /// </summary>
        public static readonly ITokenFactory Default = new Antlr4.Runtime.CommonTokenFactory();

        /// <summary>
        /// Indicates whether
        /// <see cref="CommonToken.Text(string)">CommonToken.Text(string)</see>
        /// should be called after
        /// constructing tokens to explicitly set the text. This is useful for cases
        /// where the input stream might not be able to provide arbitrary substrings
        /// of text from the input after the lexer creates a token (e.g. the
        /// implementation of
        /// <see cref="ICharStream.GetText(Antlr4.Runtime.Misc.Interval)">ICharStream.GetText(Antlr4.Runtime.Misc.Interval)</see>
        /// in
        /// <see cref="UnbufferedCharStream">UnbufferedCharStream</see>
        /// throws an
        /// <see cref="System.NotSupportedException">System.NotSupportedException</see>
        /// ). Explicitly setting the token text
        /// allows
        /// <see cref="IToken.Text()">IToken.Text()</see>
        /// to be called at any time regardless of the
        /// input stream implementation.
        /// <p>
        /// The default value is
        /// <code>false</code>
        /// to avoid the performance and memory
        /// overhead of copying text for every token unless explicitly requested.</p>
        /// </summary>
        protected internal readonly bool copyText;

        /// <summary>
        /// Constructs a
        /// <see cref="CommonTokenFactory">CommonTokenFactory</see>
        /// with the specified value for
        /// <see cref="copyText">copyText</see>
        /// .
        /// <p>
        /// When
        /// <code>copyText</code>
        /// is
        /// <code>false</code>
        /// , the
        /// <see cref="Default">Default</see>
        /// instance
        /// should be used instead of constructing a new instance.</p>
        /// </summary>
        /// <param name="copyText">
        /// The value for
        /// <see cref="copyText">copyText</see>
        /// .
        /// </param>
        public CommonTokenFactory(bool copyText)
        {
            this.copyText = copyText;
        }

        /// <summary>
        /// Constructs a
        /// <see cref="CommonTokenFactory">CommonTokenFactory</see>
        /// with
        /// <see cref="copyText">copyText</see>
        /// set to
        /// <code>false</code>
        /// .
        /// <p>
        /// The
        /// <see cref="Default">Default</see>
        /// instance should be used instead of calling this
        /// directly.</p>
        /// </summary>
        public CommonTokenFactory()
            : this(false)
        {
        }

        public virtual CommonToken Create(Tuple<ITokenSource, ICharStream> source, int type, string text, int channel, int start, int stop, int line, int charPositionInLine)
        {
            CommonToken t = new CommonToken(source, type, channel, start, stop);
            t.Line = line;
            t.Column = charPositionInLine;
            if (text != null)
            {
                t.Text = text;
            }
            else
            {
                if (copyText && source.Item2 != null)
                {
                    t.Text = source.Item2.GetText(Interval.Of(start, stop));
                }
            }
            return t;
        }

        IToken ITokenFactory.Create(Tuple<ITokenSource, ICharStream> source, int type, string text, int channel, int start, int stop, int line, int charPositionInLine)
        {
            return Create(source, type, text, channel, start, stop, line, charPositionInLine);
        }

        public virtual CommonToken Create(int type, string text)
        {
            return new CommonToken(type, text);
        }

        IToken ITokenFactory.Create(int type, string text)
        {
            return Create(type, text);
        }
    }
}
