using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfObjectRecieve
{
    [ServiceContract]
    internal interface IWcfService
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "GetStudent")]
        Student GetStudent();

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "GrowUpByObject")]
        Student GrowUpByObject(Student requestModel);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "GrowUpByStream")]
        Student GrowUpByStream(Stream stream);
    }
}
