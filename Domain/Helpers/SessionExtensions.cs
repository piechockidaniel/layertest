using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public static class SessionExtensions
    {
        public static bool Exists<T>(this Session session, CriteriaOperator criteria)
        {
            return (bool)session.Evaluate<T>(CriteriaOperator.Parse("Exists()"), criteria);
        }
    }
}
