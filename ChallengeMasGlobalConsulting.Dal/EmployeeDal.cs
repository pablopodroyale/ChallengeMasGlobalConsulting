using ChallengeMasGlobalConsulting.Dal.Contracts;
using Core.Dto.Response;
using Core.Shared;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMasGlobalConsulting.Dal
{
    public class EmployeeDal : IEmployeeDal
    {
        private HttpClient _httpClient;
        private bool disposed;
        private readonly ApplicattionSettings _applicationSettings;

        public EmployeeDal(HttpClient httpClient, IOptions<ApplicattionSettings> applicationSettings)
        {
            this._httpClient = httpClient;
            this._applicationSettings = applicationSettings.Value;
            _httpClient.BaseAddress = new Uri(_applicationSettings.ApiBaseUrl);
            disposed = false;
        }

        public async Task<ResponseDto<ICollection<EmployeeResponseDto>>> GetAsync()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var response = await _httpClient.GetAsync("employees");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var employees = JsonConvert.DeserializeObject<ICollection<EmployeeResponseDto>>(await (response.Content.ReadAsStringAsync()));
            return new ResponseDto<ICollection<EmployeeResponseDto>> { Status = 200, Content = employees };
        }
    }
}
