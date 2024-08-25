using Common.Enums.SystemManagement.ResponseManagement;

namespace Common.Constant.SystemManagement.ResponseManagement
{
	public interface IResponse
	{
		ResponseCodes ResponseCode { get; set; }
		string? Message { get; set; }
	}
	public sealed class Response : IResponse
	{
		public ResponseCodes ResponseCode { get; set; }
		public string? Message { get; set; }
		public Response()
		{
		}
		private Response(ResponseCodes responseCode, string? message = null)
		{
			ResponseCode = responseCode;
			Message = message;
		}
		public static Response CreateServerErrorResponse(string? message = null)
		{
			return new Response(ResponseCodes.ServerError, message);
		}
		public static Response CreateNotFoundResponse(string? message = null)
		{
			return new Response(ResponseCodes.NotFound, message);
		}
		public static Response CreateRecordUpdateFailureResponse(string? message = null)
		{
			return new Response(ResponseCodes.UpdateFailure, message);
		}
		public static Response CreateRecordAddFailureResponse(string? message = null)
		{
			return new Response(ResponseCodes.AddFailure, message);
		}
		public static Response CreateFailureResponse(string? message = null)
		{
			return new Response(ResponseCodes.Failure, message);
		}
		public static Response CreateSuccessResponse(string? message = null)
		{
			return new Response(ResponseCodes.Success, message);
		}
	}

	public sealed class Response<T> : IResponse
	{
		public ResponseCodes ResponseCode { get; set; }
		public string? Message { get; set; }
		public T? Data { get; set; }
		public Response()
		{
		}
		private Response(ResponseCodes responseCode, T? data = default, string? message = null)
		{
			ResponseCode = responseCode; Data = data; Message = message;
		}
		public static Response<T> CreateServerErrorResponse(T? data = default, string? message = null)
		{
			return new Response<T>(ResponseCodes.ServerError, data, message);
		}
		public static Response<T> CreateNotFoundResponse(T? data = default, string? message = null)
		{
			return new Response<T>(ResponseCodes.NotFound, data, message);
		}
		public static Response<T> CreateRecordUpdateFailureResponse(T? data = default, string? message = null)
		{
			return new Response<T>(ResponseCodes.UpdateFailure, data, message);
		}
		public static Response<T> CreateRecordAddFailureResponse(T? data = default, string? message = null)
		{
			return new Response<T>(ResponseCodes.AddFailure, data, message);
		}
		public static Response<T> CreateFailureResponse(T? data = default, string? message = null)
		{
			return new Response<T>(ResponseCodes.Failure, data, message);
		}
		public static Response<T> CreateSuccessResponse(T? data = default, string? message = null)
		{
			return new Response<T>(ResponseCodes.Success, data, message);
		}
	}
}
