namespace DemoDI.Cases
{
    public interface IService
    {
        string Retorno();
    }
    public class ServiceA : IService {
        public string Retorno()
        {
            return "A";
        }
    }
    public class ServiceB : IService {
        public string Retorno()
        {
            return "B";
        }
    }
    public class ServiceC : IService {
        public string Retorno()
        {
            return "C";
        }
    }
}