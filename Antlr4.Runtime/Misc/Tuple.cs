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
using Sharpen;

namespace Antlr4.Runtime.Misc
{
	/// <author>Sam Harwell</author>
	public class Tuple<T1, T2, T3>
	{
		private readonly T1 item1;

		private readonly T2 item2;

		private readonly T3 item3;

		public Tuple(T1 item1, T2 item2, T3 item3)
		{
			this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
		}

		public T1 GetItem1()
		{
			return item1;
		}

		public T2 GetItem2()
		{
			return item2;
		}

		public T3 GetItem3()
		{
			return item3;
		}

		public override bool Equals(object obj)
		{
			if (obj == this)
			{
				return true;
			}
			else
			{
				if (!(obj is Tuple<object, object, object>))
				{
					return false;
				}
			}
			Tuple<object, object, object> other = (Tuple<object, object, object>)obj;
			return Tuple.Equals(this.item1, other.item1) && Tuple.Equals(this.item2, other.item2
				) && Tuple.Equals(this.item3, other.item3);
		}

		public override int GetHashCode()
		{
			int hash = 5;
			hash = 79 * hash + (this.item1 != null ? this.item1.GetHashCode() : 0);
			hash = 79 * hash + (this.item2 != null ? this.item2.GetHashCode() : 0);
			hash = 79 * hash + (this.item3 != null ? this.item3.GetHashCode() : 0);
			return hash;
		}
	}
}