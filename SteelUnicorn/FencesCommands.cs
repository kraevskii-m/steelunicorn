using Autodesk.AutoCAD.Runtime;

[assembly: CommandClass(typeof(SteelUnicorn.FencesCommands))]

namespace SteelUnicorn
{
    public class FencesCommands
    {
        [CommandMethod("CreateFence", CommandFlags.Modal)]
        public void CreateFence()
        {

        }
    }

}
