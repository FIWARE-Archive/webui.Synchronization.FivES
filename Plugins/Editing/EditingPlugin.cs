using System;
using FIVES;
using System.Collections.Generic;
using KIARA;

namespace Editing
{
    public class EditingPlugin : IPluginInitializer
    {
        #region IPluginInitializer implementation

        public string getName()
        {
            return "Editing";
        }

        public List<string> getDependencies()
        {
            // FIXME: Instead of forcing Editing plugin to depend on ClientSync, we should introduce OnPluginLoaded
            // event into the PluginManager and only register client functions dynamically. This way we make Editing
            // plugin independant of client sync plugin.
            return new List<string>() { "Location", "ClientSync" };
        }

        public void initialize()
        {
            // Register new API with ClientSync.
            if (PluginManager.Instance.isPluginLoaded("ClientSync")) {
                var context = new Context();
                string pluginConfig = "data:text/json;base64,ewogICdpbmZvJzogJ0NsaWVudFN5bmNQbHVnaW4nLAogICdpZGxDb250" +
                    "ZW50JzogJy4uLicsCiAgJ3NlcnZlcnMnOiBbewogICAgJ3NlcnZpY2VzJzogJyonLAogICAgJ3Byb3RvY29sJzogewogICAg" +
                    "ICAnbmFtZSc6ICdkaXJlY3QtY2FsbCcsCiAgICAgICdpZCc6ICdjbGllbnRzeW5jJywKICAgICB9LAogIH1dLAp9Cg==";
                context.openConnection(pluginConfig, delegate(Connection conn) {
                    var registerClientMethod = conn.generateFuncWrapper("registerClientMethod");
                    registerClientMethod("editing.createEntityAt", (Action<float, float, float>)createEntityAt);
                });
            }
        }

        public void createEntityAt(float x, float y, float z)
        {
            Entity e = new Entity();
            e["position"].setFloatAttribute("x", x);
            e["position"].setFloatAttribute("y", y);
            e["position"].setFloatAttribute("z", z);
            EntityRegistry.Instance.addEntity(e);
        }

        #endregion
    }
}

