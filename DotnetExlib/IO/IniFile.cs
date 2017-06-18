using System;
using System.Text;
using DotnetExlib.Properties;

namespace DotnetExlib.IO
{
	/// <summary>
	///  iniファイルを扱います。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public class IniFile : IConfigFile
	{
		/// <summary>
		///  読み書きするiniファイルのファイルパスです。
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		///  操作するiniファイルのパスを設定して、
		///  新しいインスタンスを生成します。
		/// </summary>
		/// <param name="fileName">操作するiniファイルです。</param>
		public IniFile(string fileName)
		{
			this.FileName = fileName;
		}

		public object this[string section, string key]
		{
			get
			{
				StringBuilder sb = new StringBuilder(1024, 4096);
				WinAPIWrapper.Kernel32.GetPrivateProfileString(
					section,
					key,
					this.DefaultValue.ToString(),
					sb,
					((uint)(sb.Length)),
					this.FileName);
				return sb.ToString();
			}

			set
			{
				WinAPIWrapper.Kernel32.WritePrivateProfileString(
					section,
					key,
					value.ToString(),
					this.FileName);
			}
		}

		public object DefaultValue { get; set; }

		public bool DefaultValueBool { get; set; }

		public byte DefaultValueByte { get; set; }

		public char DefaultValueChar { get; set; }

		public decimal DefaultValueDecimal { get; set; }

		public double DefaultValueDouble { get; set; }

		public float DefaultValueSingle { get; set; }

		public short DefaultValueInt16 { get; set; }

		public int DefaultValueInt32 { get; set; }

		public long DefaultValueInt64 { get; set; }

		public sbyte DefaultValueSByte { get; set; }

		public string DefaultValueString { get; set; }

		public ushort DefaultValueUInt16 { get; set; }

		public uint DefaultValueUInt32 { get; set; }

		public ulong DefaultValueUInt64 { get; set; }

		public object GetValue(string section, string key)
		{
			StringBuilder sb = new StringBuilder(1024, 4096);
			WinAPIWrapper.Kernel32.GetPrivateProfileString(
				section,
				key,
				this.DefaultValue.ToString(),
				sb,
				((uint)(sb.Length)),
				this.FileName);
			return sb.ToString();
		}

		public object GetValue(string section, string key, Type type)
		{
			if (type.IsPrimitive) {
				if (type == typeof(object)) {
					return this.GetValue(section, key);
				} else if (type == typeof(string)) {
					return this.GetValueString(section, key);
				} else if (type == typeof(char)) {
					return this.GetValueChar(section, key);
				} else if (type == typeof(byte)) {
					return this.GetValueByte(section, key);
				} else if (type == typeof(ushort)) {
					return this.GetValueUInt16(section, key);
				} else if (type == typeof(uint)) {
					return this.GetValueUInt32(section, key);
				} else if (type == typeof(ulong)) {
					return this.GetValueUInt64(section, key);
				} else if (type == typeof(sbyte)) {
					return this.GetValueSByte(section, key);
				} else if (type == typeof(short)) {
					return this.GetValueInt16(section, key);
				} else if (type == typeof(int)) {
					return this.GetValueInt32(section, key);
				} else if (type == typeof(long)) {
					return this.GetValueInt64(section, key);
				} else if (type == typeof(float)) {
					return this.GetValueSingle(section, key);
				} else if (type == typeof(double)) {
					return this.GetValueDouble(section, key);
				} else if (type == typeof(decimal)) {
					return this.GetValueDecimal(section, key);
				} else if (type == typeof(bool)) {
					return this.GetValueBoolean(section, key);
				} else {
					return null;
				}
			} else {
				return null;
			}
		}

		public T GetValue<T>(string section, string key)
		{
			return ((T)(this.GetValue(section, key, typeof(T))));
		}

		public bool GetValueBoolean(string section, string key)
		{
			StringBuilder sb = new StringBuilder(1024, 4096);
			WinAPIWrapper.Kernel32.GetPrivateProfileString(
				section,
				key,
				this.DefaultValueBool.ToString(),
				sb,
				((uint)(sb.Length)),
				this.FileName);
			bool result;
			if (sb.ToString().TryToBoolean(out result)) {
				return result;
			} else {
				return this.DefaultValueBool;
			}
		}

		public byte GetValueByte(string section, string key)
		{
			StringBuilder sb = new StringBuilder(1024, 4096);
			WinAPIWrapper.Kernel32.GetPrivateProfileString(
				section,
				key,
				this.DefaultValueByte.ToString(),
				sb,
				((uint)(sb.Length)),
				this.FileName);
			byte result;
			if (byte.TryParse(sb.ToString(), out result)) {
				return result;
			} else {
				return this.DefaultValueByte;
			}
		}

		public char GetValueChar(string section, string key)
		{
			StringBuilder sb = new StringBuilder(1024, 4096);
			WinAPIWrapper.Kernel32.GetPrivateProfileString(
				section,
				key,
				this.DefaultValueChar.ToString(),
				sb,
				((uint)(sb.Length)),
				this.FileName);
			return sb.ToString()[0];
		}

		public decimal GetValueDecimal(string section, string key)
		{
			StringBuilder sb = new StringBuilder(1024, 4096);
			WinAPIWrapper.Kernel32.GetPrivateProfileString(
				section,
				key,
				this.DefaultValueDecimal.ToString(),
				sb,
				((uint)(sb.Length)),
				this.FileName);
			decimal result;
			if (decimal.TryParse(sb.ToString(), out result)) {
				return result;
			} else {
				return this.DefaultValueDecimal;
			}
		}

		public double GetValueDouble(string section, string key)
		{
			StringBuilder sb = new StringBuilder(1024, 4096);
			WinAPIWrapper.Kernel32.GetPrivateProfileString(
				section,
				key,
				this.DefaultValueDouble.ToString(),
				sb,
				((uint)(sb.Length)),
				this.FileName);
			double result;
			if (double.TryParse(sb.ToString(), out result)) {
				return result;
			} else {
				return this.DefaultValueDouble;
			}
		}

		public short GetValueInt16(string section, string key)
		{
			StringBuilder sb = new StringBuilder(1024, 4096);
			WinAPIWrapper.Kernel32.GetPrivateProfileString(
				section,
				key,
				this.DefaultValueInt16.ToString(),
				sb,
				((uint)(sb.Length)),
				this.FileName);
			short result;
			if (short.TryParse(sb.ToString(), out result)) {
				return result;
			} else {
				return this.DefaultValueInt16;
			}
		}

		public int GetValueInt32(string section, string key)
		{
			return ((int)(WinAPIWrapper.Kernel32.GetPrivateProfileInt(
				section,
				key,
				this.DefaultValueInt32,
				this.FileName)));
		}

		public long GetValueInt64(string section, string key)
		{
			StringBuilder sb = new StringBuilder(1024, 4096);
			WinAPIWrapper.Kernel32.GetPrivateProfileString(
				section,
				key,
				this.DefaultValueInt64.ToString(),
				sb,
				((uint)(sb.Length)),
				this.FileName);
			long result;
			if (long.TryParse(sb.ToString(), out result)) {
				return result;
			} else {
				return this.DefaultValueInt64;
			}
		}

		public sbyte GetValueSByte(string section, string key)
		{
			StringBuilder sb = new StringBuilder(1024, 4096);
			WinAPIWrapper.Kernel32.GetPrivateProfileString(
				section,
				key,
				this.DefaultValueSByte.ToString(),
				sb,
				((uint)(sb.Length)),
				this.FileName);
			sbyte result;
			if (sbyte.TryParse(sb.ToString(), out result)) {
				return result;
			} else {
				return this.DefaultValueSByte;
			}
		}

		public float GetValueSingle(string section, string key)
		{
			StringBuilder sb = new StringBuilder(1024, 4096);
			WinAPIWrapper.Kernel32.GetPrivateProfileString(
				section,
				key,
				this.DefaultValueSingle.ToString(),
				sb,
				((uint)(sb.Length)),
				this.FileName);
			float result;
			if (float.TryParse(sb.ToString(), out result)) {
				return result;
			} else {
				return this.DefaultValueSingle;
			}
		}

		public string GetValueString(string section, string key)
		{
			StringBuilder sb = new StringBuilder(1024, 4096);
			WinAPIWrapper.Kernel32.GetPrivateProfileString(
				section,
				key,
				this.DefaultValue.ToString(),
				sb,
				((uint)(sb.Length)),
				this.FileName);
			return sb.ToString();
		}

		public ushort GetValueUInt16(string section, string key)
		{
			StringBuilder sb = new StringBuilder(1024, 4096);
			WinAPIWrapper.Kernel32.GetPrivateProfileString(
				section,
				key,
				this.DefaultValueUInt16.ToString(),
				sb,
				((uint)(sb.Length)),
				this.FileName);
			ushort result;
			if (ushort.TryParse(sb.ToString(), out result)) {
				return result;
			} else {
				return this.DefaultValueUInt16;
			}
		}

		public uint GetValueUInt32(string section, string key)
		{
			return WinAPIWrapper.Kernel32.GetPrivateProfileInt(
				section,
				key,
				((int)(this.DefaultValueUInt32)),
				this.FileName);
		}

		public ulong GetValueUInt64(string section, string key)
		{
			StringBuilder sb = new StringBuilder(1024, 4096);
			WinAPIWrapper.Kernel32.GetPrivateProfileString(
				section,
				key,
				this.DefaultValueUInt64.ToString(),
				sb,
				((uint)(sb.Length)),
				this.FileName);
			ulong result;
			if (ulong.TryParse(sb.ToString(), out result)) {
				return result;
			} else {
				return this.DefaultValueUInt64;
			}
		}

		public void SetValue(string section, string key, long value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, float value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, decimal value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, bool value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, double value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, byte value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, uint value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, ulong value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, sbyte value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, short value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, int value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, ushort value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, string value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value, this.FileName);
		}

		public void SetValue(string section, string key, char value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, object value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue(string section, string key, object value, Type type)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}

		public void SetValue<T>(string section, string key, T value)
		{
			WinAPIWrapper.Kernel32.WritePrivateProfileString(section, key, value.ToString(), this.FileName);
		}
	}
}
