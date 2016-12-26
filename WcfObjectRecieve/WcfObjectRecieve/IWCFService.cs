using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfObjectRecieve
{
    [ServiceContract]
    internal interface IWcfService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "GrowUpByObject",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        Student GrowUpByObject(Student requestModel);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "GrowUpByStream",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        Student GrowUpByStream(Stream stream);
    }
}
