using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CursoAngularDotNet_WebAPI.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;

namespace CursoAngularDotNet_WebAPI{

    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase{

        private readonly IRepository _repo;

        public FuncionarioController(IRepository repo){
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> get(){
            
            try
            {
                var result = await _repo.GetAllFuncionarioesAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados falhou");
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> upload(){
            
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources","Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if(file.Length > 0){
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, filename.Replace("\""," ").Trim());

                    using(var stream = new FileStream(fullPath, FileMode.Create)){
                        file.CopyTo(stream);
                    }
                }

                return Ok();
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados falhou");
            }

            return BadRequest("Erro ao tentar realizar upload");
        }

        [HttpGet("{FuncionarioId}")]
        public async Task<IActionResult> getByFuncionarioId(int FuncionarioId){
            
            try
            {
                var result = await _repo.GetFuncionarioAsyncById(FuncionarioId);
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados falhou");
            }
        }

        [HttpGet("ByDepartamento/{DepartamentoId}")]
        public async Task<IActionResult> getFuncionarioByDepartamentoId(int DepartamentoId){
            
            try
            {
                var result = await _repo.GetFuncionarioesAsyncByDepartamentoId(DepartamentoId);
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Funcionario model){
            
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

        [HttpPut("{funcionarioId}")]
        public async Task<IActionResult> put(int funcionarioId, Funcionario model){
            
            try
            {
                var funcionario = await _repo.GetFuncionarioAsyncById(funcionarioId);
                if(funcionario == null){
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

        [HttpDelete("{funcionarioId}")]
        public async Task<IActionResult> delete(int funcionarioId){
            
            try
            {
                var funcionario = await _repo.GetFuncionarioAsyncById(funcionarioId);
                if(funcionario == null){
                    return NotFound();
                }
                _repo.Delete(funcionario);

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