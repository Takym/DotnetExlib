using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using DotnetExlib.Properties;

namespace DotnetExlib.AOP
{
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public interface IAspectBehavior
	{
		void PreInitializer(IConstructionCallMessage constructionCallMessage);
		void PostInitializer(IConstructionCallMessage constructionCallMessage);
		void PreCallMethod(IMethodCallMessage methodCallMessage);
		void PostCallMethod(IMethodCallMessage methodCallMessage);
	}
}
