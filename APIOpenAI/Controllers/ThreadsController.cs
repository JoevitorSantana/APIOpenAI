using System.Dynamic;
using APIOpenAI.DTO;
using APIOpenAI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIOpenAI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ThreadsController : ControllerBase
    {
        private static List<Entities.Thread> _threads = new List<Entities.Thread>();

        [HttpPost]
        public IActionResult createThread([FromBody] ThreadCreateRequestDTO request)
        {
            try
            {
                Entities.Thread newThread = new Entities.Thread();

                if (request.Metadata != null)
                    newThread.Metadata = request.Metadata;

                if (request.Tool_Resources != null)
                    newThread.ToolResources = request.Tool_Resources;

                _threads.Add(newThread);

                return Ok(newThread.toResponseDTO());
            }
            catch (Exception ex)
            {
                return Problem(
                    detail: "Erro when creating assistant",
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Internal Server Error"
                );
            }
        }

        [HttpGet]
        public IActionResult listThreads()
        {
            try
            {
                List<ThreadResponseDTO> response = _threads.Select(a => a.toResponseDTO()).ToList();
                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(
                    detail: "Erro when listing assistant",
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Internal Server Error"
                );
            }
        }

        [HttpGet("{id}")]
        public IActionResult retriveAssistant(string id)
        {
            try
            {
                ThreadResponseDTO response = _threads.Find(a => a.Id == id).toResponseDTO();

                return Ok(response);
            }
            catch (Exception)
            {
                return Problem(
                    detail: "Erro when retrieving threads",
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Internal Server Error"
                );
            }
        }

        [HttpPost("{id}")]
        public IActionResult modifyThread(string id, [FromBody] ThreadModifyRequestDTO threadBody)
        {
            try
            {
                var thread = _threads.Find(a => a.Id == id);

                if (thread == null)
                {
                    return NotFound("Thread not found!");
                }

                // Atualiza apenas os atributos que não são nulos no body da requisição.
                if (threadBody.Metadata != null)
                {
                    thread.Metadata = threadBody.Metadata;
                }
                if (threadBody.Tool_Resources != null)
                {
                    thread.ToolResources = threadBody.Tool_Resources;
                }

                // Retorna o assistente modificado.
                return Ok(thread.toResponseDTO());
            }
            catch (Exception)
            {
                return Problem(
                    detail: "Erro when modifying assistant",
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Internal Server Error"
                );
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteThread(string id)
        {
            try
            {
                var thread = _threads.Find(a => a.Id == id);

                if (thread == null)
                    return NotFound("Thread not found!");

                _threads.Remove(thread);

                var response = new DeleteResponseDTO() { Id = id, Object = "object.thread", Deleted = true };

                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(
                    detail: "Erro when deleting thread",
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Internal Server Error"
                );
            }
        }

        [HttpGet("{thread_id}/messages")]
        public IActionResult listMessages(string thread_id)
        {
            try
            {
                var thread = _threads.Find(t => t.Id == thread_id);

                if (thread == null) return NotFound("Thread not found!");

                List<MessageResponseDTO> response = thread.Messages.Select(m => m.toResponseDTO()).ToList();

                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(
                    detail: "Erro when list messages",
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Internal Server Error"
                );
            }
        }

        [HttpPost("{id}/messages")]
        public IActionResult createMessage(string id, [FromBody] MessageCreateRequestDTO messageBody)
        {
            try
            {
                var thread = _threads.Find(t => t.Id == id);

                if (thread == null) return NotFound("Thread not found!");

                var newMessage = new Message();

                if (messageBody == null) return NotFound("Message not found!");

                newMessage.ThreadId = id;

                if (messageBody.Content != null) {
                    dynamic obj = new ExpandoObject();
                    obj.Type = "text";
                    obj.Text = messageBody.Content;
                    newMessage.Content.Add(obj);
                }

                if (messageBody.Attachments != null)
                    newMessage.Attachments = messageBody.Attachments;
                if (messageBody.Role != null)
                    newMessage.Role = messageBody.Role;
                if (messageBody.Metadata != null)
                    newMessage.Metadata = messageBody.Metadata;

                thread.Messages.Add(newMessage);

                return Ok(newMessage.toResponseDTO());
            }
            catch (Exception e)
            {
                return Problem(
                    detail: "Erro when creating message",
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Internal Server Error"
                );
            }
        }
    }
}
