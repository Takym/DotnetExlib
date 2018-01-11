using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetExlib.Yeckthone
{
	public enum TokenType : byte
	{
		NAME,
		SYMB,

		NUM_INT,
		NUM_DEC,
		CHR,
		STR,
		TXT,
		OBJ,
		ARY
	}
}
