using System.Net;

namespace SR.Tool.Proxy
{
    internal static class Program
    {
        private const string Title = "SR 代理";

        private static ProxyService s_proxyService;
        private static EventHandler s_processExitHandler = new EventHandler(OnProcessExit);
        
        private static void Main(string[] args)
        {
            Console.Title = Title;
            CheckProxy();

            s_proxyService = new ProxyService("127.0.0.1", 21000);
            AppDomain.CurrentDomain.ProcessExit += s_processExitHandler;
            Console.WriteLine("启动完成");

            Thread.Sleep(-1);
        }

        private static void OnProcessExit(object sender, EventArgs args)
        {
            s_proxyService.Shutdown();
        }

        public static void CheckProxy()
        {
            try
            {
                string ProxyInfo = GetProxyInfo();
                if (ProxyInfo != null)
                {
                    Console.WriteLine("嗯...看来您正在使用其他代理软件（例如Clash，V2RayN，Fiddler等）)");
                    Console.WriteLine($"您的系统代理: {ProxyInfo}");
                    Console.WriteLine("您必须关闭所有其他代理软件才能确保 SR.Tool.Proxy 能够正常工作。");
                    Console.WriteLine("如果您关闭了其他代理软件，或者您认为您没有使用其他代理，请按任意键继续。");
                    Console.ReadKey();
                }
            }
            catch (NullReferenceException)
            {

            }
        }

        public static string GetProxyInfo()
        {
            try
            {
                IWebProxy proxy = WebRequest.GetSystemWebProxy();
                Uri proxyUri = proxy.GetProxy(new Uri("https://www.example.com"));

                string proxyIP = proxyUri.Host;
                int proxyPort = proxyUri.Port;
                string info = proxyIP + ":" + proxyPort;
                return info;
            }
            catch
            {
                return null;
            }
        }
    }
}