using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ParseLib
{
    [ServiceContract]
    interface IStringService
    {
        [OperationContract]
        string getString(string s11);

    }
}



