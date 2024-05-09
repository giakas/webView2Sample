using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
#pragma warning restore CS0618
    [ComVisible(true)]
    public class BridgeRemoteObject
    {
        public void ShowMessage(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
