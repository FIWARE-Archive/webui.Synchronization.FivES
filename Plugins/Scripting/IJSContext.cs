using System;

namespace ScriptingPlugin
{
    /// <summary>
    /// Interface to be implemented by JavaScript context when passed to other plugins.
    /// </summary>
    public interface IJSContext
    {
        /// <summary>
        /// Executes the script.
        /// </summary>
        /// <param name="script">Script to be executed.</param>
        void Execute(string script);

        /// <summary>
        /// Executes the script with given arguments, which are available as arguments[0], arguments[1] and so on.
        /// </summary>
        /// <param name="script">Script to be executed.</param>
        /// <param name="arguments">Arguments passed to the script.</param>
        void Execute(string script, params object[] arguments);

        /// <summary>
        /// Registers a new global object in this context. The fields and methods of the new object correspond to the
        /// passed C# object.
        /// </summary>
        /// <param name="name">Name of the global object.</param>
        /// <param name="csObject">Corresponding C# object.</param>
        void CreateGlobalObject(string name, object csObject);
    }
}

