using SchoolProject.Core.Features.Users.Queries.Responses;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Users.Queries.Models;

public record GetUserListQuery(int PageNumber = 1, int PageSize = 20) : IRequest<PaginatedResult<GetUserResponse>>;