using FluentValidation;
using GW.CustomerManagement.Application.Interfaces;
using GW.CustomerManagement.Application.ViewModels;
using GW.CustomerManagement.Domain.Entities;
using GW.CustomerManagement.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GW.CustomerManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerAppService _customerAppService;
    private readonly IValidator<CreateCustomerViewModel> _createCustomerValidator;
    private readonly IValidator<UpdateNameViewModel> _updateNameValidator;
    private readonly IValidator<AddressViewModel> _addressValidator;

    public CustomerController(ICustomerAppService customerAppService, IValidator<CreateCustomerViewModel> createCustomerValidator, 
        IValidator<UpdateNameViewModel> updateNameValidator, IValidator<AddressViewModel> addressValidator)
    {
        _customerAppService = customerAppService;
        _createCustomerValidator = createCustomerValidator;
        _updateNameValidator = updateNameValidator;
        _addressValidator = addressValidator;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> Get([FromRoute] Guid id)
    {
        try
        {
            return Ok(await _customerAppService.Get(id));
        }
        catch (Exception ex) when (ex is ArgumentException || ex is CustomerManagementException)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    public ActionResult GetAll([FromQuery] PaginationFilterViewModel pageFilter)
    {
        try
        {
            return Ok(_customerAppService.GetAll(pageFilter));
        }
        catch (Exception ex) when (ex is ArgumentException || ex is CustomerManagementException)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateCustomerViewModel customer)
    {
        try
        {
            var validator = _createCustomerValidator.Validate(customer);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            var newCustomer = await _customerAppService.Create(customer);

            return Ok(newCustomer);
        }
        catch (Exception ex) when (ex is ArgumentException || ex is CustomerManagementException)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        try
        {
            await _customerAppService.Delete(id);

            return Ok($"Usuário ID \"{id}\" deletado com sucesso");
        }
        catch (Exception ex) when (ex is ArgumentException || ex is CustomerManagementException)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    [Route("update-name/{id}")]
    public async Task<ActionResult> UpdateName([FromRoute] Guid id, [FromBody] UpdateNameViewModel newName)
    {
        try
        {
            var validator = _updateNameValidator.Validate(newName);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            await _customerAppService.UpdateName(id, newName);

            return Ok($"Nome do Usuário ID \"{id}\" alterado com sucesso");
        }
        catch (Exception ex) when (ex is ArgumentException || ex is CustomerManagementException)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    [Route("update-address/{id}")]
    public async Task<ActionResult> UpdateAddress([FromRoute] Guid id, [FromBody] AddressViewModel newAddress)
    {
        try
        {
            var validator = _addressValidator.Validate(newAddress);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            await _customerAppService.UpdateAddress(id, newAddress);

            return Ok($"Endereço do Usuário ID \"{id}\" alterado com sucesso");
        }
        catch (Exception ex) when (ex is ArgumentException || ex is CustomerManagementException)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
