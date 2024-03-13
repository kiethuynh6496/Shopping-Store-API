using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DTOs.AuthDTOs;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface;

namespace Shopping_Store_API.Controllers.v1
{
	[ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/address")]
    public class AddressController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddressController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get the addresses of the current User
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApiError"></exception>
        [HttpGet("get-address")]
        [Authorize]
        public async Task<IActionResult> GetAddress()
        {
            var userAddress = _unitOfWork.Address.FindByCondition(a => a.UserId == Request.Cookies["userId"]).ToList();

            if (userAddress == null) throw new ApiError((int)ErrorCodes.UserIsUnauthenticated);
            var userAddressDTO = _mapper.Map<IEnumerable<AddressResponseDTO>>(userAddress);

            return CustomResult(ResponseMesssage.DataAreLoadedSuccessfully.DisplayName(), userAddressDTO, System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Create a new Address to Checkout
        /// </summary>
        /// <param name="addressRequestDTO"></param>
        /// <returns></returns>
        /// <exception cref="ApiError"></exception>
        [HttpPost("create-address")]
        [Authorize]
        public async Task<IActionResult> CreateAddress(AddressRequestDTO addressRequestDTO)
        {
            var newAddress = new Address
            {
                UserId = Request.Cookies["userId"],
                NickName = addressRequestDTO.NickName,
                AddressName = addressRequestDTO.AddressName,
                Phone = addressRequestDTO.Phone,
                City = "HCM",
                isDefault = false
            };

            var createNewAddress = await _unitOfWork.Address.Add(newAddress);
            if (createNewAddress == false)
            {
                throw new ApiError((int)ErrorCodes.NewAddressCantCreated);
            }

            var result = await _unitOfWork.CommitAsync();
            if (result <= 0) throw new ApiError((int)ErrorCodes.DataArentUpdatedSuccessfully);

            return CustomResult(ResponseMesssage.DataAreCreatedSuccessfully.DisplayName(), System.Net.HttpStatusCode.Created);
        }

        /// <summary>
        /// Set a default address to Checkout
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApiError"></exception>
        [HttpPatch("set-default-address")]
        [Authorize]
        public async Task<IActionResult> SetDefaultAddress(int id)
        {
            var userAddress = await _unitOfWork.Address.FindById(a => a.UserId == Request.Cookies["userId"] && a.isDefault == true, true);
            if(userAddress != null)
            {
                 userAddress.isDefault = false;
                var updateUserAddress = _unitOfWork.Address.Update(userAddress);
                if (updateUserAddress == false) throw new ApiError((int)ErrorCodes.DataArentUpdatedSuccessfully);
            }

            var defaultUserAddress = await _unitOfWork.Address.FindById(a => a.UserId == Request.Cookies["userId"] && a.Id == id, true);
            if (defaultUserAddress == null) throw new ApiError((int)ErrorCodes.UserIsUnauthenticated);

            defaultUserAddress.isDefault = true;
            var updateDefaultUserAddress = _unitOfWork.Address.Update(defaultUserAddress);
            if (updateDefaultUserAddress == false) throw new ApiError((int)ErrorCodes.DataArentUpdatedSuccessfully);

            var result = await _unitOfWork.CommitAsync();
            if (result <= 0) throw new ApiError((int)ErrorCodes.DataArentUpdatedSuccessfully);

            var userAddressDTO = _mapper.Map<AddressResponseDTO>(defaultUserAddress);

            return CustomResult(ResponseMesssage.DataAreLoadedSuccessfully.DisplayName(), userAddressDTO, System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Delete a User's Address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ApiError"></exception>
        [HttpDelete("delete-address")]
        [Authorize]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var userAddress = await _unitOfWork.Address.FindById(a => a.UserId == Request.Cookies["userId"] && a.Id == id, true);
            if (userAddress == null) throw new ApiError((int)ErrorCodes.UserIsUnauthenticated);

            var deleteUserAddress = _unitOfWork.Address.Delete(userAddress);
            if (deleteUserAddress == false) throw new ApiError((int)ErrorCodes.DataArentDeletedSuccessfully);

            var result = await _unitOfWork.CommitAsync();
            if (result <= 0) throw new ApiError((int)ErrorCodes.DataArentDeletedSuccessfully);

            var userAddressList = _unitOfWork.Address.FindByCondition(a => a.UserId == Request.Cookies["userId"]).ToList();
            var userAddressDTO = _mapper.Map<IEnumerable<AddressResponseDTO>>(userAddressList);

            return CustomResult(ResponseMesssage.DataAreDeletedSuccessfully.DisplayName(), userAddressDTO, System.Net.HttpStatusCode.OK);
        }
    }
}