using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetExlib.Properties;

namespace DotnetExlib.Yeckthone
{
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
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
