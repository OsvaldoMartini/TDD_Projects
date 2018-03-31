using System;

namespace DI.Autofac.ConstructorFinder
{

    //With this I am able to Decorator my constuctor
    [AttributeUsage(AttributeTargets.Constructor)]
    public class AwesomeConstructorAttribute : Attribute
    {
    }
}
