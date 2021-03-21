using System.Collections.Generic;

namespace SortProject.Models.Interfaces
{
    public interface IStrategy
    {
        int[] Algorithm(int[] mas, ref List<string> infoAboutSort, bool flag = true);
    }
}
