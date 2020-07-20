using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Enums;
using Lottery.Interfaces.Analyzer;
using Lottery.Interfaces.Services;

namespace Lottery.Service.Analyzer
{
    public delegate IAnalyzer AnalyzerResolver(AnalyzeType analyzeType);
}
