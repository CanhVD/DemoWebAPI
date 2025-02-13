namespace DemoWebAPI.Repository
{
    public class MyService : IMyService
    {
        private readonly Guid _operationId;

        public MyService()
        {
            _operationId = Guid.NewGuid();
        }

        public Guid GetOperationId()
        {
            return _operationId;
        }
    }
}
