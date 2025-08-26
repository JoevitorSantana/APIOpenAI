using APIOpenAI.DTO;
using APIOpenAI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIOpenAI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AssistantsController : ControllerBase
    {
        private static List<Assistant> _assistants = new List<Assistant>();

        [HttpPost]
        public IActionResult createAssistant([FromBody] AssistantCreateRequestDTO assistant)
        {
            try
            {
                Assistant newAssistant = new Assistant() 
                    { Name = assistant.Name, Model = assistant.Model, Tools = assistant.Tools, Instructions = assistant.Instructions };

                _assistants.Add(newAssistant);

                return Ok(newAssistant.toResponseDTO());
            }
            catch (Exception ex) {
                return Problem(
                    detail: "Erro when creating assistant",
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Internal Server Error"
                );
            }
        }

        [HttpGet]
        public IActionResult listAssistants()
        {
            try
            {
                List<AssistantResponseDTO> response = _assistants.Select(a => a.toResponseDTO()).ToList();
                return Ok(response);
            } catch (Exception e)
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
                AssistantResponseDTO response = _assistants.Find(a => a.Id == id).toResponseDTO();

                return Ok(response);
            } catch (Exception)
            {
                return Problem(
                    detail: "Erro when retrieving assistant",
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Internal Server Error"
                );
            }
        }

        [HttpPost("{id}")]
        public IActionResult modifyAssistant(string id, [FromBody] AssistantModifyRequestDTO assistantBody)
        {
            try
            {
                // Encontra o assistente pelo ID.
                var assistant = _assistants.Find(a => a.Id == id);

                // Se o assistente não for encontrado, retorna 404 Not Found.
                if (assistant == null)
                {
                    return NotFound("Assistant not found!");
                }

                // Atualiza apenas os atributos que não são nulos no body da requisição.
                if (assistantBody.Name != null)
                {
                    assistant.Name = assistantBody.Name;
                }
                if (assistantBody.Description != null)
                {
                    assistant.Description = assistantBody.Description;
                }
                if (assistantBody.Model != null)
                {
                    assistant.Model = assistantBody.Model;
                }
                if (assistantBody.Instructions != null)
                {
                    assistant.Instructions = assistantBody.Instructions;
                }
                if (assistantBody.Tools != null)
                {
                    assistant.Tools = assistantBody.Tools;
                }
                if (assistantBody.Metadata != null)
                {
                    assistant.Metadata = assistantBody.Metadata;
                }
                if (assistantBody.Top_p.HasValue)
                {
                    assistant.Topp = assistantBody.Top_p.Value;
                }
                if (assistantBody.Temperature.HasValue)
                {
                    assistant.Temperature = assistantBody.Temperature.Value;
                }
                if (assistantBody.Response_Format != null)
                {
                    assistant.ResponseFormat = assistantBody.Response_Format;
                }

                // Retorna o assistente modificado.
                return Ok(assistant.toResponseDTO());
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
        public IActionResult deleteAssistant(string id)
        {
            try
            {
                var assistant = _assistants.Find(a => a.Id == id);

                if (assistant == null)
                    return NotFound("Assistant not found!");

                _assistants.Remove(assistant);

                var response = new DeleteResponseDTO() { Id = id, Object = "object.assistant", Deleted  = true };

                return Ok(response);
            } catch (Exception e)
            {
                return Problem(
                    detail: "Erro when deleting assistant",
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Internal Server Error"
                );
            }
        }
    }
}
