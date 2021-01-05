using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy.Configuration;

namespace School.Tests
{
    [TestClass] 
    public class AssemblyInitialize
    {
        /// 
        /// Our one-time initialization method called at the very start of running unit tests in this assembly
        ///
        ///
        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            Configurator.BatchProcessors.MarkDownReport.Enable();
        }


        /// 
        /// Our one-time cleanup method called at the very end of running unit tests in this assembly
        ///
        [AssemblyCleanup]
        public static void Cleanup()
        {
            Configurator.BatchProcessors.MarkDownReport.Disable();
        }
    }
}
