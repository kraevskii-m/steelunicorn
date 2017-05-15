using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Autodesk.AutoCAD.Runtime;
using Application = System.Windows.Forms.Application;
using Exception = System.Exception;

[assembly: CommandClass(typeof(SteelUnicorn.FencesCommands))]

namespace SteelUnicorn
{
    public class FencesCommands
    {
        private FenceCreator _fenceCreator = new FenceCreator();

        [CommandMethod("CreateFence", CommandFlags.Modal)]
        public void CreateFence()
        {
            try
            {
                Application.ThreadException +=
                    delegate(object o, ThreadExceptionEventArgs args)
                    {
                        Debug.WriteLine(args.Exception.ToString());
                        MessageBox.Show(@"Exception: " + args.Exception.Message);
                    };

                _fenceCreator.SelectPolyline();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                MessageBox.Show(@"Exception: " + ex.Message);
            }
        }
    }
}