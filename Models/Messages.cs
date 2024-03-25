using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ListOfCustomers_New.Models
{
    public static class Messages
    {
       public static void NewMessageYN(string TextMessage) 
        {
            MessageBox.Show(
        TextMessage,
        "Notice",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);
        }

        public static void NewMessage(string TextMessage)
        {
            MessageBox.Show(
        TextMessage,
        "Notice",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
