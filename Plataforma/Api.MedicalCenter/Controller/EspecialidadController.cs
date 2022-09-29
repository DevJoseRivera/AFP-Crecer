using Api.Common.Responses;
using Api.MedicalCenter.Requests;
using Api.MedicalCenter.Responses;
using Domain.Core.MedicalCenter.Models;
using Library.Clients.Contracts;
using Library.Clients.Responses;
using Microsoft.AspNetCore.Mvc;
using Services.MedicalCenter.Contracts;

namespace Api.MedicalCenter.Controller
{
    [Route("api/v1")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly IGenericService<Especialidad> _service;

        public EspecialidadController(IGenericService<Especialidad> service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene el listado de especialidades médicas
        /// </summary>
        /// <returns>Un resultado HTTP que confirma si la acción fue satisfactoria</returns>
        /// <response code="200">Si la petición es procesada satisfactoriamente</response>              
        /// <response code="500">Si se obtiene un error interno del servidor</response>
        [HttpGet("especialidad")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IListResponse<EspecialidadDetailsModel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEspecialidadAsync()
        {
            var response = new ListResponse<EspecialidadDetailsModel>();

            try
            {
                var especialidad = await _service.GetItemsAsync();

                response.Items = especialidad.ToDetailsModel();
            }
            catch (Exception)
            {
                return response.ToInternalServerError(message: "Ocurrio un error interno en el servidor.");
            }

            return response.ToOkResult();
        }

        /// <summary>
        /// Adiciona un nuevo tipo de especialidad médica
        /// </summary>
        /// <param name="request">Información para crear un nuevo tipo de especialidad médica</param>
        /// <returns>Un resultado HTTP que confirma si la acción fue satisfactoria</returns>
        /// <response code="201">Si el elemento ha sido creado</response>              
        /// <response code="400">Si la petición es incorrecta</response>
        /// <response code="500">Si se obtiene un error interno del servidor</response>
        [HttpPost("crear-especialidad")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ICreatedResponse<int?>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEspecialidadAsync([FromBody] EspecialidadRequest request)
        {
            var response = new CreatedResponse<int?>();

            try
            {
                var especialidad = await _service.SaveItemAsync(request.ToEntity());

                response.Id = especialidad.Id;
            }
            catch (Exception)
            {
                return response.ToInternalServerError("Ocurrio un error interno en el servidor.");
            }

            return response.ToCreatedResult();
        }

        /// <summary>
        /// Actualiza la información de un tipo de especialidad médica
        /// </summary>
        /// <param name="id">Identificador del tipo de especialidad médica</param>
        /// <param name="request">Información para actualizar un tipo especialidad médica</param>
        /// <returns>Un resultado HTTP que confirma si la acción fue satisfactoria</returns>
        /// <response code="200">Si la petición es procesada satisfactoriamente</response>   
        /// <response code="400">Si la petición es incorrecta</response>
        /// <response code="404">Si el elemento no es encontrado</response>
        /// <response code="500">Si se obtiene un error interno del servidor</response>
        [HttpPut("actualizar-especialidad/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEspecialidadAsync(short id, [FromBody] EspecialidadRequest request)
        {
            var response = new Response();

            try
            {
                var especialidad = await _service.GetItemAsync(id);

                if (especialidad is null)
                    return response.ToNotFoundResult();

                especialidad.Nombre = request.Nombre;

                await _service.UpdateItemAsync(especialidad);
            }
            catch (Exception)
            {
                return response.ToInternalServerError("Ocurrio un error interno en el servidor.");
            }

            return response.ToOkResult();
        }

        /// <summary>
        /// Elimina la información de un tipo de especialidad médica
        /// </summary>
        /// <param name="id">Identificador del tipo de especialidad médica</param>
        /// <param name="request">Información para actualizar un tipo de especialidad médica</param>
        /// <returns>Un resultado HTTP que confirma si la acción fue satisfactoria</returns>
        /// <response code="200">Si la petición es procesada satisfactoriamente</response>
        /// <response code="404">Si el elemento no es encontrado</response>
        /// <response code="500">Si se obtiene un error interno del servidor</response>
        [HttpDelete("eliminar-especialidad/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEspecialidadAsync(short id)
        {
            var response = new Response();

            try
            {
                var especialidad = await _service.GetItemAsync(id);

                if (especialidad is null)
                    return response.ToNotFoundResult();

                await _service.DeleteItemAsync(id);
            }
            catch (Exception)
            {
                return response.ToInternalServerError("Ocurrio un error interno en el servidor.");
            }

            return response.ToOkResult();
        }

        /// <summary>
        /// Obtiene la información de un tipo de especialidad por su ID.
        /// </summary>
        /// <param name="id">Identificador del tipo de especialidad</param>
        /// <returns>Un resultado HTTP que confirma si la acción fue satisfactoria</returns>
        /// <response code="200">Si la petición es procesada satisfactoriamente</response>
        /// <response code="404">Si el elemento no es encontrado</response>
        /// <response code="500">Si se obtiene un error interno del servidor</response>
        [HttpGet("especialidad/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ISingleResponse<EspecialidadDetailsModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTrainingType(short id)
        {
            var response = new SingleResponse<EspecialidadDetailsModel>();

            try
            {
                var especialidad = await _service.GetItemAsync(id);

                if (especialidad is null)
                    return response.ToNotFoundResult();

                response.Item = especialidad.ToDetailsModel();
            }
            catch (Exception)
            {
                return response.ToInternalServerError("Ocurrio un error interno en el servidor.");
            }

            return response.ToOkResult();
        }
    }
}
