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
using System.Collections.Concurrent;
using System.Collections.Generic;
using Antlr4.Runtime.Tree;
using Sharpen;

namespace Antlr4.Runtime.Tree
{
    /// <summary>Associate a property with a parse tree node.</summary>
    /// <remarks>
    /// Associate a property with a parse tree node. Useful with parse tree listeners
    /// that need to associate values with particular tree nodes, kind of like
    /// specifying a return value for the listener event method that visited a
    /// particular node. Example:
    /// <pre>
    /// ParseTreeProperty&lt;Integer&gt; values = new ParseTreeProperty&lt;Integer&gt;();
    /// values.put(tree, 36);
    /// int x = values.get(tree);
    /// values.removeFrom(tree);
    /// </pre>
    /// You would make one decl (values here) in the listener and use lots of times
    /// in your event methods.
    /// </remarks>
    public class ParseTreeProperty<V>
    {
        protected internal ConcurrentDictionary<IParseTree, V> annotations = new ConcurrentDictionary<IParseTree, V>();

        public virtual V Get(IParseTree node)
        {
            V value;
            if (!annotations.TryGetValue(node, out value))
                return default(V);

            return value;
        }

        public virtual void Put(IParseTree node, V value)
        {
            annotations[node] = value;
        }

        public virtual V RemoveFrom(IParseTree node)
        {
            V value;
            if (!annotations.TryRemove(node, out value))
                return default(V);

            return value;
        }
    }
}
