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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Sharpen;

namespace Antlr4.Runtime.Atn
{
    /// <summary>
    /// Implements the
    /// <code>skip</code>
    /// lexer action by calling
    /// <see cref="Antlr4.Runtime.Lexer.Skip()">Antlr4.Runtime.Lexer.Skip()</see>
    /// .
    /// <p>The
    /// <code>skip</code>
    /// command does not have any parameters, so this action is
    /// implemented as a singleton instance exposed by
    /// <see cref="Instance">Instance</see>
    /// .</p>
    /// </summary>
    /// <author>Sam Harwell</author>
    /// <since>4.2</since>
    public sealed class LexerSkipAction : ILexerAction
    {
        /// <summary>Provides a singleton instance of this parameterless lexer action.</summary>
        /// <remarks>Provides a singleton instance of this parameterless lexer action.</remarks>
        public static readonly Antlr4.Runtime.Atn.LexerSkipAction Instance = new Antlr4.Runtime.Atn.LexerSkipAction();

        /// <summary>
        /// Constructs the singleton instance of the lexer
        /// <code>skip</code>
        /// command.
        /// </summary>
        private LexerSkipAction()
        {
        }

        /// <summary><inheritDoc></inheritDoc></summary>
        /// <returns>
        /// This method returns
        /// <see cref="LexerActionType.Skip">LexerActionType.Skip</see>
        /// .
        /// </returns>
        public LexerActionType GetActionType()
        {
            return LexerActionType.Skip;
        }

        /// <summary><inheritDoc></inheritDoc></summary>
        /// <returns>
        /// This method returns
        /// <code>false</code>
        /// .
        /// </returns>
        public bool IsPositionDependent()
        {
            return false;
        }

        /// <summary>
        /// <inheritDoc></inheritDoc>
        /// <p>This action is implemented by calling
        /// <see cref="Antlr4.Runtime.Lexer.Skip()">Antlr4.Runtime.Lexer.Skip()</see>
        /// .</p>
        /// </summary>
        public void Execute(Lexer lexer)
        {
            lexer.Skip();
        }

        public override int GetHashCode()
        {
            int hash = MurmurHash.Initialize();
            hash = MurmurHash.Update(hash, (int)(GetActionType()));
            return MurmurHash.Finish(hash, 1);
        }

        public override bool Equals(object obj)
        {
            return obj == this;
        }

        public override string ToString()
        {
            return "skip";
        }
    }
}
