using System;
using System.Threading.Tasks;
using CursoAngularDotNet_WebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoAngularDotNet_WebAPI{

    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase{

        private readonly IRepository _repo;

        public DepartamentoController(IRepository repo){
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> get(){
            
            try
            {
                var result = await _repo.GetAllDepartamentosAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados falhou");
            }
        }

        [HttpGet("{DepartamentoId}")]
        public async Task<IActionResult> getByDepartamentoId(int DepartamentoId){
            
            try
            {
                var result = await _repo.GetDepartamentoAsyncById(DepartamentoId);
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Departamento model){
            
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync()){

                return Ok(model);

                }

            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados falhou");
            }
            return BadRequest();
        }

        [HttpPut("{departamentoId}")]
        public async Task<IActionResult> put(int departamentoId, Departamento model){
            
            try
            {
                var departamento = await _repo.GetDepartamentoAsyncById(departamentoId);
                if(departamento == null){
                    return NotFound();
                }
                _repo.Update(model);

                if(await _repo.SaveChangesAsync()){

                return Ok(model);

                }

            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados falhou");
            }
            return BadRequest();
        }

        [HttpDelete("{departamentoId}")]
        public async Task<IActionResult> delete(int departamentoId){
            
            try
            {
                var departamento = await _repo.GetDepartamentoAsyncById(departamentoId);
                if(departamento == null){
                    return NotFound();
                }
                _repo.Delete(departamento);

                if(await _repo.SaveChangesAsync()){

                return Ok(new {message = "Deletado"});

                }

            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados falhou");
            }
            return BadRequest();
        }
    }
}