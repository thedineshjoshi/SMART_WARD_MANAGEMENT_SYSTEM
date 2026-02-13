using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Notices.Queries.GetAllNotices
{
    public class GetAllNoticesQuery : IRequest<List<Notice>>
    {
    }
}
