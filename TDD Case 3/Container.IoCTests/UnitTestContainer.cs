using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Container.IoCTests
{
    [TestClass]
    public class UnitTestContainer
    {
        private static IoCContainer _container;

        [TestInitialize]
        public void TestSetup()
        {
            _container = new IoCContainer();
        }


        //If  I not get "InvalidOperationException" the Test should  fail
        [TestMethod]
        [Priority(0)]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldNotRegisterAbstractType()
        {
            _container.Register<IRegisterableType, AbstractType>();
        }

        [TestMethod]
        public void RegistryType()
        {
            //Primeira Definiçaõ de TDD Não Existe class "IoCContainer"
            //IoCContainer container = new IoCContainer();

            //Segunda Definição de TDD Não Existe class "IRegisterableType" and "ResolvedType"
            //Need Register method 
            _container.Register<IRegisterableType, ResolvedType>();

            Assert.IsTrue(_container.RegisteredTypes.Count == 1);

        }

        [TestMethod]
        public void ResolveType()
        {
            //IoCContainer container = new IoCContainer();
            _container.Register<IRegisterableType, ResolvedType>();

            //Primeira Definiçaõ de TDD Não Existe "Resolve"
            //Need Resolve method 
            IRegisterableType instance = _container.Resolve<IRegisterableType>();

            Assert.IsNotNull(instance);
            Assert.IsTrue(instance.GetType() == typeof(ResolvedType));


        }

    }

}
