using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FuzzyFramework;
using FuzzyFramework.Sets;
using FuzzyFramework.Dimensions;
using FuzzyFramework.Members;

namespace FuzzyDemo_DSS_Team_3
{
    class stockFuzzy : DiscreteMember
    {
        #region Contructor
        public stockFuzzy(IDiscreteDimension dimension, string caption)
            : base(dimension, caption)
        {
        }
        #endregion
    }
}
