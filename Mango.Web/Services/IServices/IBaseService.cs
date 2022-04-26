using Mango.Web.Models;
using Mango.Web.Models.Dtos;
using System;
using System.Threading.Tasks;

namespace Mango.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        #region Properties

        public ResponseDto ResponseDto { get; set; }

        #endregion

        #region Methods

        Task<T> SendAsync<T>(ApiRequest apiRequest);

        #endregion
    }
}
