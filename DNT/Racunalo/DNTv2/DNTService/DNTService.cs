using System.ServiceProcess;
using DNTServiceProcessor;

namespace DNTService
{
    public partial class DntService : ServiceBase
    {
        private Processor _processor;

        protected override void OnStart(string[] args)
        {
            _processor = new Processor();
            _processor.Start();
        }
        
        protected override void OnStop()
        {
            if (_processor != null)
            {
                _processor.Stop();
                _processor = null;
            }
        }
    }
}
