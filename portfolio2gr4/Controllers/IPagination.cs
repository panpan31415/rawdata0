using System.Net.Http;
namespace portfolio2gr4.Controllers
{
	interface IPagination
	{
		int limit { set; get; }
		int offset { set; get; }
        void setLimitOffset(HttpRequestMessage Request);

	}
}
