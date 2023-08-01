using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Posts.Commands
{
    public class DeleteCommand : IRequest<Unit>
    {

        public int PostID { get; set; }
    }
}
