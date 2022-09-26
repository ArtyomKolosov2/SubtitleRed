using MediatR;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.Identity.Logout;

public class LogoutCommand : IRequest<Result<LogoutResponseDto, Error>>
{
}