using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EssayQuestionProcess : HumanResourceProcessBase
    {
        protected readonly IEssayQuestionConverter<SqlDataReader> r_Converter;

        public EssayQuestionProcess(IConnectionStringSource connectionStringSource, IEssayQuestionConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
