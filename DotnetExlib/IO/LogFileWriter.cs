using System;
using System.IO;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace DotnetExlib.IO
{
	public class LogFileWriter : TextWriter
	{
		#region プロパティ

		public TextWriter BaseStream
		{
			get
			{
				if (_tw == null) {
					_tw = new StringWriter(); // null時、ダミーストリーム生成
				}
				return _tw;
			}
		}
		private TextWriter _tw;

		public override Encoding Encoding
		{
			get
			{
				return _tw.Encoding;
			}
		}

		public override IFormatProvider FormatProvider
		{
			get
			{
				return _tw.FormatProvider;
			}
		}

		public override string NewLine
		{
			get
			{
				return _tw.NewLine;
			}

			set
			{
				_tw.NewLine = value;
			}
		}

		#endregion

		#region コンストラクタ

		public LogFileWriter() { }

		public LogFileWriter(TextWriter writer)
		{
			_tw = writer;
		}

		#endregion

		#region WriteLine メソッド

		public override void WriteLine()
		{
			_tw.WriteLine($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
		}

		public override void WriteLine(char value)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(value);
			_tw.WriteLine();
		}

		public override void WriteLine(char[] buffer)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(buffer);
			_tw.WriteLine();
		}

		public override void WriteLine(char[] buffer, int index, int count)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(buffer, index, count);
			_tw.WriteLine();
		}

		public override void WriteLine(bool value)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(value);
			_tw.WriteLine();
		}

		public override void WriteLine(int value)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(value);
			_tw.WriteLine();
		}

		public override void WriteLine(uint value)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(value);
			_tw.WriteLine();
		}

		public override void WriteLine(long value)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(value);
			_tw.WriteLine();
		}

		public override void WriteLine(ulong value)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(value);
			_tw.WriteLine();
		}

		public override void WriteLine(float value)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(value);
			_tw.WriteLine();
		}

		public override void WriteLine(double value)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(value);
			_tw.WriteLine();
		}

		public override void WriteLine(decimal value)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(value);
			_tw.WriteLine();
		}

		public override void WriteLine(string value)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(value);
			_tw.WriteLine();
		}

		public override void WriteLine(object value)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(value);
			_tw.WriteLine();
		}

		public override void WriteLine(string format, object arg0)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(string.Format(format, arg0));
			_tw.WriteLine();
		}

		public override void WriteLine(string format, object arg0, object arg1)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(string.Format(format, arg0, arg1));
			_tw.WriteLine();
		}

		public override void WriteLine(string format, object arg0, object arg1, object arg2)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(string.Format(format, arg0, arg1, arg2));
			_tw.WriteLine();
		}

		public override void WriteLine(string format, params object[] args)
		{
			_tw.Write($"[{DateTime.Now:yyyy/MM/dd hh:mm:ss.fff}] ");
			_tw.Write(string.Format(format, args));
			_tw.WriteLine();
		}

		public override Task WriteLineAsync()
		{
			return new Task(() => _tw.WriteLine());
		}

		public override Task WriteLineAsync(char value)
		{
			return new Task(() => _tw.WriteLine(value));
		}

		public override Task WriteLineAsync(string value)
		{
			return new Task(() => _tw.WriteLine(value));
		}

		public override Task WriteLineAsync(char[] buffer, int index, int count)
		{
			return new Task(() => _tw.WriteLine(buffer, index, count));
		}

		#endregion

		#region 継承した関数

		public override string ToString()
		{
			return _tw.ToString();
		}

		public override bool Equals(object obj)
		{
			return _tw.Equals(obj);
		}

		public override int GetHashCode()
		{
			return _tw.GetHashCode();
		}

		public override object InitializeLifetimeService()
		{
			return _tw.InitializeLifetimeService();
		}

		public override ObjRef CreateObjRef(Type requestedType)
		{
			return _tw.CreateObjRef(requestedType);
		}

		public override void Close()
		{
			_tw.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing) _tw.Dispose();
		}

		public override void Flush()
		{
			_tw.Flush();
		}

		public override void Write(char value)
		{
			_tw.Write(value);
		}

		public override void Write(char[] buffer)
		{
			_tw.Write(buffer);
		}

		public override void Write(char[] buffer, int index, int count)
		{
			_tw.Write(buffer, index, count);
		}

		public override void Write(bool value)
		{
			_tw.Write(value);
		}

		public override void Write(int value)
		{
			_tw.Write(value);
		}

		public override void Write(uint value)
		{
			_tw.Write(value);
		}

		public override void Write(long value)
		{
			_tw.Write(value);
		}

		public override void Write(ulong value)
		{
			_tw.Write(value);
		}

		public override void Write(float value)
		{
			_tw.Write(value);
		}

		public override void Write(double value)
		{
			_tw.Write(value);
		}

		public override void Write(decimal value)
		{
			_tw.Write(value);
		}

		public override void Write(string value)
		{
			_tw.Write(value);
		}

		public override void Write(object value)
		{
			_tw.Write(value);
		}

		public override void Write(string format, object arg0)
		{
			_tw.Write(format, arg0);
		}

		public override void Write(string format, object arg0, object arg1)
		{
			_tw.Write(format, arg0, arg1);
		}

		public override void Write(string format, object arg0, object arg1, object arg2)
		{
			_tw.Write(format, arg0, arg1, arg2);
		}

		public override void Write(string format, params object[] arg)
		{
			_tw.Write(format, arg);
		}

		public override Task WriteAsync(char value)
		{
			return _tw.WriteAsync(value);
		}

		public override Task WriteAsync(string value)
		{
			return _tw.WriteAsync(value);
		}

		public override Task WriteAsync(char[] buffer, int index, int count)
		{
			return _tw.WriteAsync(buffer, index, count);
		}

		public override Task FlushAsync()
		{
			return _tw.FlushAsync();
		}

		#endregion

		#region 関数

		public void SetWriter(TextWriter writer)
		{
			_tw = writer;
		}

		#endregion
	}
}
