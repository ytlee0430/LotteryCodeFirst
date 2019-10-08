using System.Collections.Generic;

namespace Lottery.Interfaces
{
    public interface ITableMapper
    {
        void AnalyzeData(List<List<string>> crawlerResultList);
    }
}