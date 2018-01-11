using System.IO;
using DotnetExlib.Properties;

namespace DotnetExlib.IO
{
	/// <summary>
	///  一時ファイルを扱います。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public class TemporaryFile : Stream
	{
		private string _file_path;
		private FileStream _stream;

		/// <summary>
		///  一時ファイルの基となるファイル ストリームです。
		/// </summary>
		public FileStream BaseStream
		{
			get
			{
				if (_stream == null) {
					_stream = new FileStream(_file_path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
				}
				return _stream;
			}
		}

		/// <summary>
		///  このプロパティは必ず<c>true</c>を返します。
		/// </summary>
		public override bool CanRead
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		///  現在のストリームがシークできるかどうかの値です。
		/// </summary>
		public override bool CanSeek
		{
			get
			{
				return _stream.CanSeek;
			}
		}

		/// <summary>
		///  このプロパティは必ず<c>true</c>を返します。
		/// </summary>
		public override bool CanWrite
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		///  現在のストリームの長さ(バイト単位)を取得します。
		/// </summary>
		public override long Length
		{
			get
			{
				return _stream.Length;
			}
		}

		/// <summary>
		///  ストリームの現在位置を設定または取得します。
		/// </summary>
		public override long Position
		{
			get
			{
				return _stream.Position;
			}

			set
			{
				_stream.Position = value;
			}
		}

		/// <summary>
		///  一時ファイルの場所を指定して、新しいインスタンスを生成します。
		/// </summary>
		/// <param name="place">一時ファイルの場所です。</param>
		public TemporaryFile(FilePlace place) : this(place, Path.GetRandomFileName()) { }

		/// <summary>
		///  一時ファイルの場所と名前を指定して、新しいインスタンスを生成します。
		/// </summary>
		/// <param name="place">一時ファイルの場所です。</param>
		/// <param name="name">一時ファイルの名前です。</param>
		public TemporaryFile(FilePlace place, string name)
		{
			(_file_path, _stream) = FilePathManager.GetTempFile(place, name);
		}

		/// <summary>
		///  現在のストリームのバッファをクリアして、
		///  一時ファイルにデータを書き込みます。
		/// </summary>
		public override void Flush()
		{
			_stream.Flush();
		}

		/// <summary>
		///  このストリームの現在位置を特定の値に設定します。
		/// </summary>
		/// <param name="offset">
		///  <paramref name="origin"/>に対するオフセットです。
		/// </param>
		/// <param name="origin">
		///  基準となる位置です。
		/// </param>
		/// <returns>設定後の現在位置です。</returns>
		public override long Seek(long offset, SeekOrigin origin)
		{
			return _stream.Seek(offset, origin);
		}

		/// <summary>
		///  ストリームの大きさを設定します。
		/// </summary>
		/// <param name="value">ストリームの大きさをバイト単位で設定します。</param>
		public override void SetLength(long value)
		{
			_stream.SetLength(value);
		}

		/// <summary>
		///  ストリームからデータを指定したバッファに読み取ります。
		/// </summary>
		/// <param name="buffer">読み取り先のバッファです。</param>
		/// <param name="offset">バッファの先頭位置です。</param>
		/// <param name="count">何バイト読み取るかです。</param>
		/// <returns>何バイト読み取ったかです。</returns>
		public override int Read(byte[] buffer, int offset, int count)
		{
			return _stream.Read(buffer, offset, count);
		}

		/// <summary>
		///  ストリームに指定したバッファからデータを書き込みます。
		/// </summary>
		/// <param name="buffer">書き込み元のバッファです。</param>
		/// <param name="offset">バッファの先頭位置です。</param>
		/// <param name="count">何バイト書き込むかです。</param>
		public override void Write(byte[] buffer, int offset, int count)
		{
			_stream.Write(buffer, offset, count);
		}

		/// <summary>
		///  <see cref="System.IO.FileStream"/>と<see cref="DotnetExlib.IO.TemporaryFile"/>の変換演算子を提供します。
		/// </summary>
		/// <param name="stream">変換前のオブジェクトです。</param>
		/// <returns>変換後のオブジェクトです。</returns>
		public static explicit operator TemporaryFile(FileStream stream)
		{
			TemporaryFile result = new TemporaryFile(FilePlace.User);
			result._file_path = stream.Name;
			result._stream = stream;
			return result;
		}

		/// <summary>
		///  <see cref="System.IO.FileStream"/>と<see cref="DotnetExlib.IO.TemporaryFile"/>の変換演算子を提供します。
		/// </summary>
		/// <param name="stream">変換前のオブジェクトです。</param>
		/// <returns>変換後のオブジェクトです。</returns>
		public static explicit operator FileStream(TemporaryFile stream)
		{
			return stream._stream;
		}
	}
}
