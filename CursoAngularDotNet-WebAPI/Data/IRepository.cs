using System.Threading.Tasks;

namespace CursoAngularDotNet_WebAPI.Data
{
    public interface IRepository
    {
         
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Departamento
        Task<Departamento[]> GetAllDepartamentosAsync();        
        Task<Departamento[]> GetDepartamentosAsyncByFuncionarioId(int FuncionarioIdDepartamento);
        Task<Departamento> GetDepartamentoAsyncById(int DepartamentoId);
        
        //Funcionario
        Task<Funcionario[]> GetAllFuncionarioesAsync();
        Task<Funcionario> GetFuncionarioAsyncById(int FuncionarioId);
        Task<Funcionario[]> GetFuncionarioesAsyncByDepartamentoId(int DepartamentoId);
    }
    
}