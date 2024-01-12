using UnityEditor;

namespace TestWork.Editor
{
    //Helpful commands for quick navigation in the editor
    internal static class WindowsCommands
    {
        private static readonly Console Console = new();
        private static readonly Inspector Inspector = new();
        private static readonly Project Project = new();

        [MenuItem("TestWork/Console/Clear &q")]
        private static void ClearConsole() =>
            Console.Clear();

        [MenuItem("TestWork/Inspector/ToggleLockMode &w")]
        private static void LockInspector() =>
            Inspector.ToggleLockMode();

        [MenuItem("TestWork/Inspector/ToggleDebugMode &e")]
        private static void ToggleDebugMode() =>
            Inspector.ToggleDebugMode();

        [MenuItem("TestWork/Project/SearchAllScenes &r")]
        private static void SearchAllScenes() =>
            Project.Filtrate("t:Scene");
    }
}