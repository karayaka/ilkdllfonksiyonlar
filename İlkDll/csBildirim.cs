using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personel_Puantaj.cs
{
    class csBildirim
    {
        public static void bildirim(string Baslik, string text)
        {
            Tulpep.NotificationWindow.PopupNotifier popupNotifier = new Tulpep.NotificationWindow.PopupNotifier();
            popupNotifier.TitleText = Baslik;
            popupNotifier.ContentText = text;
            
            popupNotifier.Popup();
        }
    }
}
