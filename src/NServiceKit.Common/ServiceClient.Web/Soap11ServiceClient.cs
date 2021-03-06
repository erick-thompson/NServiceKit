using System;
using System.IO;
using NServiceKit.Service;
using NServiceKit.ServiceHost;

namespace NServiceKit.ServiceClient.Web
{

#if SILVERLIGHT || MONOTOUCH || XBOX || ANDROIDINDIE

    public class Soap11ServiceClient : IServiceClient
    {
        public Soap11ServiceClient(string uri)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SetCredentials(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void GetAsync<TResponse>(IReturn<TResponse> request, Action<TResponse> onSuccess, Action<TResponse, Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void GetAsync<TResponse>(string relativeOrAbsoluteUrl, Action<TResponse> onSuccess, 
            Action<TResponse, Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync<TResponse>(string relativeOrAbsoluteUrl, Action<TResponse> onSuccess, 
            Action<TResponse, Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync<TResponse>(IReturn<TResponse> request, Action<TResponse> onSuccess, Action<TResponse, Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void PostAsync<TResponse>(IReturn<TResponse> request, Action<TResponse> onSuccess, Action<TResponse, Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void PostAsync<TResponse>(string relativeOrAbsoluteUrl, object request, 
            Action<TResponse> onSuccess, Action<TResponse,Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void PutAsync<TResponse>(IReturn<TResponse> request, Action<TResponse> onSuccess, Action<TResponse, Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void PutAsync<TResponse>(string relativeOrAbsoluteUrl, object request, Action<TResponse> onSuccess, 
            Action<TResponse,Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void CustomMethodAsync<TResponse>(string httpVerb, IReturn<TResponse> request, Action<TResponse> onSuccess, Action<TResponse, Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void CancelAsync()
        {
            throw new NotImplementedException();
        }

        public void SendAsync<TResponse>(object request, Action<TResponse> onSuccess, Action<TResponse, Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void SendOneWay(object request)
        {
            throw new NotImplementedException();
        }

        public void SendOneWay(string relativeOrAbsoluteUrl, object request)
        {
            throw new NotImplementedException();
        }

        public TResponse Send<TResponse>(object request)
        {
            throw new NotImplementedException();
        }

#if !NETFX_CORE
        public TResponse PostFile<TResponse>(string relativeOrAbsoluteUrl, FileInfo fileToUpload, string mimeType)
        {
            throw new NotImplementedException();
        }
#endif

        public TResponse PostFile<TResponse>(string relativeOrAbsoluteUrl, Stream fileToUpload, string fileName, string mimeType)
        {
            throw new NotImplementedException();
        }

#if !NETFX_CORE
        public TResponse PostFileWithRequest<TResponse>(string relativeOrAbsoluteUrl, FileInfo fileToUpload, object request)
        {
            throw new NotImplementedException();
        }
#endif
        
        public TResponse PostFileWithRequest<TResponse>(string relativeOrAbsoluteUrl, Stream fileToUpload, string fileName, object request)
        {
            throw new NotImplementedException();
        }
    }

#else
    using NServiceKit.Service;

    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using NServiceKit.Text;

    /// <summary>A SOAP 11 service client.</summary>
    public class Soap11ServiceClient : WcfServiceClient
    {
        private BasicHttpBinding binding;

        /// <summary>Initializes a new instance of the NServiceKit.ServiceClient.Web.Soap11ServiceClient class.</summary>
        ///
        /// <param name="uri">URI of the document.</param>
        public Soap11ServiceClient(string uri)
        {
            this.Uri = uri.WithTrailingSlash() + "Soap11";
        }

        private Binding BasicHttpBinding
        {
            get
            {
                if (this.binding == null)
                {
                    this.binding = new BasicHttpBinding {
                        MaxReceivedMessageSize = int.MaxValue,
                        HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
                    };
                }
                return this.binding;
            }
        }

        /// <summary>Gets the binding.</summary>
        ///
        /// <value>The binding.</value>
        protected override Binding Binding
        {
            get { return this.BasicHttpBinding; }
        }

        /// <summary>Gets the message version.</summary>
        ///
        /// <value>The message version.</value>
        protected override MessageVersion MessageVersion
        {
            get { return this.BasicHttpBinding.MessageVersion; }
        }

        /// <summary>Sets a proxy.</summary>
        ///
        /// <param name="proxyAddress">The proxy address.</param>
        public override void SetProxy(Uri proxyAddress)
        {
            var basicBinding = (BasicHttpBinding)Binding;

            basicBinding.ProxyAddress = proxyAddress;
            basicBinding.UseDefaultWebProxy = false;
            basicBinding.BypassProxyOnLocal = false;
            return;
        }
    }

#endif

}