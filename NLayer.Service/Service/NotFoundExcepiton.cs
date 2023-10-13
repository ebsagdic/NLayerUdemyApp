using System.Runtime.Serialization;

namespace NLayer.Service.Service
{
    [Serializable]
    public class NotFoundExcepiton : Exception
    {
        public NotFoundExcepiton(string message) : base(message)
        {

        }
    }
}