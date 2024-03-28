using AnimeList.Components;
using AnimeList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeList.Utilities
{
    internal static class MainFormUtils
    {
        internal static void listBoxScaling(int dpi,MyListBox listBox)
        {
            double scale = (float)dpi / 96;
            var scaled = listBox.ItemHeight * scale;
            listBox.ItemHeight = (int)scaled;
        }

        internal static int getIndex(long id,List<AContent> Content)
        {
            for (int i = 0; i < Content.Count; i++)
            {
                if (Content[i].ID == id) return i;
            }
            return -1;
        }
        internal static bool needsChage(bool hasScroll,MyListBox listBox)
        {
            bool n = listBox.HasScroll();
            if (n != hasScroll)
            {
                return true;
            }
            else return false;
        }

    }
}
