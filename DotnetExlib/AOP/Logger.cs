using System;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using DotnetExlib.Properties;

namespace DotnetExlib.AOP
{
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public class Logger : IAspectBehavior
	{
		private Type _type;
		public Logger(Type target)
		{
			_type = target;
		}

		public void PreInitializer(IConstructionCallMessage msg)
		{
			Console.WriteLine($"{_type.FullName}.{msg.MethodName} : インスタンス生成開始 . . .");
		}

		public void PostInitializer(IConstructionCallMessage msg)
		{
			Console.WriteLine($"{_type.FullName}.{msg.MethodName} : 正常にインスタンスを生成しました。");
		}

		public void PreCallMethod(IMethodCallMessage msg)
		{
			Console.WriteLine($"{_type.FullName}.{msg.MethodName} : 実行開始");
		}

		public void PostCallMethod(IMethodCallMessage msg)
		{
			Console.WriteLine($"{_type.FullName}.{msg.MethodName} : 実行終了");
		}
	}
}
