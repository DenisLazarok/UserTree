using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserTree.Application.Trees.Commands.CreateNodeCommand;
using UserTree.Application.Trees.Commands.DeleteNodeCommand;
using UserTree.Application.Trees.Commands.RenameNodeCommand;
using UserTree.Application.Trees.Queries.GetTreeQuery;

namespace UserTree.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserTreeController : BaseController
{

   public UserTreeController(IMediator mediator) : base(mediator)
   {
   }

    [HttpGet(Name = "api.user.tree.get")]
    public async Task<ActionResult<string>> Get([FromQuery] GetTreeQuery request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    [HttpPost(Name = "api.user.tree.node.create")]
    public async Task<ActionResult> Create([FromBody] CreateNodeCommand request)
    {
        
        await _mediator.Send(request);
        return Ok();
    }

    [HttpDelete(Name = "api.user.tree.node.delete")]
    public async Task<ActionResult> Delete([FromQuery] DeleteNodeCommand request)
    {
        
        await _mediator.Send(request);
        return Ok();
    }
    
    [HttpPatch(Name = "api.user.tree.node.rename")]
    public async Task<ActionResult> Rename([FromQuery] RenameNodeCommand request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}