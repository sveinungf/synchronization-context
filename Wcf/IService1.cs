using System.ServiceModel;
using System.Threading.Tasks;

namespace Wcf
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Task<string> GetData();
    }
}
