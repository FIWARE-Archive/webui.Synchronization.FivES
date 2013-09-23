using NUnit.Framework;
using System;
using FIVES;

namespace Renderable
{
    [TestFixture()]
    public class RenderablePluginTest
    {
        RenderablePlugin plugin = new RenderablePlugin();

        public RenderablePluginTest()
        {
            plugin.Initialize();
        }

        [Test()]
        public void ShouldRegisterPositionComponent()
        {
            Assert.True(ComponentRegistry.Instance.IsRegistered("meshResource"));
        }

        [Test()]
        public void ShouldRegisterOrientationComponent()
        {
            Assert.True(ComponentRegistry.Instance.IsRegistered("scale"));
        }

        [Test()]
        public void ShouldReturnCorrectName()
        {
            Assert.AreEqual("Renderable", plugin.GetName());
        }

        [Test()]
        public void ShouldReturnCorrectDeps()
        {
            Assert.AreEqual(plugin.GetDependencies().Count, 1);
            Assert.Contains("Location", plugin.GetDependencies());
        }
    }
}
