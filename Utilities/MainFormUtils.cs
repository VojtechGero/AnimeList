using AnimeList.Components;
using AnimeList.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeList.Utilities
{
    internal static class MainFormUtils
    {
        internal enum SortType : int
        {
            None=0,
            Aplhabetical=1,
            Score=2
        }

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
        internal static int getDuplicate(long id,List<AContent> Content)
        {
            int output = -1;
            for (int i = 0; i < Content.Count; i++)
            {
                if (Content[i].ID == id) return i;
            }
            return output;
        }

        internal static string WatchButtonUpdate(bool inProgress)
        {
            if (inProgress)
            {
                return "UnWatch";
            }
            else
            {
                return "Watch";
            }
        }

        internal static List<AContent> SortBy(List<AContent> Content, SortType s)
        {
            IEnumerable<AContent> Sorted = Content;
            switch ((int)s)
            {
                case 1:
                    Sorted=Sorted.OrderBy(content => content.name);
                    break;
                case 2:
                    Sorted = Sorted.OrderByDescending(content => content.Score);
                    break;
            }
            return Sorted.OrderByDescending(content => content.inProgress).ToList();
        }
    }
}
