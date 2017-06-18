using System;
using DotnetExlib.Properties;

namespace DotnetExlib.IO
{
	/// <summary>
	///  設定ファイルを操作する機能を提供します。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public interface IConfigFile
	{
		object this[string section, string key] { get; set; }

		object DefaultValue { get; set; }
		string DefaultValueString { get; set; }
		char DefaultValueChar { get; set; }
		byte DefaultValueByte { get; set; }
		ushort DefaultValueUInt16 { get; set; }
		uint DefaultValueUInt32 { get; set; }
		ulong DefaultValueUInt64 { get; set; }
		sbyte DefaultValueSByte { get; set; }
		short DefaultValueInt16 { get; set; }
		int DefaultValueInt32 { get; set; }
		long DefaultValueInt64 { get; set; }
		float DefaultValueSingle { get; set; }
		double DefaultValueDouble { get; set; }
		decimal DefaultValueDecimal { get; set; }
		bool DefaultValueBool { get; set; }

		object GetValue(string section, string key);
		object GetValue(string section, string key, Type type);
		T GetValue<T>(string section, string key);
		string GetValueString(string section, string key);
		char GetValueChar(string section, string key);
		byte GetValueByte(string section, string key);
		ushort GetValueUInt16(string section, string key);
		uint GetValueUInt32(string section, string key);
		ulong GetValueUInt64(string section, string key);
		sbyte GetValueSByte(string section, string key);
		short GetValueInt16(string section, string key);
		int GetValueInt32(string section, string key);
		long GetValueInt64(string section, string key);
		float GetValueSingle(string section, string key);
		double GetValueDouble(string section, string key);
		decimal GetValueDecimal(string section, string key);
		bool GetValueBoolean(string section, string key);

		void SetValue(string section, string key, object value);
		void SetValue(string section, string key, object value, Type type);
		void SetValue<T>(string section, string key, T value);
		void SetValue(string section, string key, string value);
		void SetValue(string section, string key, char value);
		void SetValue(string section, string key, byte value);
		void SetValue(string section, string key, ushort value);
		void SetValue(string section, string key, uint value);
		void SetValue(string section, string key, ulong value);
		void SetValue(string section, string key, sbyte value);
		void SetValue(string section, string key, short value);
		void SetValue(string section, string key, int value);
		void SetValue(string section, string key, long value);
		void SetValue(string section, string key, float value);
		void SetValue(string section, string key, double value);
		void SetValue(string section, string key, decimal value);
		void SetValue(string section, string key, bool value);
	}
}
